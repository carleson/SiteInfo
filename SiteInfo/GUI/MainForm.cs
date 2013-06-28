/*
 * Created by SharpDevelop.
 * User: Carleson
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
using System.Data;
using System.ComponentModel;

namespace SiteInfo
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		
		//public string _htmlOutput = string.Empty;
		public SiteInfo site;
		public Util util;
		public Config.SiteInfo config;

		public const string Version = "0.3.3";
		
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
		

		
		public void init()
		{	 
			util = new Util();
			config = new Config.SiteInfo();
			
			config.links.Enabled=false;
//			config.Save();
			
			SetStatus(string.Format("SiteInfo version {0}",Version));
			
			dgvLinks.AutoGenerateColumns = false;
		
		    DataGridViewCell cell = new DataGridViewTextBoxCell();
		    DataGridViewCell linkcell = new DataGridViewLinkCell();
		    
		    DataGridViewTextBoxColumn colLink = new DataGridViewTextBoxColumn()
		    {
		        CellTemplate = cell, 
		        Name = "Value",
		        HeaderText = "Links",
		        DataPropertyName = "Value" 
		     };
		
		    dgvLinks.Columns.Add(colLink);
		    
		    DataGridViewTextBoxColumn colDescription = new DataGridViewTextBoxColumn()
		    {
		        CellTemplate = cell, 
		        Name = "Description",
		        HeaderText = "Description",
		        DataPropertyName = "Description" 
		     };
		
		    dgvLinks.Columns.Add(colDescription);
		    
		    DataGridViewLinkColumn colUrl = new DataGridViewLinkColumn
		    {
		        CellTemplate = linkcell, 
		        Name = "Url",
		        HeaderText = "Url",
		        DataPropertyName = "Url" 
		     };
		
		    dgvLinks.Columns.Add(colUrl);
		    
		}
		
		
		private void SetStatus(string text)
		{
			toolStripProgress.Text=text;
		}
				
		public void GetSiteData()
		{
			try
			{
				string _htmlOutput;
					
				SetStatus("loading data...");
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
					client.Headers.Add ("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
					
				    _htmlOutput = client.DownloadString(txtURL.Text);
				}
				site = new SiteInfo(txtURL.Text,_htmlOutput, config);
				txtOutput.Text = site.Source;
				
				Run();
				
				SetStatus(string.Format("Source:{0}",txtURL.Text));
				
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
			finally
			{
				Cursor.Current=Cursors.Default;
				SetStatus("ready");
			}
		}

		private void GetSiteLinks()
		{
			if (config.links.Enabled)
			{
			    List<Link> links = util.GetLinks(site.Source);
		    	var linkList = new BindingList<Link>(links); 
		
		    	dgvLinks.DataSource = linkList;			
			}
		}
		
		private void GetSiteStatistics()
		{
			
			if (config.statistics.Enabled) textStats.Text =site.statistics.Get();
		}
		
		private void GetSiteAnalytics()
		{
			if (config.analytics.Enabled) txtAnalyze.Text=site.analytics.Get();
		}
		
		
		private void Run()
		{
			GetSiteStatistics();
			GetSiteAnalytics();
			GetSiteLinks();	
		}
		
		private void LoadFile()
		{
			string filename = util.LoadFileToTextbox(txtOutput);
			
			site = new SiteInfo(txtURL.Text, txtOutput.Text, config);
			SetStatus(string.Format("Loaded:{0}",filename));
			Run();
		}
		
#region "Events"

		void BtnFetchClick(object sender, EventArgs e)
		{
			GetSiteData();
		}
		
		void TxtURLKeyPress(object sender, KeyPressEventArgs e)
		{
		
			if (e.KeyChar == (char)Keys.Return)
	        {
				GetSiteData();
	            e.Handled = true;
	        }	
		}
		
		void FetchToolStripMenuItemClick(object sender, EventArgs e)
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
			SetStatus("added text to clipboard");	
		}
		
		void TxtAnalyzeTextChanged(object sender, EventArgs e)
		{
			util.CopyTextFromTextBox(txtAnalyze);
			SetStatus("added text to clipboard");	
		}
		
		void TextStatsTextChanged(object sender, EventArgs e)
		{
			util.CopyTextFromTextBox(textStats);
			SetStatus("added text to clipboard");	
		}
		
		void LoadToolStripMenuItemClick(object sender, EventArgs e)
		{
			LoadFile();
		}
		
		void SaveToolStripMenuItemClick(object sender, EventArgs e)
		{
			util.SaveStringToFile(site.Source);
		}
		
#endregion
		
	}
}
