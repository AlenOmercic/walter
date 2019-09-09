using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Walter
{
	public class EditElementProperties
	{
		public string Name { get; set; }
		public string Value { get; set; }
		public bool CanEdit { get; set; }
	}
}
