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
	public class FurnitureCommand : IExternalCommand
	{
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			using (Transaction transaction = new Transaction(commandData.Application.ActiveUIDocument.Document, "FurnitureCommand"))
			{
				try
				{
					transaction.Start();
					ShowFurnitureForm frmFurniture= new ShowFurnitureForm(commandData.Application);
					frmFurniture.ShowDialog();
					transaction.Commit();
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
