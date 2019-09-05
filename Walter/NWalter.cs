using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Walter
{
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	[Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
	public class NWalter : IExternalApplication
	{
		public Result OnShutdown(UIControlledApplication application)
		{
			return Result.Succeeded;
		}

		public Result OnStartup(UIControlledApplication application)
		{
			string tabName = "Walter";
			application.CreateRibbonTab(tabName);
			RibbonPanel ribbonPanel = application.CreateRibbonPanel(tabName, "Tools");
			PushButton pushButton = CreatePushButton(ribbonPanel, "Select Category", "Select\nCategory", @"C:\Users\Walter - User\source\repos\Walter\Walter\bin\Debug\Walter.dll", "Walter.WCommand", "Korisnik ima mogućnost da izabere više prikazanih kategorija, te prilikom klika na dugme „Accept & Export“ , program će izvršiti pribavljanje svih odabranih kategorija (instanci) iz Revitovog modela i ispisati u txt fajl na Desktopu.", true, @"C:\Users\Walter - User\source\repos\Walter\Walter\resorce\select.png");
			ribbonPanel.AddSeparator();
			return Result.Succeeded;
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
