using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Walter
{
	[Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class InsertElevationCommand : IExternalCommand
	{
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			using (Transaction transaction = new Transaction(commandData.Application.ActiveUIDocument.Document, "Test"))
			{
				try
				{
					bool isValidSelect = false;
					do
					{
						Reference reference = commandData.Application.ActiveUIDocument.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element, "Please select room.");
						if (reference == null)
						{
							TaskDialog.Show("Error", "It is not object!");
						}
						else
						{
							Element element = commandData.Application.ActiveUIDocument.Document.GetElement(reference);
							Room selectedRoom = element as Room;

							if (selectedRoom == null)
							{
								TaskDialog.Show("Error", "It is not room!");
							}
							else
							{
								IList<IList<BoundarySegment>> roomSegments = selectedRoom.GetBoundarySegments(new SpatialElementBoundaryOptions { SpatialElementBoundaryLocation = SpatialElementBoundaryLocation.Finish });
								Curve curveRight = null;
								Curve curveLeft = null;
								Curve curveUp = null;
								Curve curveDown = null;
								transaction.Start();
								foreach (IList<BoundarySegment> segments in roomSegments)
								{
									foreach (BoundarySegment segment in segments)
									{
										Line cu = segment.GetCurve() as Line;
										Element e = commandData.Application.ActiveUIDocument.Document.GetElement(segment.ElementId);
										Wall wall = e as Wall;
										if (cu.Direction.X == -1)
										{
											if (curveUp != null)
											{
												curveUp = Line.CreateBound(curveUp.GetEndPoint(0), segment.GetCurve().GetEndPoint(1)) as Curve;
											}
											else
											{
												curveUp = segment.GetCurve();
											}
											
										}
										else if (cu.Direction.X == 1)
										{
											if (curveDown != null)
											{
												curveDown = Line.CreateBound(curveDown.GetEndPoint(0), segment.GetCurve().GetEndPoint(1)) as Curve;
											}
											else
											{
												curveDown = segment.GetCurve();
											}
										}
										else if (cu.Direction.Y == -1)
										{
											if (curveLeft != null)
											{
												curveLeft = Line.CreateBound(curveLeft.GetEndPoint(0), segment.GetCurve().GetEndPoint(1)) as Curve;
											}
											else
											{
												curveLeft = segment.GetCurve();
											}
										}
										else if (cu.Direction.Y == 1)
										{
											if (curveRight != null)
											{
												curveRight = Line.CreateBound(curveRight.GetEndPoint(0), segment.GetCurve().GetEndPoint(1)) as Curve;
											}
											else
											{
												curveRight = segment.GetCurve();
											}
										}
									}
								}

								IEnumerable<ViewFamilyType> viewFamilyTypes = from elem in new FilteredElementCollector(commandData.Application.ActiveUIDocument.Document).OfClass(typeof(ViewFamilyType))
																			  let type = elem as ViewFamilyType
																			  where type.ViewFamily == ViewFamily.Elevation
																			  select type;

								ElevationMarker markerUp = ElevationMarker.CreateElevationMarker(commandData.Application.ActiveUIDocument.Document, viewFamilyTypes.FirstOrDefault().Id, new XYZ(curveUp.GetEndPoint(0).X, curveUp.GetEndPoint(0).Y - 1, curveUp.GetEndPoint(0).Z), 1);
								ViewSection sectionUp = markerUp.CreateElevation(commandData.Application.ActiveUIDocument.Document, commandData.Application.ActiveUIDocument.Document.ActiveView.Id, 1);
								sectionUp.get_Parameter(BuiltInParameter.VIEWER_BOUND_OFFSET_FAR).Set(3);

								ElevationMarker markerDown = ElevationMarker.CreateElevationMarker(commandData.Application.ActiveUIDocument.Document, viewFamilyTypes.FirstOrDefault().Id, new XYZ(curveDown.GetEndPoint(0).X, curveDown.GetEndPoint(0).Y + 1, curveDown.GetEndPoint(0).Z), 1);
								ViewSection sectionDown = markerDown.CreateElevation(commandData.Application.ActiveUIDocument.Document, commandData.Application.ActiveUIDocument.Document.ActiveView.Id, 3);
								sectionDown.get_Parameter(BuiltInParameter.VIEWER_BOUND_OFFSET_FAR).Set(3);

								ElevationMarker markerLeft = ElevationMarker.CreateElevationMarker(commandData.Application.ActiveUIDocument.Document, viewFamilyTypes.FirstOrDefault().Id, new XYZ(curveLeft.GetEndPoint(0).X + 1, curveLeft.GetEndPoint(0).Y, curveLeft.GetEndPoint(0).Z), 1);
								ViewSection sectionLeft = markerLeft.CreateElevation(commandData.Application.ActiveUIDocument.Document, commandData.Application.ActiveUIDocument.Document.ActiveView.Id, 0);
								sectionLeft.get_Parameter(BuiltInParameter.VIEWER_BOUND_OFFSET_FAR).Set(3);

								ElevationMarker markerRight = ElevationMarker.CreateElevationMarker(commandData.Application.ActiveUIDocument.Document, viewFamilyTypes.FirstOrDefault().Id, new XYZ(curveRight.GetEndPoint(0).X - 1, curveRight.GetEndPoint(0).Y, curveRight.GetEndPoint(0).Z), 1);
								ViewSection sectionRight = markerRight.CreateElevation(commandData.Application.ActiveUIDocument.Document, commandData.Application.ActiveUIDocument.Document.ActiveView.Id, 2);
								sectionRight.get_Parameter(BuiltInParameter.VIEWER_BOUND_OFFSET_FAR).Set(3);
								transaction.Commit();
								isValidSelect = true;
							}	
							
						}
					} while (!isValidSelect);
				}
				catch (Exception e)
				{

					return Result.Failed;
				}
			}
			return Result.Succeeded;
		}
	}
}
