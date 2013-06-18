/*
 * Created by SharpDevelop.
 * User: a491259
 * Date: 2013-06-17
 * Time: 09:22
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace SiteInfo
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.txtURL = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtOutput = new System.Windows.Forms.TextBox();
			this.btnCheck = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.LoadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.checkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusFooter = new System.Windows.Forms.StatusStrip();
			this.toolStripStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripProgress = new System.Windows.Forms.ToolStripStatusLabel();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPageSource = new System.Windows.Forms.TabPage();
			this.tabPageAnalyze = new System.Windows.Forms.TabPage();
			this.txtAnalyze = new System.Windows.Forms.TextBox();
			this.tabPageStats = new System.Windows.Forms.TabPage();
			this.textStats = new System.Windows.Forms.TextBox();
			this.tabPageLinks = new System.Windows.Forms.TabPage();
			this.tabPageOptions = new System.Windows.Forms.TabPage();
			this.groupBox1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.statusFooter.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPageSource.SuspendLayout();
			this.tabPageAnalyze.SuspendLayout();
			this.tabPageStats.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtURL
			// 
			this.txtURL.Location = new System.Drawing.Point(84, 37);
			this.txtURL.Name = "txtURL";
			this.txtURL.Size = new System.Drawing.Size(424, 22);
			this.txtURL.TabIndex = 0;
			this.txtURL.Text = "http://www.sunet.se";
			this.txtURL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtURLKeyPress);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(29, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(49, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "URL:";
			// 
			// txtOutput
			// 
			this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtOutput.Location = new System.Drawing.Point(3, 3);
			this.txtOutput.Multiline = true;
			this.txtOutput.Name = "txtOutput";
			this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtOutput.Size = new System.Drawing.Size(950, 420);
			this.txtOutput.TabIndex = 2;
			this.txtOutput.DoubleClick += new System.EventHandler(this.TxtOutputDoubleClick);
			// 
			// btnCheck
			// 
			this.btnCheck.Location = new System.Drawing.Point(418, 65);
			this.btnCheck.Name = "btnCheck";
			this.btnCheck.Size = new System.Drawing.Size(90, 28);
			this.btnCheck.TabIndex = 3;
			this.btnCheck.Text = "&Check";
			this.btnCheck.UseVisualStyleBackColor = true;
			this.btnCheck.Click += new System.EventHandler(this.BtnCheckClick);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtURL);
			this.groupBox1.Controls.Add(this.btnCheck);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 28);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(964, 124);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.fileToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(964, 28);
			this.menuStrip1.TabIndex = 5;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.LoadToolStripMenuItem,
									this.toolStripSeparator1,
									this.SaveToolStripMenuItem,
									this.toolStripSeparator2,
									this.checkToolStripMenuItem,
									this.quitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// LoadToolStripMenuItem
			// 
			this.LoadToolStripMenuItem.Name = "LoadToolStripMenuItem";
			this.LoadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.LoadToolStripMenuItem.Size = new System.Drawing.Size(173, 24);
			this.LoadToolStripMenuItem.Text = "Load...";
			this.LoadToolStripMenuItem.Click += new System.EventHandler(this.LoadToolStripMenuItemClick);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(170, 6);
			// 
			// SaveToolStripMenuItem
			// 
			this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
			this.SaveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.SaveToolStripMenuItem.Size = new System.Drawing.Size(173, 24);
			this.SaveToolStripMenuItem.Text = "Save";
			this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItemClick);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(170, 6);
			// 
			// checkToolStripMenuItem
			// 
			this.checkToolStripMenuItem.Name = "checkToolStripMenuItem";
			this.checkToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
			this.checkToolStripMenuItem.Size = new System.Drawing.Size(173, 24);
			this.checkToolStripMenuItem.Text = "&Check";
			this.checkToolStripMenuItem.Click += new System.EventHandler(this.CheckToolStripMenuItemClick);
			// 
			// quitToolStripMenuItem
			// 
			this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
			this.quitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
			this.quitToolStripMenuItem.Size = new System.Drawing.Size(173, 24);
			this.quitToolStripMenuItem.Text = "&Quit";
			this.quitToolStripMenuItem.Click += new System.EventHandler(this.QuitToolStripMenuItemClick);
			// 
			// statusFooter
			// 
			this.statusFooter.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.toolStripStatus,
									this.toolStripProgress});
			this.statusFooter.Location = new System.Drawing.Point(0, 616);
			this.statusFooter.Name = "statusFooter";
			this.statusFooter.Size = new System.Drawing.Size(964, 25);
			this.statusFooter.TabIndex = 4;
			this.statusFooter.Text = "status";
			// 
			// toolStripStatus
			// 
			this.toolStripStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.toolStripStatus.Name = "toolStripStatus";
			this.toolStripStatus.Size = new System.Drawing.Size(136, 20);
			this.toolStripStatus.Text = "SiteInfo XXXXXXXX";
			// 
			// toolStripProgress
			// 
			this.toolStripProgress.Name = "toolStripProgress";
			this.toolStripProgress.Size = new System.Drawing.Size(65, 20);
			this.toolStripProgress.Text = "Progress";
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPageSource);
			this.tabControl1.Controls.Add(this.tabPageAnalyze);
			this.tabControl1.Controls.Add(this.tabPageStats);
			this.tabControl1.Controls.Add(this.tabPageLinks);
			this.tabControl1.Controls.Add(this.tabPageOptions);
			this.tabControl1.Location = new System.Drawing.Point(0, 158);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(964, 455);
			this.tabControl1.TabIndex = 6;
			// 
			// tabPageSource
			// 
			this.tabPageSource.Controls.Add(this.txtOutput);
			this.tabPageSource.Location = new System.Drawing.Point(4, 25);
			this.tabPageSource.Name = "tabPageSource";
			this.tabPageSource.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageSource.Size = new System.Drawing.Size(956, 426);
			this.tabPageSource.TabIndex = 0;
			this.tabPageSource.Text = "Source";
			this.tabPageSource.UseVisualStyleBackColor = true;
			// 
			// tabPageAnalyze
			// 
			this.tabPageAnalyze.Controls.Add(this.txtAnalyze);
			this.tabPageAnalyze.Location = new System.Drawing.Point(4, 25);
			this.tabPageAnalyze.Name = "tabPageAnalyze";
			this.tabPageAnalyze.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageAnalyze.Size = new System.Drawing.Size(956, 426);
			this.tabPageAnalyze.TabIndex = 1;
			this.tabPageAnalyze.Text = "Analyze";
			this.tabPageAnalyze.UseVisualStyleBackColor = true;
			// 
			// txtAnalyze
			// 
			this.txtAnalyze.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtAnalyze.Location = new System.Drawing.Point(3, 3);
			this.txtAnalyze.Multiline = true;
			this.txtAnalyze.Name = "txtAnalyze";
			this.txtAnalyze.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtAnalyze.Size = new System.Drawing.Size(950, 420);
			this.txtAnalyze.TabIndex = 0;
			this.txtAnalyze.TextChanged += new System.EventHandler(this.TxtAnalyzeTextChanged);
			// 
			// tabPageStats
			// 
			this.tabPageStats.Controls.Add(this.textStats);
			this.tabPageStats.Location = new System.Drawing.Point(4, 25);
			this.tabPageStats.Name = "tabPageStats";
			this.tabPageStats.Size = new System.Drawing.Size(956, 426);
			this.tabPageStats.TabIndex = 2;
			this.tabPageStats.Text = "Stats";
			this.tabPageStats.UseVisualStyleBackColor = true;
			// 
			// textStats
			// 
			this.textStats.AcceptsReturn = true;
			this.textStats.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textStats.Location = new System.Drawing.Point(0, 0);
			this.textStats.Multiline = true;
			this.textStats.Name = "textStats";
			this.textStats.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textStats.Size = new System.Drawing.Size(956, 426);
			this.textStats.TabIndex = 0;
			this.textStats.TextChanged += new System.EventHandler(this.TextStatsTextChanged);
			// 
			// tabPageLinks
			// 
			this.tabPageLinks.Location = new System.Drawing.Point(4, 25);
			this.tabPageLinks.Name = "tabPageLinks";
			this.tabPageLinks.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageLinks.Size = new System.Drawing.Size(956, 426);
			this.tabPageLinks.TabIndex = 3;
			this.tabPageLinks.Text = "Links";
			this.tabPageLinks.UseVisualStyleBackColor = true;
			// 
			// tabPageOptions
			// 
			this.tabPageOptions.Location = new System.Drawing.Point(4, 25);
			this.tabPageOptions.Name = "tabPageOptions";
			this.tabPageOptions.Size = new System.Drawing.Size(956, 426);
			this.tabPageOptions.TabIndex = 4;
			this.tabPageOptions.Text = "Options";
			this.tabPageOptions.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(964, 641);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.statusFooter);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.Text = "SiteInfo";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.statusFooter.ResumeLayout(false);
			this.statusFooter.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPageSource.ResumeLayout(false);
			this.tabPageSource.PerformLayout();
			this.tabPageAnalyze.ResumeLayout(false);
			this.tabPageAnalyze.PerformLayout();
			this.tabPageStats.ResumeLayout(false);
			this.tabPageStats.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.TabPage tabPageOptions;
		private System.Windows.Forms.TabPage tabPageLinks;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem LoadToolStripMenuItem;
		private System.Windows.Forms.TextBox textStats;
		private System.Windows.Forms.TextBox txtAnalyze;
		private System.Windows.Forms.TabPage tabPageStats;
		private System.Windows.Forms.TabPage tabPageAnalyze;
		private System.Windows.Forms.TabPage tabPageSource;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripProgress;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatus;
		private System.Windows.Forms.StatusStrip statusFooter;
		private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem checkToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnCheck;
		private System.Windows.Forms.TextBox txtOutput;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtURL;
	}
}
