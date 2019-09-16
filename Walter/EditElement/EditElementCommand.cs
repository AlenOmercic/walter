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
	public enum PropertyType
	{
		ElementProperty,
		FamilyProperty
	}
	[Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class EditElementCommand : IExternalCommand
	{
		private EditElementProperties GetEditElementProperties(ExternalCommandData commandData, Parameter parameter)
		{
			EditElementProperties editElementProperties = new EditElementProperties();
			editElementProperties.Name = parameter.Definition.Name;
			switch (parameter.StorageType)
			{
				case StorageType.None:
					editElementProperties.Value = parameter.AsValueString();
					editElementProperties.CanEdit = false;
					break;
				case StorageType.Integer:
					editElementProperties.Value = parameter.AsInteger().ToString();
					editElementProperties.CanEdit = false;
					break;
				case StorageType.Double:
					editElementProperties.Value = parameter.AsDouble().ToString();
					editElementProperties.CanEdit = false;
					break;
				case StorageType.String:
					editElementProperties.Value = parameter.AsString();
					editElementProperties.CanEdit = true;
					break;
				case StorageType.ElementId:
					ElementId elementId = new ElementId(parameter.AsElementId().IntegerValue);
					Element elem = commandData.Application.ActiveUIDocument.Document.GetElement(elementId);
					editElementProperties.Value = (elem != null) ? elem.Name : "Not Set";

					break;
				default:
					break;
			}
			return editElementProperties;
		}
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			using (Transaction transaction = new Transaction(commandData.Application.ActiveUIDocument.Document,"EditElementCommand"))
			{
				
				try
				{
					transaction.Start();
					ICollection<ElementId> elementIds = commandData.Application.ActiveUIDocument.Selection.GetElementIds();
					Element element = commandData.Application.ActiveUIDocument.Document.GetElement(elementIds.First());
					IList<Parameter> elementTypeParam = (commandData.Application.ActiveUIDocument.Document.GetElement(element.GetTypeId()) as ElementType).GetOrderedParameters();
					IList<Parameter> parameters = element.GetOrderedParameters();
					List<EditElementProperties> editElements = new List<EditElementProperties>();
					List<EditElementProperties> familyEditElements = new List<EditElementProperties>();
					foreach (var item in parameters)
					{
						if (item == null) continue;

						editElements.Add(GetEditElementProperties(commandData, item));
					}
					foreach (var item in elementTypeParam)
					{
						if (item == null) continue;
						familyEditElements.Add(GetEditElementProperties(commandData, item));
					}
					ShowElementPropertiesForm frmShowProperties = new ShowElementPropertiesForm(commandData.Application.ActiveUIDocument.Document, element, commandData.Application.ActiveUIDocument.Document.GetElement(element.GetTypeId()) as ElementType, editElements, familyEditElements);
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
