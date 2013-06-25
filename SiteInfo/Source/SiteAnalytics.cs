/*
 * Created by SharpDevelop.
 * User: Carleson
 * Date: 2013-06-18
 * Time: 14:28
 */
using System;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace SiteInfo
{
	/// <summary>
	/// Description of GetSiteAnalytics.
	/// </summary>
	public class SiteAnalytics
	{
		private SiteInfo _site;
		private const string WordPressPattern = "wp-content";
		private const string DrupalPattern = "drupal.js";
		private const string JoomlaPattern = "Joomla!";
		private const string PolopolyPattern = "polopoly";
		private const string GoogleAnalyticsPattern = "google-analytics.com";
		private const string GoogleTagPattern = "googletagservices.com";
		
		private bool IsWordPress = false;
		private bool IsDrupal = false;
		private bool IsJoomla =false;
		private bool IsPolopoly = false;
		
		private bool IsJavascriptEnabled =false;
		private bool HasGoogleTag = false;
		private bool HasGoogleAnalytics = false;
		
		
		public SiteAnalytics(SiteInfo site)
		{
			_site = site;
		}
		
#region Properties	
		public bool Enabled
	  	{
		  	get
		  	{
		  		return _site.config.analytics.Enabled;
		  	}
		}
		
		public bool FetchRobots
		{
			get
			{
				return _site.config.analytics.Enabled;
			}
		}
#endregion

#region Methods
		public string Get()
		{
			try
			{
				StringBuilder sb = new StringBuilder();
				
				IsWordPress = _site.Source.Contains(WordPressPattern);
				IsDrupal = _site.Source.Contains(DrupalPattern);
				IsJoomla = _site.Source.Contains(JoomlaPattern);
				IsPolopoly = _site.Source.Contains(PolopolyPattern);
				
				IsJavascriptEnabled = _site.Source.Contains("text/javascript");
				HasGoogleAnalytics = _site.Source.Contains(GoogleAnalyticsPattern);
				HasGoogleTag = _site.Source.Contains(GoogleTagPattern);
				
				//Summary
				if (IsWordPress) 			sb.AppendLine("Powered by: WordPress");
				if (IsDrupal) 				sb.AppendLine("Powered by: Drupal");
				if (IsJoomla) 				sb.AppendLine("Powered by: Joomla");
				if (IsPolopoly)				sb.AppendLine("Powered by: Polopoly");
				if (IsJavascriptEnabled) 	sb.AppendLine("Javascript - Enabled");
			
				if (HasGoogleAnalytics)		sb.AppendLine("Google Analytics Service");
				if (HasGoogleTag)			sb.AppendLine("Google Tag Service");
				
				if (FetchRobots) 			sb.AppendLine(GetRobots());
				
				return sb.ToString();
			}
			
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
				return string.Empty;
			}
		}
			
		
		private string GetRobots()
		{
			try
			{
				using (WebClient client = new WebClient ()) 
				{
					return client.DownloadString(string.Format("{0}/{1}",_site.url, "robots.txt"));
				}

			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
				return string.Empty;
			}
		}
		
#endregion

	}
}
