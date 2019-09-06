using Autodesk.Revit.UI;
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
			_path = Uri.UnescapeDataString((new UriBuilder(Assembly.GetExecutingAssembly().CodeBase)).Path);
			_resorce = _path.Substring(0, _path.LastIndexOf("/d") + 1) + @"resorce/";
			string tabName = "Walter";
			application.CreateRibbonTab(tabName);
			RibbonPanel ribbonPanel = application.CreateRibbonPanel(tabName, "Tools");
			InitRibbonButtons(ribbonPanel);

			return Result.Succeeded;
		}
		private void InitRibbonButtons(RibbonPanel ribbonPanel)
		{
			CreatePushButton(ribbonPanel, "Select Category", "Select\nCategory", @_path, "Walter.SelectCommand", "Korisnik ima mogućnost da izabere više prikazanih kategorija, te prilikom klika na dugme „Accept & Export“ , program će izvršiti pribavljanje svih odabranih kategorija (instanci) iz Revitovog modela i ispisati u txt fajl na Desktopu.", true, _resorce + @"select.png");
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
