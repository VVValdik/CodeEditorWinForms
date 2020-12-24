using System.Windows.Forms;

namespace CodeEditorWinForms
{
	class EditorTabPage : TabPage
	{
		
		public EditorTabPage(string name, ContextMenuStrip contextMenuStrp)
		{
			Text = name;
			CodeEditor codeEditor = new CodeEditor(contextMenuStrp);
			Controls.Add(codeEditor);
		}
	}
}
