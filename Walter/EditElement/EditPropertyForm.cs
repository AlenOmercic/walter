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
		private ElementType _family { get; set; }
		private EditElementProperties _editElementProperties { get; set; }
		private PropertyType _propertyType { get; set; }
		private Document _document { get; set; }
		public EditPropertyForm()
		{
			InitializeComponent();
		}
		public EditPropertyForm(Document document, EditElementProperties editElementProperties, Element element, ElementType family,PropertyType propertyType)
		{
			_element = element;
			_family = family;
			_propertyType = propertyType;
			_editElementProperties = editElementProperties;
			_document = document;
			InitializeComponent();
		}

		private void EditPropertyForm_Load(object sender, EventArgs e)
		{
			txtValue.Text = _editElementProperties.Value;
			lblProperty.Text = _editElementProperties.Name;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			_editElementProperties.Value = txtValue.Text;
			switch (_propertyType)
			{
				case PropertyType.ElementProperty:
					List<Element> elementsInDoc = new FilteredElementCollector(_document).OfCategoryId(_element.Category.Id).ToElements().ToList();
					foreach (var el in elementsInDoc)
					{
						if (el.Name == _element.Name)
						{
							foreach (Parameter item in el.Parameters)
							{
								if (item.Definition.Name == _editElementProperties.Name)
								{
									item.Set(txtValue.Text);
								}
							}
						}
					}
					break;
				case PropertyType.FamilyProperty:
					foreach (Parameter item in _family.Parameters)
					{
						if (item.Definition.Name == _editElementProperties.Name)
						{
							item.Set(txtValue.Text);
						}
					}
					break;
				default:
					throw new Exception();
			}
			this.ReturnValue1 = _editElementProperties.Value;
			this.Close();
		}
	}
}
