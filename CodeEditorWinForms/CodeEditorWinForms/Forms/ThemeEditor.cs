using System;
using System.Drawing;
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

		private void BackgroundColorBox_Click(object sender, EventArgs e)
		{
			PickColor(sender, BgColor);
		}

		private void TextColorBox_Click(object sender, EventArgs e)
		{
			PickColor(sender, TextColor);
		}

		private void Reset_Click(object sender, EventArgs e)
		{
			Settings.SetDefault();
			InitColors();	
		}
	}
}
