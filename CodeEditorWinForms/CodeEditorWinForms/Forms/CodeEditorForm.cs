using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
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

		public CodeEditorForm()
		{
			InitializeComponent();

			Settings.Init();
			InitCodeEditor();
			InitFileExplorer();
		}

		private void InitFileExplorer()
		{
			fileExplorer = new FileExplorer(treeView);
		}

		private void InitCodeEditor()
		{
			AddNewTab(NewTab);
			GetCurrentCodeEditor().Focus();

			currentLanguage = cToolStripMenuItem;
			SelectLanguage(currentLanguage);
		}
		
		void AddNewTab(string name)
		{
			EditorTabPage newTab = new EditorTabPage(name, tabMenuStrip);

			tabControl.Controls.Add(newTab);
			tabControl.SelectTab(tabControl.TabCount - 1);
		}

		private void NewToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AddNewTab(NewTab);
			GetCurrentCodeEditor().Text = "";
		}

		private void OpenFileDialog()
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();

			openFileDialog.Filter = FileDialogFilterAny;

			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				StreamReader streamReader = new StreamReader(openFileDialog.FileName);

				AddNewTab(Path.GetFileName(openFileDialog.FileName));
				GetCurrentCodeEditor().Text = streamReader.ReadToEnd();

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

				if(!HasTabs())
				{
					return;
				}
				var codeEditor = GetCurrentCodeEditor();
				streamWriter.Write(codeEditor.Text);
				streamWriter.Close();
			}
			catch
			{
				OpenFileDialog();
			}
		}

		private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = FileDialogFilterAny;

			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);
				
				streamWriter.Write(GetCurrentCodeEditor().Text);

				streamWriter.Close();
			}
		}

		private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void CutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if(!HasTabs())
			{
				return;
			}

			var codeEditor = GetCurrentCodeEditor();
			codeEditor.Cut();
		}

		private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!HasTabs())
			{
				return;
			}

			var codeEditor = GetCurrentCodeEditor();

			codeEditor.Copy();
		}

		private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!HasTabs())
			{
				return;
			}

			var codeEditor = GetCurrentCodeEditor();

			codeEditor.Paste();
		}

		private void BackgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
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

		private void TextColorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ColorDialog colorDialog = new ColorDialog();

			if (colorDialog.ShowDialog() == DialogResult.OK)
			{
				var codeEditor = tabControl.SelectedTab.Controls[0] as FastColoredTextBox;
				codeEditor.ForeColor = colorDialog.Color;
			}
		}

		private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!HasTabs())
			{
				return;
			}

			var codeEditor = GetCurrentCodeEditor();
			codeEditor.Undo();
		}

		private void RedoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!HasTabs())
			{
				return;
			}

			var codeEditor = GetCurrentCodeEditor();
			codeEditor.Redo();
		}

		private void SelectAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!HasTabs())
			{
				return;
			}

			var codeEditor = GetCurrentCodeEditor();
			codeEditor.SelectAll();
		}

		private void CutToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			if (!HasTabs())
			{
				return;
			}

			var codeEditor = GetCurrentCodeEditor();
			codeEditor.Cut();
		}

		private void CopyToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			if (!HasTabs())
			{
				return;
			}

			var codeEditor = GetCurrentCodeEditor();
			codeEditor.Copy();
		}

		private void PasteToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			if (!HasTabs())
			{
				return;
			}

			var codeEditor = GetCurrentCodeEditor();
			codeEditor.Paste();
		}

		private void FindToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!HasTabs())
			{
				return;
			}

			var codeEditor = GetCurrentCodeEditor();
			codeEditor.ShowFindDialog();
		}

		private void GoToToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!HasTabs())
			{
				return;
			}

			var codeEditor = GetCurrentCodeEditor();
			codeEditor.ShowGoToDialog();
		}

		private void ReplaceToolStripMenuItem_Click(object sender, EventArgs e)
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

		private void CToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SelectLanguage(sender);
		}

		private void VBToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SelectLanguage(sender);
		}

		private void HTMLToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SelectLanguage(sender);
		}

		private void PHPToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SelectLanguage(sender);
		}

		private void JSToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SelectLanguage(sender);
		}

		private void SQLToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SelectLanguage(sender);
		}

		private void LUAToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SelectLanguage(sender);
		}

		private void XMLToolStripMenuItem_Click(object sender, EventArgs e)
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

		private void RunHTMLToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if(!HasTabs())
			{
				return;
			}

			var codeEditor = tabControl.SelectedTab.Controls[0] as CodeEditor;
			if (codeEditor.Language == Language.HTML)
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

		void CheckCurrentLanguage(string language)
		{
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

		void SetLanguage(string language)
		{
			if (Languages.languages.ContainsKey(language))
			{
				if (!HasTabs())
				{
					return;
				}

				var codeEditor = GetCurrentCodeEditor();

				codeEditor.Language = Languages.languages[language];
			}
			else
			{
				if (!HasTabs())
				{
					return;
				}

				var codeEditor = GetCurrentCodeEditor();

				codeEditor.Language = Language.CSharp;
			}

			CheckCurrentLanguage(language);
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

		private void OpenProjectFolderToolStripMenuItem_Click_1(object sender, EventArgs e)
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
						this.tabMenuStrip.Show(this.tabControl, e.Location);
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

		private void CloseToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			tabControl.TabPages.RemoveAt(tabClickIndex);
		}
	}
}
