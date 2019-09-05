using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Walter.SelectCategory;

namespace Walter
{
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	[Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
	public class SelectCommand : IExternalCommand
	{
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			using (Transaction transaction = new Transaction(commandData.Application.ActiveUIDocument.Document, "WalterSelect"))
			{
				try
				{
					transaction.Start();
					SelectForm frmSelect = new SelectForm(commandData.Application);
					frmSelect.ShowDialog();
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
