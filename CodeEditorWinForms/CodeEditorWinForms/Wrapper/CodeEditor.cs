using FastColoredTextBoxNS;
using System.Windows.Forms;

namespace CodeEditorWinForms
{
	class CodeEditor : FastColoredTextBox
	{
		private AutocompleteMenu popupMenu;

		public CodeEditor(ContextMenuStrip contextMenuStrip)
		{
			Dock = DockStyle.Fill;
			ContextMenuStrip = contextMenuStrip;
			KeyDown += CodeEditor_KeyDown;

			SetAutoCompleteMenu();
			SetEditorStyle();
		}

		private void CodeEditor_KeyDown(object sender, KeyEventArgs e)
		{
			// when user press Ctrl + Space
			if (e.KeyData == (Keys.Control | Keys.Space))
			{
				ShowPopupMenu();
				e.Handled = true;
			}
		}

		public void ShowPopupMenu()
		{
			popupMenu.Show(true);
		}

		private void SetAutoCompleteMenu()
		{
			popupMenu = new AutocompleteMenu(this);

			popupMenu.SearchPattern = @"[\w\.:=!<>]";
			popupMenu.AllowTabKey = true;

			Autocomplete autocomplete = new Autocomplete();
			autocomplete.BuildAutocompleteMenu(popupMenu);
		}

		public void SetEditorStyle()
		{
			BackColor = Properties.Settings.Default.BackgroundColor;
			ForeColor = Properties.Settings.Default.ForeColor;
		}
	}
}
