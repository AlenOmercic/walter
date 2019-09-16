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
		private ElementType _family { get; set; }
		private List<EditElementProperties> _editElementProperties { get; set; }
		private List<EditElementProperties> _editFamilyProperties { get; set; }
		private Document _document { get; set; }
		public ShowElementPropertiesForm()
		{
			InitializeComponent();
		}
		public ShowElementPropertiesForm(Document document, Element element, ElementType family, List<EditElementProperties> editElementProperties, List<EditElementProperties> editFamilyProperties)
		{
			_document = document;
			_element = element;
			_family = family;
			_editElementProperties = editElementProperties;
			_editFamilyProperties = editFamilyProperties;
			InitializeComponent();
		}

		private void ShowElementProperties_Load(object sender, EventArgs e)
		{
			dgvShowProperties.DataSource = _editElementProperties;
			dgvFamilyProp.DataSource = _editFamilyProperties;
		}

		private void dgvShowProperties_Click(object sender, EventArgs e)
		{
			ShowFormDialog(bool.Parse(dgvShowProperties.SelectedRows[0].Cells["CanEdit"].Value.ToString()), PropertyType.ElementProperty, dgvShowProperties);
		}

		private void dgvFamilyProp_Click(object sender, EventArgs e)
		{
			ShowFormDialog(bool.Parse(dgvFamilyProp.SelectedRows[0].Cells["CanEdit"].Value.ToString()), PropertyType.FamilyProperty, dgvFamilyProp);
		}

		private void ShowFormDialog(bool canEdit, PropertyType propertyType, ComponentFactory.Krypton.Toolkit.KryptonDataGridView kryptonDataGridView)
		{
			if (canEdit)
			{
				EditElementProperties editElementProperties = new EditElementProperties();
				editElementProperties.Name = kryptonDataGridView.SelectedRows[0].Cells["Name"].Value.ToString();
				editElementProperties.Value = (kryptonDataGridView.SelectedRows[0].Cells["Value"].Value == null) ? "" : kryptonDataGridView.SelectedRows[0].Cells["Value"].Value.ToString();
				editElementProperties.CanEdit = canEdit;
				EditPropertyForm frmEditProp = new EditPropertyForm(_document, editElementProperties, _element, _family, propertyType);
				frmEditProp.ShowDialog();
				kryptonDataGridView.SelectedRows[0].Cells["Value"].Value = frmEditProp.ReturnValue1;
			}
			else
			{
				TaskDialog.Show("Warning", "You can not edit this property!");
			}
		}
	}
}
