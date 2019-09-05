using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Walter
{
	public partial class InsertStartingNumber : System.Windows.Forms.Form
	{
		private UIApplication _uIApplication { get; set; }
		public InsertStartingNumber()
		{
			InitializeComponent();
		}
		public InsertStartingNumber(UIApplication uIApplication)
		{
			InitializeComponent();
			_uIApplication = uIApplication;
		}

		private void btnAccept_Click(object sender, EventArgs e)
		{
			decimal startingNumber = txtStartingNumber.Value;
			List<Element> rooms = (new FilteredElementCollector(_uIApplication.ActiveUIDocument.Document).OfCategory(BuiltInCategory.OST_Rooms).WhereElementIsNotElementType() as IEnumerable<Element>).Cast<Element>().ToList();
			rooms.Sort((x, y) => x.LevelId.Compare(y.LevelId));

			List<List<Element>> roomsGroupByLvl = rooms.GroupBy(r => r.LevelId).Select(gr => gr.ToList()).ToList();
			Room room;

			foreach (var item in roomsGroupByLvl)
			{
				foreach (var r in item)
				{
					room = _uIApplication.ActiveUIDocument.Document.GetElement(r.Id) as Room;
					room.Number = startingNumber.ToString();
					startingNumber++;
				}
			}
			this.Close();
			TaskDialog.Show("Message", "Done!", TaskDialogCommonButtons.Ok);
		}
	}
}
