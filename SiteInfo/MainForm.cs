/*
 * Created by SharpDevelop.
 * User: a491259
 * Date: 2013-06-17
 * Time: 09:22
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.Text;

namespace SiteInfo
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		
		public string _htmlOutput = string.Empty;
		public SiteInfo site;
		public SiteStatistics statistics;
		public SiteAnalytics analytics;
		public Util util;
		
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			init();
		}
		
		void BtnCheckClick(object sender, EventArgs e)
		{
			GetSiteData();
		}
		
		public void init()
		{
			util = new Util();
			util.InitStatus(toolStripProgress);
			
			site = new SiteInfo();
			 
			toolStripStatus.Text = string.Format("SiteInfo version {0}",site.GetVersion());
			util.SetStatus("Test");
		}
		
		
		public void GetSiteData()
		{
			try
			{
				util.SetStatus("loading data...");
				Cursor.Current=Cursors.WaitCursor;
				
				txtOutput.Clear();
				txtAnalyze.Clear();
				textStats.Clear();
				
				if (txtURL.Text.Contains("http://") == false)
			     {
			     	txtURL.Text = string.Format("{0}{1}","http://",txtURL.Text);
			     }
				     
				using (WebClient client = new WebClient ()) 
				{
				    _htmlOutput = client.DownloadString(txtURL.Text);
				}
				
				txtOutput.Text = _htmlOutput;
				

					
				GetSiteStatistics();
				GetSiteAnalytics();
				util.SetStatus(string.Format("Source:{0}",txtURL.Text));
				
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
			finally
			{
				Cursor.Current=Cursors.Default;
				util.SetStatus("ready");
			}
		}

		public void GetSiteStatistics()
		{
			statistics = new SiteStatistics(_htmlOutput);
			textStats.Text = statistics.Get();	
		}
		
		public void GetSiteAnalytics()
		{
			analytics = new SiteAnalytics(_htmlOutput);
			txtAnalyze.Text=analytics.Get();
		}
		
		public void LoadFile()
		{
			util.LoadFile(txtOutput);
			_htmlOutput=txtOutput.Text;
			
			GetSiteStatistics();
			GetSiteAnalytics();
		}
		
#region "Events"
		void TxtURLKeyPress(object sender, KeyPressEventArgs e)
		{
		
			if (e.KeyChar == (char)Keys.Return)
	        {
				GetSiteData();
	            e.Handled = true;
	        }	
		}
		
		void CheckToolStripMenuItemClick(object sender, EventArgs e)
		{
			GetSiteData();
		}
		
		void QuitToolStripMenuItemClick(object sender, EventArgs e)
		{
			Application.Exit();
		}
		
		void TxtOutputDoubleClick(object sender, EventArgs e)
		{		
			util.CopyTextFromTextBox(txtOutput);
		}
		
		void TxtAnalyzeTextChanged(object sender, EventArgs e)
		{
			util.CopyTextFromTextBox(txtAnalyze);
		}
		
		void TextStatsTextChanged(object sender, EventArgs e)
		{
			util.CopyTextFromTextBox(textStats);
		}
		
		void LoadToolStripMenuItemClick(object sender, EventArgs e)
		{
			LoadFile();
		}
		
		void SaveToolStripMenuItemClick(object sender, EventArgs e)
		{
			util.SaveStringToFile(_htmlOutput);
		}
		
#endregion

	
	

		

	}
}
