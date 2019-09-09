using Autodesk.Revit.DB;
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
	public partial class EditPropertyForm : System.Windows.Forms.Form
	{
		public string ReturnValue1 { get; set; }
		private Element _element { get; set; }
		private EditElementProperties _editElementProperties { get; set; }
		public EditPropertyForm()
		{
			InitializeComponent();
		}
		public EditPropertyForm(EditElementProperties editElementProperties, Element element)
		{
			_element = element;
			_editElementProperties = editElementProperties;
			InitializeComponent();
		}

		private void EditPropertyForm_Load(object sender, EventArgs e)
		{
			txtValue.Text = _editElementProperties.Value;
			lblProperty.Text = _editElementProperties.Name;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			foreach (Parameter item in _element.Parameters)
			{
				if (item.Definition.Name == _editElementProperties.Name)
				{
					item.Set(txtValue.Text);
					_editElementProperties.Value = txtValue.Text;
				}
			}
			this.ReturnValue1 = _editElementProperties.Value;
			this.Close();
		}
	}
}
