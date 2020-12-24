using FastColoredTextBoxNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeEditorWinForms
{
	class Settings
	{

		public static void Init()
		{
			if (Properties.Settings.Default.FirstStart)
			{
				Properties.Settings.Default.BackgroundColor = FastColoredTextBox.DefaultBackColor;
				Properties.Settings.Default.ForeColor = FastColoredTextBox.DefaultForeColor;
			}
		}
	}
}
