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
	class AutoNumberingRoomCommand : IExternalCommand
	{
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			using (Transaction transaction = new Transaction(commandData.Application.ActiveUIDocument.Document, "AutoNumberingRoomCommand"))
			{
				try
				{
					transaction.Start();
					decimal startingNumber = 100;
					List<Element> rooms = (new FilteredElementCollector(commandData.Application.ActiveUIDocument.Document).OfCategory(BuiltInCategory.OST_Rooms).WhereElementIsNotElementType() as IEnumerable<Element>).Cast<Element>().ToList();
					rooms.Sort((x, y) => x.LevelId.Compare(y.LevelId));

					List<List<Element>> roomsGroupByLvl = rooms.GroupBy(r => r.LevelId).Select(gr => gr.ToList()).ToList();
					Room room;

					foreach (var item in roomsGroupByLvl)
					{
						foreach (var r in item)
						{
							room = commandData.Application.ActiveUIDocument.Document.GetElement(r.Id) as Room;
							room.Number = startingNumber.ToString();
							startingNumber++;
						}
					}
					transaction.Commit();
					TaskDialog.Show("Message", "Done!", TaskDialogCommonButtons.Ok);
				}
				catch (Exception)
				{

					return Result.Failed;
				}
			}
			return Result.Succeeded;
		}
	}
}
