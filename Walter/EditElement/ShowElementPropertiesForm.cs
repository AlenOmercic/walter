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
	public partial class ShowElementPropertiesForm : System.Windows.Forms.Form
	{
		private Element _element { get; set; }
		private List<EditElementProperties> _editElementProperties { get; set; }
		public ShowElementPropertiesForm()
		{
			InitializeComponent();
		}
		public ShowElementPropertiesForm(Element element, List<EditElementProperties> editElementProperties)
		{
			_element = element;
			_editElementProperties = editElementProperties;
			InitializeComponent();
		}

		private void ShowElementProperties_Load(object sender, EventArgs e)
		{
			dgvShowProperties.DataSource = _editElementProperties;
		}

		private void dgvShowProperties_Click(object sender, EventArgs e)
		{
			bool canEdit = bool.Parse(dgvShowProperties.SelectedRows[0].Cells["CanEdit"].Value.ToString());
			if (canEdit)
			{
				EditElementProperties editElementProperties = new EditElementProperties();
				editElementProperties.Name = dgvShowProperties.SelectedRows[0].Cells["Name"].Value.ToString();
				editElementProperties.Value = (dgvShowProperties.SelectedRows[0].Cells["Value"].Value == null) ? "" : dgvShowProperties.SelectedRows[0].Cells["Value"].Value.ToString();
				editElementProperties.CanEdit = canEdit;
				EditPropertyForm frmEditProp = new EditPropertyForm(editElementProperties, _element);
				frmEditProp.ShowDialog();
				dgvShowProperties.SelectedRows[0].Cells["Value"].Value = frmEditProp.ReturnValue1;
			}
			else
			{
				TaskDialog.Show("Warning", "You can not edit this property!");
			}
			
		}
	}
}
