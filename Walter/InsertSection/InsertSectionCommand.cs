using Autodesk.Revit.DB;
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
	public class InsertSectionCommand : IExternalCommand
	{
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			using (Transaction transaction = new Transaction(commandData.Application.ActiveUIDocument.Document,"InsertSection"))
			{
				try
				{
					
					bool isValidSelect = false;
					do
					{
						Reference selectedObject = commandData.Application.ActiveUIDocument.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element, "Select door!");
						if (selectedObject != null)
						{
							Element element = commandData.Application.ActiveUIDocument.Document.GetElement(selectedObject.ElementId);
							ElementType elementType = commandData.Application.ActiveUIDocument.Document.GetElement(element.GetTypeId()) as ElementType;
							double height = elementType.get_Parameter(BuiltInParameter.DOOR_HEIGHT).AsDouble();
							double width = elementType.get_Parameter(BuiltInParameter.DOOR_WIDTH).AsDouble();
							FamilyInstance familyInstance = element as FamilyInstance;
							if (height == 0 )
							{
								height = familyInstance.get_Parameter(BuiltInParameter.DOOR_HEIGHT).AsDouble();
							}
							if (width == 0)
							{
								width = familyInstance.get_Parameter(BuiltInParameter.DOOR_WIDTH).AsDouble();
							}
							
							Transform doorTransform = familyInstance.get_Geometry(new Options()).Select(s =>s as GeometryInstance).Select(y=>y.Transform).FirstOrDefault();
							if (element.Category.Name == "Doors")
							{
								Document doc = commandData.Application.ActiveUIDocument.Document;
								View view = doc.ActiveView;
								ViewFamilyType viewFamilyType = new FilteredElementCollector(commandData.Application.ActiveUIDocument.Document).OfClass(typeof(ViewFamilyType)).Cast<ViewFamilyType>().Where(t => t.ViewFamily == ViewFamily.Section).FirstOrDefault();
								if (viewFamilyType == null)
								{
									return Result.Failed;
								}
								Transform curveTransform = doorTransform;
								curveTransform.BasisX = new XYZ(curveTransform.BasisX.Y, curveTransform.BasisX.X, curveTransform.BasisX.Z);
								XYZ origin = curveTransform.Origin; // mid-point of location curve
								XYZ viewDirection = curveTransform.BasisX.Normalize(); // tangent vector along the location curve
								XYZ normal = viewDirection.CrossProduct(XYZ.BasisZ).Normalize(); // location curve normal @ mid-point

								Transform transform = Transform.Identity;
								transform.Origin = origin;
								transform.BasisX = normal;
								transform.BasisY = XYZ.BasisZ;

								// can use this simplification because wall's "up" is vertical.
								// For a non-vertical situation (such as section through a sloped floor the surface normal would be needed)
								transform.BasisZ = normal.CrossProduct(XYZ.BasisZ);

								BoundingBoxXYZ sectionBox = new BoundingBoxXYZ();
								sectionBox.Transform = transform;
								sectionBox.Min = new XYZ(-(width / 2), 0, 0);
								sectionBox.Max = new XYZ(width / 2, height, 5);
								transaction.Start();
								ViewSection viewSection = ViewSection.CreateSection(doc, viewFamilyType.Id, sectionBox);
								transaction.Commit();
								isValidSelect = true;
							}
							else
							{
								TaskDialog.Show("Error", "It is not door!");
							}

						}
						else
						{
							TaskDialog.Show("Error", "It is not object!");
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
