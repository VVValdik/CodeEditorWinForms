using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeEditorWinForms
{
	public partial class HTMLPreview : Form
	{
		public HTMLPreview(string htmlCode)
		{
			InitializeComponent();

			webBrowser1.DocumentText = htmlCode;
		}

		private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{

		}

		private void label1_Click(object sender, EventArgs e)
		{

		}
	}
}
