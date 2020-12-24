using FastColoredTextBoxNS;

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
