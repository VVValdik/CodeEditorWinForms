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
	}
}
