/*
 * Created by SharpDevelop.
 * User: Carleson
 * Date: 2013-06-18
 * Time: 14:28
 */
using System;
using System.Text;
using System.Windows.Forms;

namespace SiteInfo
{
	/// <summary>
	/// Description of GetSiteAnalytics.
	/// </summary>
	public class SiteAnalytics
	{
		private string _htmlOutput;
		public const string WordPressPattern = "wp-content";
		public const string DrupalPattern = "drupal.js";
		public const string JoomlaPattern = "Joomla!";
		public const string PolopolyPattern = "polopoly";
		public const string GoogleAnalyticsPattern = "google-analytics.com";
		public const string GoogleTagPattern = "googletagservices.com";

		
		public bool IsWordPress = false;
		public bool IsDrupal = false;
		public bool IsJoomla =false;
		public bool IsPolopoly = false;
		
		public bool IsJavascriptEnabled =false;
		public bool HasGoogleTag = false;
		public bool HasGoogleAnalytics = false;
			
		public SiteAnalytics(string htmlOutput)
		{
			_htmlOutput=htmlOutput;
		}
		
		public string Get()
		{
			try
			{
				StringBuilder sb = new StringBuilder();
				
				IsWordPress = _htmlOutput.Contains(WordPressPattern);
				IsDrupal = _htmlOutput.Contains(DrupalPattern);
				IsJoomla = _htmlOutput.Contains(JoomlaPattern);
				IsPolopoly = _htmlOutput.Contains(PolopolyPattern);
				
				IsJavascriptEnabled = _htmlOutput.Contains("text/javascript");
				HasGoogleAnalytics = _htmlOutput.Contains(GoogleAnalyticsPattern);
				HasGoogleTag = _htmlOutput.Contains(GoogleTagPattern);
				
				//Summary
				if (IsWordPress) 			sb.AppendLine("Powered by: WordPress");
				if (IsDrupal) 				sb.AppendLine("Powered by: Drupal");
				if (IsJoomla) 				sb.AppendLine("Powered by: Joomla");
				if (IsPolopoly)				sb.AppendLine("Powered by: Polopoly");
				if (IsJavascriptEnabled) 	sb.AppendLine("Javascript - Enabled");
			
				if (HasGoogleAnalytics)		sb.AppendLine("Google Analytics Service");
				if (HasGoogleTag)			sb.AppendLine("Google Tag Service");
				
				return sb.ToString();
			}
			
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
				return string.Empty;
			}
		}
				
	}
}
