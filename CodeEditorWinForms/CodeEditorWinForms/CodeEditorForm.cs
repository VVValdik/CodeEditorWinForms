using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using FastColoredTextBoxNS;

namespace CodeEditorWinForms
{
	public partial class CodeEditorForm : Form
	{
		private string NewTab = "new tab";
		private string FileDialogFilterAny = "Any file|*.*";
		
		private int tabClickIndex = -1;

		private ToolStripMenuItem currentLanguage;
		private FileExplorer fileExplorer;

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

		public CodeEditorForm()
		{
			InitializeComponent();

			SettingsInit();
			InitCodeEditor();
			InitFileExplorer();
		}

		private void InitFileExplorer()
		{
			fileExplorer = new FileExplorer(treeView);
		}

		private void InitCodeEditor()
		{
			var editor = AddNewTab(NewTab);

			editor.Focus();

			currentLanguage = cToolStripMenuItem;
			SelectLanguage(currentLanguage);
		}
		
		CodeEditor AddNewTab(string name)
		{
			TabPage newTab = new TabPage();
			newTab.Text = name;

			CodeEditor editor = new CodeEditor(contextMenuStrip1);
			
			newTab.Controls.Add(editor);
			tabControl.Controls.Add(newTab);

			tabControl.SelectTab(tabControl.TabCount - 1);

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

			openFileDialog.Filter = FileDialogFilterAny;

			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				StreamReader streamReader = new StreamReader(openFileDialog.FileName);

				var codeEditor = AddNewTab(Path.GetFileName(openFileDialog.FileName));
				codeEditor.Text = streamReader.ReadToEnd();

				streamReader.Close();
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

				var codeEditor = tabControl.SelectedTab.Controls[0] as FastColoredTextBox;
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

			saveFileDialog.Filter = FileDialogFilterAny;

			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);

				var codeEditor = tabControl.SelectedTab.Controls[0] as FastColoredTextBox;
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
			if(!HasTabs())
			{
				return;
			}

			var codeEditor = GetCurrentCodeEditor();
			codeEditor.Cut();
		}

		private void copyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!HasTabs())
			{
				return;
			}

			var codeEditor = GetCurrentCodeEditor();

			codeEditor.Copy();
		}

		private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!HasTabs())
			{
				return;
			}

			var codeEditor = GetCurrentCodeEditor();

			codeEditor.Paste();
		}

		private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ColorDialog colorDialog = new ColorDialog();

			if (colorDialog.ShowDialog() == DialogResult.OK)
			{
				var codeEditor = tabControl.SelectedTab.Controls[0] as FastColoredTextBox;
				codeEditor.BackColor = colorDialog.Color;
			}
		}

		private CodeEditor GetCurrentCodeEditor()
		{
			var codeEditor = tabControl.SelectedTab.Controls[0] as CodeEditor;
			return codeEditor;
		}

		private void textColorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ColorDialog colorDialog = new ColorDialog();

			if (colorDialog.ShowDialog() == DialogResult.OK)
			{
				var codeEditor = tabControl.SelectedTab.Controls[0] as FastColoredTextBox;
				codeEditor.ForeColor = colorDialog.Color;
			}
		}

		private void undoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!HasTabs())
			{
				return;
			}

			var codeEditor = GetCurrentCodeEditor();

			codeEditor.Undo();
		}

		private void redoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!HasTabs())
			{
				return;
			}

			var codeEditor = GetCurrentCodeEditor();

			codeEditor.Redo();
		}

		private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!HasTabs())
			{
				return;
			}

			var codeEditor = GetCurrentCodeEditor();

			codeEditor.SelectAll();
		}

		private void cutToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			if (!HasTabs())
			{
				return;
			}

			var codeEditor = GetCurrentCodeEditor();

			codeEditor.Cut();
		}

		private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			if (!HasTabs())
			{
				return;
			}

			var codeEditor = GetCurrentCodeEditor();

			codeEditor.Copy();
		}

		private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			if (!HasTabs())
			{
				return;
			}

			var codeEditor = GetCurrentCodeEditor();

			codeEditor.Paste();
		}

		private void findToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!HasTabs())
			{
				return;
			}

			var codeEditor = GetCurrentCodeEditor();

			codeEditor.ShowFindDialog();
		}

		private void goToToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!HasTabs())
			{
				return;
			}

			var codeEditor = GetCurrentCodeEditor();

			codeEditor.ShowGoToDialog();
		}

		private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!HasTabs())
			{
				return;
			}

			var codeEditor = GetCurrentCodeEditor();

			codeEditor.ShowReplaceDialog();
		}

		private void SelectLanguage(object sender)
		{
			currentLanguage.Checked = false;
			currentLanguage = ((ToolStripMenuItem)sender);
			currentLanguage.Checked = true;

			SetLanguage(currentLanguage.Text);

			var codeEditor = tabControl.SelectedTab.Controls[0] as FastColoredTextBox;
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

		private bool HasTabs()
		{
			if(tabControl.TabPages.Count > 0)
			{
				return true;
			}

			return false;
		}

		private void runHTMLToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if(!HasTabs())
			{
				return;
			}

			var codeEditor = tabControl.SelectedTab.Controls[0] as CodeEditor;
			if (codeEditor.Language == FastColoredTextBoxNS.Language.HTML)
			{
				HTMLPreview preview = new HTMLPreview(codeEditor.Text);
				preview.Show();
			}
			else
			{
				MessageBox.Show("Wrong language!");
			}
		}

		private void RunCShaprCodeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if(!HasTabs())
			{
				return;
			}

			var codeEditor = GetCurrentCodeEditor();
			CSharpCompiler.Compile(codeEditor.Text);
		}

		void SetLanguage(string language)
		{
			if (languages.ContainsKey(language))
			{
				if (!HasTabs())
				{
					return;
				}

				var codeEditor = GetCurrentCodeEditor();

				codeEditor.Language = languages[language];
			}
			else
			{
				if (!HasTabs())
				{
					return;
				}

				var codeEditor = GetCurrentCodeEditor();

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

			if (!HasTabs())
			{
				return;
			}

			var codeEditor = GetCurrentCodeEditor();

			codeEditor.Text = streamReader.ReadToEnd();
			
			streamReader.Close();
		}

		void TreeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			TreeView treeView = (TreeView)sender;
			if (treeView.SelectedNode.GetNodeCount(true) == 0)
			{
				string currentPath = fileExplorer.GetCurrentPath();
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
				fileExplorer.PopulateTreeView(folderBrowserDialog.SelectedPath);
			}
		}

		private void TabControl1_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				for (int i = 0; i < tabControl.TabCount; i++)
				{
					// get their rectangle area and check if it contains the mouse cursor
					Rectangle r = tabControl.GetTabRect(i);
					if (r.Contains(e.Location))
					{
						// show the context menu here
						this.contextMenuStrip2.Show(this.tabControl, e.Location);
						tabClickIndex = i;
					}
				}
			}
		}

		private void NewToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			AddNewTab(NewTab);
		}

		private void ThemeEditorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ThemeEditor themeEditor = new ThemeEditor();

			if(themeEditor.ShowDialog() == DialogResult.OK)
			{
				try
				{
					var codeEditor = tabControl.SelectedTab.Controls[0] as CodeEditor;
					codeEditor.SetEditorStyle();
				}
				catch { }
			}
		}

		private void SettingsInit()
		{
			if(Properties.Settings.Default.FirstStart)
			{
				Properties.Settings.Default.BackgroundColor = DefaultBackColor;
				Properties.Settings.Default.ForeColor = DefaultForeColor;
			}
		}

		private void CloseToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			tabControl.TabPages.RemoveAt(tabClickIndex);
		}
	}
}
