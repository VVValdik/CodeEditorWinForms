namespace CodeEditorWinForms
{
	partial class CodeEditorForm
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
			#region Код, автоматически созданный конструктором форм Windows
		}
		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openProjectFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.goToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.replaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.vBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.hTMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pHPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.jSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sQLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.lUAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.xMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.themeEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.runHTMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.runCShaprCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.copyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.pasteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.treeView = new System.Windows.Forms.TreeView();
			this.tabMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.newToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.tabMenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.languageToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.runToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(800, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem,
            this.openProjectFolderToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
			this.newToolStripMenuItem.Text = "New";
			this.newToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
			this.openToolStripMenuItem.Text = "Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			// 
			// saveAsToolStripMenuItem
			// 
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
			this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
			this.saveAsToolStripMenuItem.Text = "Save as...";
			this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
			// 
			// openProjectFolderToolStripMenuItem
			// 
			this.openProjectFolderToolStripMenuItem.Name = "openProjectFolderToolStripMenuItem";
			this.openProjectFolderToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
			this.openProjectFolderToolStripMenuItem.Text = "Open project folder";
			this.openProjectFolderToolStripMenuItem.Click += new System.EventHandler(this.OpenProjectFolderToolStripMenuItem_Click_1);
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.findToolStripMenuItem,
            this.goToToolStripMenuItem,
            this.replaceToolStripMenuItem});
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
			this.editToolStripMenuItem.Text = "Edit";
			// 
			// cutToolStripMenuItem
			// 
			this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
			this.cutToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
			this.cutToolStripMenuItem.Text = "Cut";
			this.cutToolStripMenuItem.Click += new System.EventHandler(this.CutToolStripMenuItem_Click);
			// 
			// copyToolStripMenuItem
			// 
			this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
			this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
			this.copyToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
			this.copyToolStripMenuItem.Text = "Copy";
			this.copyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
			// 
			// pasteToolStripMenuItem
			// 
			this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
			this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
			this.pasteToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
			this.pasteToolStripMenuItem.Text = "Paste";
			this.pasteToolStripMenuItem.Click += new System.EventHandler(this.PasteToolStripMenuItem_Click);
			// 
			// undoToolStripMenuItem
			// 
			this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
			this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
			this.undoToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
			this.undoToolStripMenuItem.Text = "Undo";
			this.undoToolStripMenuItem.Click += new System.EventHandler(this.UndoToolStripMenuItem_Click);
			// 
			// redoToolStripMenuItem
			// 
			this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
			this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
			this.redoToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
			this.redoToolStripMenuItem.Text = "Redo";
			this.redoToolStripMenuItem.Click += new System.EventHandler(this.RedoToolStripMenuItem_Click);
			// 
			// findToolStripMenuItem
			// 
			this.findToolStripMenuItem.Name = "findToolStripMenuItem";
			this.findToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
			this.findToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
			this.findToolStripMenuItem.Text = "Find";
			this.findToolStripMenuItem.Click += new System.EventHandler(this.FindToolStripMenuItem_Click);
			// 
			// goToToolStripMenuItem
			// 
			this.goToToolStripMenuItem.Name = "goToToolStripMenuItem";
			this.goToToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
			this.goToToolStripMenuItem.Text = "Go to";
			this.goToToolStripMenuItem.Click += new System.EventHandler(this.GoToToolStripMenuItem_Click);
			// 
			// replaceToolStripMenuItem
			// 
			this.replaceToolStripMenuItem.Name = "replaceToolStripMenuItem";
			this.replaceToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.F)));
			this.replaceToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
			this.replaceToolStripMenuItem.Text = "Replace";
			this.replaceToolStripMenuItem.Click += new System.EventHandler(this.ReplaceToolStripMenuItem_Click);
			// 
			// languageToolStripMenuItem
			// 
			this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cToolStripMenuItem,
            this.vBToolStripMenuItem,
            this.hTMLToolStripMenuItem,
            this.pHPToolStripMenuItem,
            this.jSToolStripMenuItem,
            this.sQLToolStripMenuItem,
            this.lUAToolStripMenuItem,
            this.xMLToolStripMenuItem});
			this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
			this.languageToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
			this.languageToolStripMenuItem.Text = "Language";
			// 
			// cToolStripMenuItem
			// 
			this.cToolStripMenuItem.Name = "cToolStripMenuItem";
			this.cToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
			this.cToolStripMenuItem.Text = "C#";
			this.cToolStripMenuItem.Click += new System.EventHandler(this.CToolStripMenuItem_Click);
			// 
			// vBToolStripMenuItem
			// 
			this.vBToolStripMenuItem.Name = "vBToolStripMenuItem";
			this.vBToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
			this.vBToolStripMenuItem.Text = "VB";
			this.vBToolStripMenuItem.Click += new System.EventHandler(this.VBToolStripMenuItem_Click);
			// 
			// hTMLToolStripMenuItem
			// 
			this.hTMLToolStripMenuItem.Name = "hTMLToolStripMenuItem";
			this.hTMLToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
			this.hTMLToolStripMenuItem.Text = "HTML";
			this.hTMLToolStripMenuItem.Click += new System.EventHandler(this.HTMLToolStripMenuItem_Click);
			// 
			// pHPToolStripMenuItem
			// 
			this.pHPToolStripMenuItem.Name = "pHPToolStripMenuItem";
			this.pHPToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
			this.pHPToolStripMenuItem.Text = "PHP";
			this.pHPToolStripMenuItem.Click += new System.EventHandler(this.PHPToolStripMenuItem_Click);
			// 
			// jSToolStripMenuItem
			// 
			this.jSToolStripMenuItem.Name = "jSToolStripMenuItem";
			this.jSToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
			this.jSToolStripMenuItem.Text = "JS";
			this.jSToolStripMenuItem.Click += new System.EventHandler(this.JSToolStripMenuItem_Click);
			// 
			// sQLToolStripMenuItem
			// 
			this.sQLToolStripMenuItem.Name = "sQLToolStripMenuItem";
			this.sQLToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
			this.sQLToolStripMenuItem.Text = "SQL";
			this.sQLToolStripMenuItem.Click += new System.EventHandler(this.SQLToolStripMenuItem_Click);
			// 
			// lUAToolStripMenuItem
			// 
			this.lUAToolStripMenuItem.Name = "lUAToolStripMenuItem";
			this.lUAToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
			this.lUAToolStripMenuItem.Text = "LUA";
			this.lUAToolStripMenuItem.Click += new System.EventHandler(this.LUAToolStripMenuItem_Click);
			// 
			// xMLToolStripMenuItem
			// 
			this.xMLToolStripMenuItem.Name = "xMLToolStripMenuItem";
			this.xMLToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
			this.xMLToolStripMenuItem.Text = "XML";
			this.xMLToolStripMenuItem.Click += new System.EventHandler(this.XMLToolStripMenuItem_Click);
			// 
			// settingsToolStripMenuItem
			// 
			this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.themeEditorToolStripMenuItem});
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
			this.settingsToolStripMenuItem.Text = "Settings";
			// 
			// themeEditorToolStripMenuItem
			// 
			this.themeEditorToolStripMenuItem.Name = "themeEditorToolStripMenuItem";
			this.themeEditorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.themeEditorToolStripMenuItem.Text = "ThemeEditor";
			this.themeEditorToolStripMenuItem.Click += new System.EventHandler(this.ThemeEditorToolStripMenuItem_Click);
			// 
			// runToolStripMenuItem
			// 
			this.runToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runHTMLToolStripMenuItem,
            this.runCShaprCodeToolStripMenuItem});
			this.runToolStripMenuItem.Name = "runToolStripMenuItem";
			this.runToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
			this.runToolStripMenuItem.Text = "Run";
			// 
			// runHTMLToolStripMenuItem
			// 
			this.runHTMLToolStripMenuItem.Name = "runHTMLToolStripMenuItem";
			this.runHTMLToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.runHTMLToolStripMenuItem.Text = "Run HTML";
			this.runHTMLToolStripMenuItem.Click += new System.EventHandler(this.RunHTMLToolStripMenuItem_Click);
			// 
			// runCShaprCodeToolStripMenuItem
			// 
			this.runCShaprCodeToolStripMenuItem.Name = "runCShaprCodeToolStripMenuItem";
			this.runCShaprCodeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.runCShaprCodeToolStripMenuItem.Text = "Run CShapr code";
			this.runCShaprCodeToolStripMenuItem.Click += new System.EventHandler(this.RunCShaprCodeToolStripMenuItem_Click);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAllToolStripMenuItem,
            this.cutToolStripMenuItem1,
            this.copyToolStripMenuItem1,
            this.pasteToolStripMenuItem1});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(123, 92);
			// 
			// selectAllToolStripMenuItem
			// 
			this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
			this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			this.selectAllToolStripMenuItem.Text = "Select All";
			this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.SelectAllToolStripMenuItem_Click);
			// 
			// cutToolStripMenuItem1
			// 
			this.cutToolStripMenuItem1.Name = "cutToolStripMenuItem1";
			this.cutToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
			this.cutToolStripMenuItem1.Text = "Cut";
			this.cutToolStripMenuItem1.Click += new System.EventHandler(this.CutToolStripMenuItem1_Click);
			// 
			// copyToolStripMenuItem1
			// 
			this.copyToolStripMenuItem1.Name = "copyToolStripMenuItem1";
			this.copyToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
			this.copyToolStripMenuItem1.Text = "Copy";
			this.copyToolStripMenuItem1.Click += new System.EventHandler(this.CopyToolStripMenuItem1_Click);
			// 
			// pasteToolStripMenuItem1
			// 
			this.pasteToolStripMenuItem1.Name = "pasteToolStripMenuItem1";
			this.pasteToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
			this.pasteToolStripMenuItem1.Text = "Paste";
			this.pasteToolStripMenuItem1.Click += new System.EventHandler(this.PasteToolStripMenuItem1_Click);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 24);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.tabControl);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.treeView);
			this.splitContainer1.Size = new System.Drawing.Size(800, 426);
			this.splitContainer1.SplitterDistance = 629;
			this.splitContainer1.TabIndex = 4;
			// 
			// tabControl
			// 
			this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl.Location = new System.Drawing.Point(0, 0);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(629, 426);
			this.tabControl.TabIndex = 0;
			this.tabControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TabControl1_MouseClick);
			// 
			// treeView
			// 
			this.treeView.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeView.Location = new System.Drawing.Point(0, 0);
			this.treeView.Name = "treeView";
			this.treeView.Size = new System.Drawing.Size(167, 426);
			this.treeView.TabIndex = 0;
			this.treeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeView1_NodeMouseDoubleClick);
			// 
			// tabMenuStrip
			// 
			this.tabMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem1,
            this.closeToolStripMenuItem});
			this.tabMenuStrip.Name = "contextMenuStrip2";
			this.tabMenuStrip.Size = new System.Drawing.Size(104, 48);
			// 
			// newToolStripMenuItem1
			// 
			this.newToolStripMenuItem1.Name = "newToolStripMenuItem1";
			this.newToolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
			this.newToolStripMenuItem1.Text = "New";
			this.newToolStripMenuItem1.Click += new System.EventHandler(this.NewToolStripMenuItem1_Click);
			// 
			// closeToolStripMenuItem
			// 
			this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
			this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.closeToolStripMenuItem.Text = "Close";
			this.closeToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click_1);
			// 
			// CodeEditorForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "CodeEditorForm";
			this.Text = "CodeEditor";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.contextMenuStrip1.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.tabMenuStrip.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem goToToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem replaceToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem vBToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem hTMLToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pHPToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem jSToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem sQLToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem lUAToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem xMLToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem runHTMLToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem runCShaprCodeToolStripMenuItem;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TreeView treeView;
		private System.Windows.Forms.ToolStripMenuItem openProjectFolderToolStripMenuItem;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.ContextMenuStrip tabMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem themeEditorToolStripMenuItem;
	}
}

