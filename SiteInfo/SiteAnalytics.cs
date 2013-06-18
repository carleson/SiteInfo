/*
 * Created by SharpDevelop.
 * User: a491259
 * Date: 2013-06-18
 * Time: 14:28
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
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
		
		public bool IsWordPress = false;
		public bool IsDrupal = false;
		public bool IsJoomla =false;
		public bool IsPolopoly = false;
		
		public bool IsJavascriptEnabled =false;
		
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
				
				//Summary
				if (IsWordPress) 			sb.AppendLine("Powered by: WordPress");
				if (IsDrupal) 				sb.AppendLine("Powered by: Drupal");
				if (IsJoomla) 				sb.AppendLine("Powered by: Joomla");
				if (IsPolopoly)				sb.AppendLine("Powered by: Polopoly");
				if (IsJavascriptEnabled) 	sb.AppendLine("Javascript - Enabled");
			
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
