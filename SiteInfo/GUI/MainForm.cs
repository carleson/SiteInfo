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
		
		public string _htmlOutput = string.Empty;
		public SiteInfo site;
//		public SiteStatistics statistics;
		public SiteAnalytics analytics;
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
		
		void BtnCheckClick(object sender, EventArgs e)
		{
			GetSiteData();
		}
		
		public void init()
		{	 
			SetStatus(string.Format("SiteInfo version {0}",Version));
		}
		
		
		private void SetStatus(string text)
		{
			toolStripProgress.Text=text;
		}
				
		public void GetSiteData()
		{
			try
			{
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
				    _htmlOutput = client.DownloadString(txtURL.Text);
				}
				site = new SiteInfo(_htmlOutput);
				txtOutput.Text = _htmlOutput;
				
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
		    dgvLinks.AutoGenerateColumns = false;
		
		    //create the column programatically
		    DataGridViewCell cell = new DataGridViewTextBoxCell();
		    DataGridViewTextBoxColumn colLink = new DataGridViewTextBoxColumn()
		    {
		        CellTemplate = cell, 
		        Name = "Value",
		        HeaderText = "Links",
		        DataPropertyName = "Value" 
		     };
		
		    dgvLinks.Columns.Add(colLink);
		
		    List<Link> links = site.util.GetLinks(_htmlOutput);
		    
		    var linkList = new BindingList<Link>(links); 
		
		    dgvLinks.DataSource = linkList;
		}
		
		private void GetSiteStatistics()
		{
			//statistics = new SiteStatistics(_htmlOutput);
			textStats.Text =  site.statistics.Get();	
		}
		
		private void GetSiteAnalytics()
		{
			analytics = new SiteAnalytics(_htmlOutput);
			txtAnalyze.Text=analytics.Get();
		}
		
		
		public void Run()
		{
			GetSiteStatistics();
			GetSiteAnalytics();
			GetSiteLinks();	
		}
		
		public void LoadFile()
		{
			//TODO Fix this !!
			site = new SiteInfo(txtOutput.Text);
			string filename = site.util.LoadFileToTextbox(txtOutput);
			_htmlOutput=txtOutput.Text;
			SetStatus(string.Format("Loaded:{0}",filename));
			Run();
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
			site.util.CopyTextFromTextBox(txtOutput);
			SetStatus("added text to clipboard");	
		}
		
		void TxtAnalyzeTextChanged(object sender, EventArgs e)
		{
			site.util.CopyTextFromTextBox(txtAnalyze);
			SetStatus("added text to clipboard");	
		}
		
		void TextStatsTextChanged(object sender, EventArgs e)
		{
			site.util.CopyTextFromTextBox(textStats);
			SetStatus("added text to clipboard");	
		}
		
		void LoadToolStripMenuItemClick(object sender, EventArgs e)
		{
			LoadFile();
		}
		
		void SaveToolStripMenuItemClick(object sender, EventArgs e)
		{
			site.util.SaveStringToFile(_htmlOutput);
		}
		
#endregion

	
	

		

	}
}
