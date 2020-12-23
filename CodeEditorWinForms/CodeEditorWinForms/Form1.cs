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

namespace CodeEditorWinForms
{
	public partial class Form1 : Form
	{

		ToolStripMenuItem currentLanguage;

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

		private void InitFileExplorer()
		{
			PopulateTreeView(@"C:\Users\Rin\Desktop\AutoCorrect");
		}

		private void PopulateTreeView(string path)
		{
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
			currentLanguage = cToolStripMenuItem;
			SelectLanguage(currentLanguage);
		}

		private void newToolStripMenuItem_Click(object sender, EventArgs e)
		{
			codeEditor.Text = "";
		}

		private void OpenFileDialog()
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();

			openFileDialog.Filter = "Text file|*.txt|Any file|*.*";

			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				StreamReader streamReader = new StreamReader(openFileDialog.FileName);

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

			saveFileDialog.Filter = "Text file|*.txt|Any file|*.*";

			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);

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
			codeEditor.Cut();
		}

		private void copyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			codeEditor.Copy();
		}

		private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			codeEditor.Paste();
		}

		private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ColorDialog colorDialog = new ColorDialog();

			if (colorDialog.ShowDialog() == DialogResult.OK)
			{
				codeEditor.BackColor = colorDialog.Color;
			}
		}

		private void textColorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ColorDialog colorDialog = new ColorDialog();

			if (colorDialog.ShowDialog() == DialogResult.OK)
			{
				codeEditor.ForeColor = colorDialog.Color;
			}
		}

		private void undoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			codeEditor.Undo();
		}

		private void redoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			codeEditor.Redo();
		}

		private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			codeEditor.SelectAll();
		}

		private void cutToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			codeEditor.Cut();
		}

		private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			codeEditor.Copy();
		}

		private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			codeEditor.Paste();
		}

		private void findToolStripMenuItem_Click(object sender, EventArgs e)
		{
			codeEditor.ShowFindDialog();
		}

		private void goToToolStripMenuItem_Click(object sender, EventArgs e)
		{
			codeEditor.ShowGoToDialog();
		}

		private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
		{
			codeEditor.ShowReplaceDialog();
		}

		private void SelectLanguage(object sender)
		{
			currentLanguage.Checked = false;
			currentLanguage = ((ToolStripMenuItem)sender);
			currentLanguage.Checked = true;

			codeEditor.Language = languages[currentLanguage.Text];

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

		void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			TreeView treeView = (TreeView)sender;
			if (treeView.SelectedNode.GetNodeCount(true) == 0)
			{
				MessageBox.Show(treeView.SelectedNode.FullPath);
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
	}
}
