using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Walter
{
	[Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class EditElementCommand : IExternalCommand
	{
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			using (Transaction transaction = new Transaction(commandData.Application.ActiveUIDocument.Document,"EditElementCommand"))
			{
				
				try
				{
					transaction.Start();
					ICollection<ElementId> elementIds = commandData.Application.ActiveUIDocument.Selection.GetElementIds();
					Element element = commandData.Application.ActiveUIDocument.Document.GetElement(elementIds.First());
					IList<Parameter> parameters = element.GetOrderedParameters();
					List<EditElementProperties> editElements = new List<EditElementProperties>();
					EditElementProperties editElementProperties = null;
					foreach (var item in parameters)
					{
						if (item == null) continue;
						editElementProperties = new EditElementProperties();
						editElementProperties.Name = item.Definition.Name;
						switch (item.StorageType)
						{
							case StorageType.None:
								editElementProperties.Value = item.AsValueString();
								editElementProperties.CanEdit = false;
								break;
							case StorageType.Integer:
								editElementProperties.Value = item.AsInteger().ToString();
								editElementProperties.CanEdit = false;
								break;
							case StorageType.Double:
								editElementProperties.Value = item.AsDouble().ToString();
								editElementProperties.CanEdit = false;
								break;
							case StorageType.String:
								editElementProperties.Value = item.AsString();
								editElementProperties.CanEdit = true;
								break;
							case StorageType.ElementId:
								ElementId elementId = new ElementId(item.AsElementId().IntegerValue);
								Element elem = commandData.Application.ActiveUIDocument.Document.GetElement(elementId);
								editElementProperties.Value = (elem != null) ? elem.Name : "Not Set";
								
								break;
							default:
								break;
						}
						editElements.Add(editElementProperties);
					}
					ShowElementPropertiesForm frmShowProperties = new ShowElementPropertiesForm(element, editElements);
					frmShowProperties.ShowDialog();
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
