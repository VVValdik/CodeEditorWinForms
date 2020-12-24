using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Windows.Forms;

namespace CodeEditorWinForms
{
	class CSharpCompiler
	{

		public static void Compile(string programm)
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
			CompilerParameters parameters = new CompilerParameters(new string[] { "System.dll" });
			parameters.GenerateExecutable = true;
			parameters.OutputAssembly = OutPath;
			
			string[] sources = { programm };
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
