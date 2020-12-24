namespace CodeEditorWinForms
{
	partial class ThemeEditor
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.backgroundColorBox = new System.Windows.Forms.PictureBox();
			this.textColorBox = new System.Windows.Forms.PictureBox();
			this.label2 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.backgroundColorBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textColorBox)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(12, 41);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(181, 26);
			this.label1.TabIndex = 0;
			this.label1.Text = "Background color";
			// 
			// backgroundColorBox
			// 
			this.backgroundColorBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.backgroundColorBox.Location = new System.Drawing.Point(212, 28);
			this.backgroundColorBox.Name = "backgroundColorBox";
			this.backgroundColorBox.Size = new System.Drawing.Size(100, 50);
			this.backgroundColorBox.TabIndex = 1;
			this.backgroundColorBox.TabStop = false;
			this.backgroundColorBox.Click += new System.EventHandler(this.backgroundColorBox_Click);
			// 
			// textColorBox
			// 
			this.textColorBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.textColorBox.Location = new System.Drawing.Point(212, 84);
			this.textColorBox.Name = "textColorBox";
			this.textColorBox.Size = new System.Drawing.Size(100, 50);
			this.textColorBox.TabIndex = 3;
			this.textColorBox.TabStop = false;
			this.textColorBox.Click += new System.EventHandler(this.textColorBox_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.Location = new System.Drawing.Point(12, 99);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(106, 26);
			this.label2.TabIndex = 2;
			this.label2.Text = "Text color";
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.Location = new System.Drawing.Point(12, 232);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(360, 55);
			this.button1.TabIndex = 4;
			this.button1.Text = "OK";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// ThemeEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(384, 299);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textColorBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.backgroundColorBox);
			this.Controls.Add(this.label1);
			this.Name = "ThemeEditor";
			this.Text = "ThemeEditor";
			((System.ComponentModel.ISupportInitialize)(this.backgroundColorBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textColorBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox backgroundColorBox;
		private System.Windows.Forms.PictureBox textColorBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button1;
	}
}