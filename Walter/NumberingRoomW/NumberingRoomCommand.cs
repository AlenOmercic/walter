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
	class NumberingRoomCommand : IExternalCommand
	{
		private int _startingNumber { get; set; }
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			using (Transaction transaction = new Transaction(commandData.Application.ActiveUIDocument.Document, "NumberingRoomCommand"))
			{
				try
				{
					transaction.Start();
					InsertStartingNumber frmInsertStartingNumber = new InsertStartingNumber(commandData.Application);
					frmInsertStartingNumber.ShowDialog();
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
