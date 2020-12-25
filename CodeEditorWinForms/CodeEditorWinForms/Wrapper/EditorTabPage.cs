using System.Windows.Forms;

namespace CodeEditorWinForms
{
	class EditorTabPage : TabPage
	{
		
		public EditorTabPage(string name, ContextMenuStrip tabMenuStrip, ContextMenuStrip editorStrip)
		{
			Text = name;
			ContextMenuStrip = tabMenuStrip;
			CodeEditor codeEditor = new CodeEditor(editorStrip);
			Controls.Add(codeEditor);
		}
	}
}
