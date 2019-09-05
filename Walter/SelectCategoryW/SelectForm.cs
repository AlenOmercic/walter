using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Walter.SelectCategory
{
	public partial class SelectForm : System.Windows.Forms.Form
	{
		private UIApplication _uIApplication { get; set; }
		private IEnumerable<Element> _elements { get; set; }
		public SelectForm()
		{
			InitializeComponent();
		}

		public SelectForm(UIApplication app)
		{
			InitializeComponent();
			_uIApplication = app;
			_elements = (new FilteredElementCollector(_uIApplication.ActiveUIDocument.Document)
				.WhereElementIsNotElementType() as IEnumerable<Element>)
				.Where(el => el.Category != null && el.Category.CategoryType == CategoryType.Model);

		}

		private void SelectForm_Load(object sender, EventArgs e)
		{
			dgvListCategories.DataSource = _elements
				.Select(y => y.Category.Name).Distinct().OrderBy(z => z).ToList().ConvertAll(x => new { Category = x });
		}

		private void dgvListCategories_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
			{
				dgvListCategories.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "To select multiple rows, hold CTRL key";
			}
			
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnAcceptExport_Click(object sender, EventArgs e)
		{
			DataGridViewSelectedRowCollection selectedRows = dgvListCategories.SelectedRows;
			string category;
			List<Element> elementsListByCat;
			List<Element> elementsListByCatIds = new List<Element>();
			List<List<Element>> finalList;
			string path = @"C:\Users\Walter - User\Desktop\Walter.txt";
			if (File.Exists(path))
			{
				File.Delete(path);
			}
			using (StreamWriter sw = File.CreateText(path))
			{
				for (int i = 0; i < selectedRows.Count; i++)
				{
					category = selectedRows[i].Cells["Category"].Value.ToString();
					sw.WriteLine(category);
					elementsListByCat = _elements.Where(x => x.Category.Name == category).ToList();
					finalList = elementsListByCat.GroupBy(x => x.Name).Select(grp => grp.ToList()).ToList();
					foreach (var item in finalList)
					{
						sw.WriteLine("\t" + item[0].Name);
						foreach (var innerItem in item)
						{
							sw.WriteLine("\t\t " + innerItem.Name + " (" + innerItem.Id.ToString() + ')');
							elementsListByCatIds.Add(innerItem);
						}
					}
				}
			}
			this.Close();
			TaskDialog.Show("Message", "Export is finished!", TaskDialogCommonButtons.Ok);
			_uIApplication.ActiveUIDocument.Selection.SetElementIds(elementsListByCatIds.Select(el => el.Id).ToList());
			
		}
	}
}
