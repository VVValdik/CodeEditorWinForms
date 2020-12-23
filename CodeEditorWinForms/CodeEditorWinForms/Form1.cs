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
		public Form1()
		{
			InitializeComponent();
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

			if(colorDialog.ShowDialog() == DialogResult.OK)
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

		private void cToolStripMenuItem_Click(object sender, EventArgs e)
		{
			codeEditor.Language = FastColoredTextBoxNS.Language.CSharp;
		}

		private void vBToolStripMenuItem_Click(object sender, EventArgs e)
		{
			codeEditor.Language = FastColoredTextBoxNS.Language.VB;
		}

		private void hTMLToolStripMenuItem_Click(object sender, EventArgs e)
		{
			codeEditor.Language = FastColoredTextBoxNS.Language.HTML;
		}

		private void pHPToolStripMenuItem_Click(object sender, EventArgs e)
		{
			codeEditor.Language = FastColoredTextBoxNS.Language.PHP;
		}

		private void jSToolStripMenuItem_Click(object sender, EventArgs e)
		{
			codeEditor.Language = FastColoredTextBoxNS.Language.JS;
		}

		private void sQLToolStripMenuItem_Click(object sender, EventArgs e)
		{
			codeEditor.Language = FastColoredTextBoxNS.Language.SQL;
		}

		private void lUAToolStripMenuItem_Click(object sender, EventArgs e)
		{
			codeEditor.Language = FastColoredTextBoxNS.Language.Lua;
		}

		private void xMLToolStripMenuItem_Click(object sender, EventArgs e)
		{
			codeEditor.Language = FastColoredTextBoxNS.Language.XML;
		}

		private void runHTMLToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if(codeEditor.Language == FastColoredTextBoxNS.Language.HTML)
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
	}
}
