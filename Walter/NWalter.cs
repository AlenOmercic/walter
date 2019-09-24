using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Walter
{
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	[Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
	public class NWalter : IExternalApplication
	{
		private string _path { get; set; }
		private string _resorce { get; set; }
		public Result OnShutdown(UIControlledApplication application)
		{
			return Result.Succeeded;
		}
		public Result OnStartup(UIControlledApplication application)
		{
			application.Idling += new EventHandler<IdlingEventArgs>(ShowCommand);
			_path = Uri.UnescapeDataString((new UriBuilder(Assembly.GetExecutingAssembly().CodeBase)).Path);
			_resorce = _path.Substring(0, _path.LastIndexOf("/d") + 1) + @"resorce/";
			string tabName = "Walter";
			application.CreateRibbonTab(tabName);
			RibbonPanel ribbonPanel = application.CreateRibbonPanel(tabName, "Tools");
			InitRibbonButtons(ribbonPanel);
			var s = ribbonPanel.GetItems();
			return Result.Succeeded;
		}
		void ShowCommand(object s, IdlingEventArgs e)
		{
			UIApplication app = s as UIApplication;
			ICollection<ElementId> elementIds = app.ActiveUIDocument.Selection.GetElementIds();
			List<PushButton> buttons = app.GetRibbonPanels("Walter")[0].GetItems().Where(w => w.Name == "Edit Element").Cast<PushButton>().ToList();
			if (elementIds.Count == 1)
			{
				buttons[0].Enabled = true;
			}
			else
			{
				buttons[0].Enabled = false;
			}
		}
		private void InitRibbonButtons(RibbonPanel ribbonPanel)
		{
			CreatePushButton(ribbonPanel, "Select Category", "Select\nCategory", _path, "Walter.SelectCommand", "Korisnik ima mogućnost da izabere više prikazanih kategorija, te prilikom klika na dugme „Accept & Export“ , program će izvršiti pribavljanje svih odabranih kategorija (instanci) iz Revitovog modela i ispisati u txt fajl na Desktopu.", true, _resorce + @"select.png");
			ribbonPanel.AddSeparator();
			SplitButton splitButton =  ribbonPanel.AddItem(new SplitButtonData("Auto Room Num", "Auto\nNumbering")) as SplitButton;
			splitButton.ToolTip = "Alat kojim se automatizuje dodjela broja sobe. Korisniku omogućiti da unese od kog broja kreću brojevi soba.";
			splitButton.LargeImage = new BitmapImage(new Uri(_resorce + @"numbering.png"));
			PushButton pushButtonInput =  splitButton.AddPushButton(new PushButtonData("Auto Room Num", "Auto\nNumbering", _path , "Walter.NumberingRoomCommand"));
			pushButtonInput.LargeImage = new BitmapImage(new Uri(_resorce + @"numbering.png"));
			pushButtonInput.ToolTip = "Alat kojim se automatizuje dodjela broja sobe. Korisniku omogućuje da unese od kog broja kreću brojevi soba.";
			pushButtonInput.SetContextualHelp(new ContextualHelp(ContextualHelpType.Url, "https://www.naviate.com/"));
			PushButton pushButtonAuto = splitButton.AddPushButton(new PushButtonData("Auto Room Num with start", "Auto Numbering\nFrom 100", _path, "Walter.AutoNumberingRoomCommand"));
			pushButtonAuto.LargeImage = new BitmapImage(new Uri(_resorce + @"autoNumbering.png"));
			pushButtonAuto.ToolTip = "Alat kojim se automatizuje dodjela broja sobe koje postoje u modelu pocevsi od 100.";
			pushButtonAuto.SetContextualHelp(new ContextualHelp(ContextualHelpType.Url, "https://www.naviate.com/"));
			ribbonPanel.AddSeparator();
			CreatePushButton(ribbonPanel, "Show Furniture", "Show\nFurniture", _path, "Walter.FurnitureCommand", "Alat kojim se prikazuje namještaj na spratu.", true, _resorce + @"furniture.png");
			ribbonPanel.AddSeparator();
			PushButton edit = CreatePushButton(ribbonPanel, "Edit Element", "Edit\nElement", _path, "Walter.EditElementCommand", "Alat omogućuje korisniku da za selektovani element budu prikazani svi parametri izabranog elementa. Korisnik ima mogućnost da unese novu vrijednost parametra i klikom na dugme „Ok“ svi elementi tog tipa koji se nalaze unutar projekta dobiće novu unesenu vrijednost", true, _resorce + @"edit.png");
			edit.Enabled = false;
			ribbonPanel.AddSeparator();
			CreatePushButton(ribbonPanel, "Insert Section", "Insert\nSection", _path, "Walter.InsertSectionCommand", "Alat omogucuje korisniku za selektovani element da se kreira section", true, _resorce + @"section.png");
			ribbonPanel.AddSeparator();
		}

		private PushButton CreatePushButton(RibbonPanel ribbonPanel, string name, string text, string assemblyName, string className, string toolTip, bool isLarge, string imageUrl = null)
		{
			PushButton pushButton = ribbonPanel.AddItem(new PushButtonData(name, text, assemblyName, className)) as PushButton;
			pushButton.ToolTip = toolTip;
			pushButton.SetContextualHelp(new ContextualHelp(ContextualHelpType.Url, "https://www.naviate.com/"));

			if (!string.IsNullOrEmpty(imageUrl))
			{
				if (isLarge)
				{
					pushButton.LargeImage = new BitmapImage(new Uri(imageUrl));
				}
				else
				{
					pushButton.Image = new BitmapImage(new Uri(imageUrl));
				}
			}
			return pushButton;
		}
	}
}
