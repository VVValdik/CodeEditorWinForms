using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using FastColoredTextBoxNS;
using System.Text.RegularExpressions;
using System.Reflection;

namespace CodeEditorWinForms
{
	public partial class Form1 : Form
	{
		string NewTab = "new tab";

		ToolStripMenuItem currentLanguage;

		AutocompleteMenu popupMenu;
		string[] keywords = { "abstract", "as", "base", "bool", "break", "byte", "case", "catch", "char", "checked", "class", "const", "continue", "decimal", "default", "delegate", "do", "double", "else", "enum", "event", "explicit", "extern", "false", "finally", "fixed", "float", "for", "foreach", "goto", "if", "implicit", "in", "int", "interface", "internal", "is", "lock", "long", "namespace", "new", "null", "object", "operator", "out", "override", "params", "private", "protected", "public", "readonly", "ref", "return", "sbyte", "sealed", "short", "sizeof", "stackalloc", "static", "string", "struct", "switch", "this", "throw", "true", "try", "typeof", "uint", "ulong", "unchecked", "unsafe", "ushort", "using", "virtual", "void", "volatile", "while", "add", "alias", "ascending", "descending", "dynamic", "from", "get", "global", "group", "into", "join", "let", "orderby", "partial", "remove", "select", "set", "value", "var", "where", "yield" };
		string[] methods = { "Equals()", "GetHashCode()", "GetType()", "ToString()" };
		string[] snippets = { "if(^)\n{\n;\n}", "if(^)\n{\n;\n}\nelse\n{\n;\n}", "for(^;;)\n{\n;\n}", "while(^)\n{\n;\n}", "do${\n^;\n}while();", "switch(^)\n{\ncase : break;\n}" };
		string[] declarationSnippets = {
			   "public class ^\n{\n}", "private class ^\n{\n}", "internal class ^\n{\n}",
			   "public struct ^\n{\n;\n}", "private struct ^\n{\n;\n}", "internal struct ^\n{\n;\n}",
			   "public void ^()\n{\n;\n}", "private void ^()\n{\n;\n}", "internal void ^()\n{\n;\n}", "protected void ^()\n{\n;\n}",
			   "public ^{ get; set; }", "private ^{ get; set; }", "internal ^{ get; set; }", "protected ^{ get; set; }"
			   };


		string currentPath = "";

		int tabClickIndex = -1;

		Dictionary<string, FastColoredTextBoxNS.Language> languages =
				new Dictionary<string, FastColoredTextBoxNS.Language>
				{
					{"C#", FastColoredTextBoxNS.Language.CSharp},
					{"VB", FastColoredTextBoxNS.Language.VB},
					{"HTML", FastColoredTextBoxNS.Language.HTML},
					{"XML", FastColoredTextBoxNS.Language.XML},
					{"JS", FastColoredTextBoxNS.Language.JS},
					{"PHP", FastColoredTextBoxNS.Language.PHP},
					{"LUA", FastColoredTextBoxNS.Language.Lua},
					{"SQL", FastColoredTextBoxNS.Language.SQL},
				};

		public Form1()
		{
			InitializeComponent();

			Init();

			InitFileExplorer();
		}

		private void BuildAutocompleteMenu()
		{
			List<AutocompleteItem> items = new List<AutocompleteItem>();

			foreach (var item in snippets)
				items.Add(new SnippetAutocompleteItem(item) { ImageIndex = 1 });
			foreach (var item in declarationSnippets)
				items.Add(new DeclarationSnippet(item) { ImageIndex = 0 });
			foreach (var item in methods)
				items.Add(new MethodAutocompleteItem(item) { ImageIndex = 2 });
			foreach (var item in keywords)
				items.Add(new AutocompleteItem(item));

			items.Add(new InsertSpaceSnippet());
			items.Add(new InsertSpaceSnippet(@"^(\w+)([=<>!:]+)(\w+)$"));
			items.Add(new InsertEnterSnippet());

			//set as autocomplete source
			popupMenu.Items.SetAutocompleteItems(items);
		}

		/// <summary>
		/// This item appears when any part of snippet text is typed
		/// </summary>
		class DeclarationSnippet : SnippetAutocompleteItem
		{
			public DeclarationSnippet(string snippet)
				: base(snippet)
			{
			}

			public override CompareResult Compare(string fragmentText)
			{
				var pattern = Regex.Escape(fragmentText);
				if (Regex.IsMatch(Text, "\\b" + pattern, RegexOptions.IgnoreCase))
					return CompareResult.Visible;
				return CompareResult.Hidden;
			}
		}

		/// <summary>
		/// Divides numbers and words: "123AND456" -> "123 AND 456"
		/// Or "i=2" -> "i = 2"
		/// </summary>
		class InsertSpaceSnippet : AutocompleteItem
		{
			string pattern;

			public InsertSpaceSnippet(string pattern) : base("")
			{
				this.pattern = pattern;
			}

			public InsertSpaceSnippet()
				: this(@"^(\d+)([a-zA-Z_]+)(\d*)$")
			{
			}

			public override CompareResult Compare(string fragmentText)
			{
				if (Regex.IsMatch(fragmentText, pattern))
				{
					Text = InsertSpaces(fragmentText);
					if (Text != fragmentText)
						return CompareResult.Visible;
				}
				return CompareResult.Hidden;
			}

			public string InsertSpaces(string fragment)
			{
				var m = Regex.Match(fragment, pattern);
				if (m == null)
					return fragment;
				if (m.Groups[1].Value == "" && m.Groups[3].Value == "")
					return fragment;
				return (m.Groups[1].Value + " " + m.Groups[2].Value + " " + m.Groups[3].Value).Trim();
			}

			public override string ToolTipTitle
			{
				get
				{
					return Text;
				}
			}
		}

		/// <summary>
		/// Inerts line break after '}'
		/// </summary>
		class InsertEnterSnippet : AutocompleteItem
		{
			Place enterPlace = Place.Empty;

			public InsertEnterSnippet()
				: base("[Line break]")
			{
			}

			public override CompareResult Compare(string fragmentText)
			{
				var r = Parent.Fragment.Clone();
				while (r.Start.iChar > 0)
				{
					if (r.CharBeforeStart == '}')
					{
						enterPlace = r.Start;
						return CompareResult.Visible;
					}

					r.GoLeftThroughFolded();
				}

				return CompareResult.Hidden;
			}

			public override string GetTextForReplace()
			{
				//extend range
				Range r = Parent.Fragment;
				Place end = r.End;
				r.Start = enterPlace;
				r.End = r.End;
				//insert line break
				return Environment.NewLine + r.Text;
			}

			public override void OnSelected(AutocompleteMenu popupMenu, SelectedEventArgs e)
			{
				base.OnSelected(popupMenu, e);
				if (Parent.Fragment.tb.AutoIndent)
					Parent.Fragment.tb.DoAutoIndent();
			}

			public override string ToolTipTitle
			{
				get
				{
					return "Insert line break after '}'";
				}
			}
		}


		private void codeEditor_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == (Keys.K | Keys.Space))
			{
				//forced show (MinFragmentLength will be ignored)
				popupMenu.Show(true);
				e.Handled = true;
			}
		}

		private void InitFileExplorer()
		{
			PopulateTreeView(@"C:\Users\Rin\Desktop\AutoCorrect");
		}

		private void PopulateTreeView(string path)
		{
			currentPath = path;
			treeView1.Nodes.Clear();

			DirectoryInfo directoryInfo = new DirectoryInfo(path);
			if (directoryInfo.Exists)
			{
				BuildTree(directoryInfo, treeView1.Nodes);
			}
		}

		private void BuildTree(DirectoryInfo directoryInfo, TreeNodeCollection addInMe)
		{
			TreeNode curNode = addInMe.Add(directoryInfo.Name);

			foreach (FileInfo file in directoryInfo.GetFiles())
			{
				curNode.Nodes.Add(file.FullName, file.Name);
			}
			foreach (DirectoryInfo subdir in directoryInfo.GetDirectories())
			{
				BuildTree(subdir, curNode.Nodes);
			}
		}

		private void Init()
		{
			var editor = AddNewTab(NewTab);
			editor.Focus();

			currentLanguage = cToolStripMenuItem;
			SelectLanguage(currentLanguage);
		}

		FastColoredTextBox AddNewTab(string name)
		{
			TabPage newTab = new TabPage();
			newTab.Text = name;

			FastColoredTextBox editor = new FastColoredTextBox();
			editor.Dock = DockStyle.Fill;
			editor.ContextMenuStrip = contextMenuStrip1;
			editor.KeyDown += codeEditor_KeyDown;

			// autocomplete menu
			popupMenu = new AutocompleteMenu(editor);
			popupMenu.SearchPattern = @"[\w\.:=!<>]";
			popupMenu.AllowTabKey = true;
			BuildAutocompleteMenu();
			
			newTab.Controls.Add(editor);
			tabControl1.Controls.Add(newTab);

			tabControl1.SelectTab(tabControl1.TabCount - 1);

			return editor;
		}

		private void newToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var codeEditor = AddNewTab(NewTab);
			codeEditor.Text = "";
		}

		private void OpenFileDialog()
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();

			openFileDialog.Filter = "Any file|*.*|Text file|*.txt";

			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				StreamReader streamReader = new StreamReader(openFileDialog.FileName);

				var codeEditor = AddNewTab(Path.GetFullPath(openFileDialog.FileName));
				codeEditor.Text = streamReader.ReadToEnd();

				streamReader.Close();

				this.Text = openFileDialog.FileName;
			}
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog();
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				StreamWriter streamWriter = new StreamWriter(this.Text);

				var codeEditor = tabControl1.SelectedTab.Controls[0] as FastColoredTextBox;
				streamWriter.Write(codeEditor.Text);
				streamWriter.Close();
			}
			catch
			{
				OpenFileDialog();
			}
		}

		private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();

			saveFileDialog.Filter = "Any file|*.*Text file|*.txt";

			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);

				var codeEditor = tabControl1.SelectedTab.Controls[0] as FastColoredTextBox;
				streamWriter.Write(codeEditor.Text);

				streamWriter.Close();
			}
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void cutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var codeEditor = tabControl1.SelectedTab.Controls[0] as FastColoredTextBox;
			codeEditor.Cut();
		}

		private void copyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var codeEditor = tabControl1.SelectedTab.Controls[0] as FastColoredTextBox;
			codeEditor.Copy();
		}

		private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var codeEditor = tabControl1.SelectedTab.Controls[0] as FastColoredTextBox;
			codeEditor.Paste();
		}

		private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ColorDialog colorDialog = new ColorDialog();

			if (colorDialog.ShowDialog() == DialogResult.OK)
			{
				var codeEditor = tabControl1.SelectedTab.Controls[0] as FastColoredTextBox;
				codeEditor.BackColor = colorDialog.Color;
			}
		}

		private void textColorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ColorDialog colorDialog = new ColorDialog();

			if (colorDialog.ShowDialog() == DialogResult.OK)
			{
				var codeEditor = tabControl1.SelectedTab.Controls[0] as FastColoredTextBox;
				codeEditor.ForeColor = colorDialog.Color;
			}
		}

		private void undoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var codeEditor = tabControl1.SelectedTab.Controls[0] as FastColoredTextBox;
			codeEditor.Undo();
		}

		private void redoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var codeEditor = tabControl1.SelectedTab.Controls[0] as FastColoredTextBox;
			codeEditor.Redo();
		}

		private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var codeEditor = tabControl1.SelectedTab.Controls[0] as FastColoredTextBox;
			codeEditor.SelectAll();
		}

		private void cutToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			var codeEditor = tabControl1.SelectedTab.Controls[0] as FastColoredTextBox;
			codeEditor.Cut();
		}

		private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			var codeEditor = tabControl1.SelectedTab.Controls[0] as FastColoredTextBox;
			codeEditor.Copy();
		}

		private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			var codeEditor = tabControl1.SelectedTab.Controls[0] as FastColoredTextBox;
			codeEditor.Paste();
		}

		private void findToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var codeEditor = tabControl1.SelectedTab.Controls[0] as FastColoredTextBox;
			codeEditor.ShowFindDialog();
		}

		private void goToToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var codeEditor = tabControl1.SelectedTab.Controls[0] as FastColoredTextBox;
			codeEditor.ShowGoToDialog();
		}

		private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var codeEditor = tabControl1.SelectedTab.Controls[0] as FastColoredTextBox;
			codeEditor.ShowReplaceDialog();
		}

		private void SelectLanguage(object sender)
		{
			currentLanguage.Checked = false;
			currentLanguage = ((ToolStripMenuItem)sender);
			currentLanguage.Checked = true;

			SetLanguage(currentLanguage.Text);

			var codeEditor = tabControl1.SelectedTab.Controls[0] as FastColoredTextBox;
			codeEditor.Refresh();
		}

		private void cToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SelectLanguage(sender);
		}

		private void vBToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SelectLanguage(sender);
		}

		private void hTMLToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SelectLanguage(sender);
		}

		private void pHPToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SelectLanguage(sender);
		}

		private void jSToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SelectLanguage(sender);
		}

		private void sQLToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SelectLanguage(sender);
		}

		private void lUAToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SelectLanguage(sender);
		}

		private void xMLToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SelectLanguage(sender);
		}

		private void runHTMLToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var codeEditor = tabControl1.SelectedTab.Controls[0] as FastColoredTextBox;
			if (codeEditor.Language == FastColoredTextBoxNS.Language.HTML)
			{
				HTMLPreview preview = new HTMLPreview(codeEditor.Text);
				preview.Show();
			}
			else
			{
				MessageBox.Show("Language or extension error!");
			}
		}

		private void runCShaprCodeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog sf = new SaveFileDialog();
			sf.Filter = "Executable File|*.exe";
			string OutPath = "?.exe";
			if (sf.ShowDialog() == DialogResult.OK)
			{
				OutPath = sf.FileName;
			}
			//compile code:
			//create c# code compiler
			CSharpCodeProvider codeProvider = new CSharpCodeProvider();
			//create new parameters for compilation and add references(libs) to compiled app
			CompilerParameters parameters = new CompilerParameters(new string[] { "System.dll" });
			//is compiled code will be executable?(.exe)
			parameters.GenerateExecutable = true;
			//output path
			parameters.OutputAssembly = OutPath;
			//code sources to compile
			var codeEditor = tabControl1.SelectedTab.Controls[0] as FastColoredTextBox;
			string[] sources = { codeEditor.Text };
			//results of compilation
			CompilerResults results = codeProvider.CompileAssemblyFromSource(parameters, sources);

			//if has errors
			if (results.Errors.Count > 0)
			{
				string errsText = "";
				foreach (CompilerError CompErr in results.Errors)
				{
					errsText = "(" + CompErr.ErrorNumber +
								")Line " + CompErr.Line +
								",Column " + CompErr.Column +
								":" + CompErr.ErrorText + "" +
								Environment.NewLine;
				}
				//show error message
				MessageBox.Show(errsText, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				//run compiled app
				System.Diagnostics.Process.Start(OutPath);
			}

		}

		void SetLanguage(string language)
		{
			if (languages.ContainsKey(language))
			{
				var codeEditor = tabControl1.SelectedTab.Controls[0] as FastColoredTextBox;
				codeEditor.Language = languages[language];

			}
			else
			{
				var codeEditor = tabControl1.SelectedTab.Controls[0] as FastColoredTextBox;
				codeEditor.Language = FastColoredTextBoxNS.Language.CSharp;
			}

			currentLanguage.Checked = false;
			switch (language)
			{
				case "VB":
					{
						currentLanguage = vBToolStripMenuItem;
					}
					break;
				case "XML":
					{
						currentLanguage = xMLToolStripMenuItem;
					}
					break;
				case "HTML":
					{
						currentLanguage = hTMLToolStripMenuItem;
					}
					break;
				case "LUA":
					{
						currentLanguage = lUAToolStripMenuItem;
					}
					break;
				case "PHP":
					{
						currentLanguage = pHPToolStripMenuItem;
					}
					break;
				case "SQL":
					{
						currentLanguage = sQLToolStripMenuItem;
					}
					break;
				case "JS":
					{
						currentLanguage = jSToolStripMenuItem;
					}
					break;
				default:
					{
						currentLanguage = cToolStripMenuItem;
					}
					break;
			}

			currentLanguage.Checked = true;
		}

		void OpenFile(string fullPath)
		{
			StreamReader streamReader = new StreamReader(fullPath);

			string language = fullPath.Split('.')[1].ToUpper();
			SetLanguage(language);

			AddNewTab(Path.GetFileName(fullPath));
			var codeEditor = tabControl1.SelectedTab.Controls[0] as FastColoredTextBox;
			codeEditor.Text = streamReader.ReadToEnd();



			streamReader.Close();
		}

		void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			TreeView treeView = (TreeView)sender;
			if (treeView.SelectedNode.GetNodeCount(true) == 0)
			{
				string path = treeView.SelectedNode.FullPath;
				string fullPath = currentPath.Remove(currentPath.LastIndexOf("\\")) + "\\" + path;
				OpenFile(fullPath);
			}
		}

		private void openProjectFolderToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

			if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
			{
				PopulateTreeView(folderBrowserDialog.SelectedPath);
			}
		}

		private void tabControl1_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{

				for (int i = 0; i < tabControl1.TabCount; i++)
				{
					// get their rectangle area and check if it contains the mouse cursor
					Rectangle r = tabControl1.GetTabRect(i);
					if (r.Contains(e.Location))
					{
						// show the context menu here
						this.contextMenuStrip2.Show(this.tabControl1, e.Location);
						tabClickIndex = i;
					}
				}
			}
		}

		private void newToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			AddNewTab(NewTab);
		}

		private void closeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			tabControl1.TabPages.RemoveAt(tabClickIndex);
		}

		private void themeEditorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ThemeEditor themeEditor = new ThemeEditor();
			themeEditor.ShowDialog();
		}

		private void FirstStartInit()
		{
			if(Properties.Settings.Default.FirstStart)
			{
				Properties.Settings.Default.BackgroundColor = DefaultBackColor;
				Properties.Settings.Default.TextColor = DefaultForeColor;
			}
		}
	}
}
