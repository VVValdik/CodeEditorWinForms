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
	public partial class ThemeEditor : Form
	{
		const string BgColor = "bgColor";
		const string TextColor = "textColor";

		public ThemeEditor()
		{
			InitializeComponent();

			InitColors();
		}

		private void InitColors()
		{
			backgroundColorBox.BackColor = Properties.Settings.Default.BackgroundColor;
			textColorBox.BackColor = Properties.Settings.Default.ForeColor;
		}

		private void SaveColor(string name, Color color)
		{
			switch(name)
			{
				case BgColor:
					{
						Properties.Settings.Default.BackgroundColor = color;
					}
					break;
				case TextColor:
					{
						Properties.Settings.Default.BackgroundColor = color;
					}
					break;
			}
		}

		private void PickColor(object sender, string name)
		{
			ColorDialog colorDialog = new ColorDialog();

			if (colorDialog.ShowDialog() == DialogResult.OK)
			{
				((PictureBox)sender).BackColor = colorDialog.Color;

				SaveColor(name, colorDialog.Color);
			}
		}

		private void backgroundColorBox_Click(object sender, EventArgs e)
		{
			PickColor(sender, BgColor);
		}

		private void textColorBox_Click(object sender, EventArgs e)
		{
			PickColor(sender, TextColor);
		}
	}
}
