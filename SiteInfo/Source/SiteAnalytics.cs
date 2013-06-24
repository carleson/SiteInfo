﻿/*
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
		public const string WordPressPattern = "wp-content";
		public const string DrupalPattern = "drupal.js";
		public const string JoomlaPattern = "Joomla!";
		public const string PolopolyPattern = "polopoly";
		public const string GoogleAnalyticsPattern = "google-analytics.com";
		public const string GoogleTagPattern = "googletagservices.com";

		public bool FetchRobots = false;
		
		public bool IsWordPress = false;
		public bool IsDrupal = false;
		public bool IsJoomla =false;
		public bool IsPolopoly = false;
		
		public bool IsJavascriptEnabled =false;
		public bool HasGoogleTag = false;
		public bool HasGoogleAnalytics = false;
		
		
		public SiteAnalytics(SiteInfo site)
		{
			_site = site;
		}
		
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
				
				if (FetchRobots)			sb.AppendLine(GetRobots());
				
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
	}
}
