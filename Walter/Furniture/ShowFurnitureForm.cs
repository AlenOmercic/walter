using Autodesk.Revit.DB;
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
	public partial class ShowFurnitureForm : System.Windows.Forms.Form
	{
		private UIApplication _uIApplication { get; set; }
		public ShowFurnitureForm()
		{
			InitializeComponent();
		}
		public ShowFurnitureForm(UIApplication uIApplication)
		{
			InitializeComponent();
			_uIApplication = uIApplication;
		}

		private void ShowFurnitureForm_Load(object sender, EventArgs e)
		{
			List<Element> rooms = (new FilteredElementCollector(_uIApplication.ActiveUIDocument.Document, _uIApplication.ActiveUIDocument.ActiveView.Id).OfCategory(BuiltInCategory.OST_Furniture).WhereElementIsNotElementType() as IEnumerable<Element>).Cast<Element>().ToList();
		}
	}
}
