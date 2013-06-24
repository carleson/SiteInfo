/*
 * Created by SharpDevelop.
 * User: Carleson
 * Date: 2013-06-24
 * Time: 10:42
 */
using System;
using System.Configuration;

namespace SiteInfo.Config
{
	/// <summary>
	/// Description of SiteConfig.
	/// </summary>
	public class SiteInfo
	{
		private Statistics _statistics;
		private Analytics _analytics;
		private Links _links;
		
		public SiteInfo()
		{
			_statistics = new Statistics();
			_analytics = new Analytics();
			_links = new Links();

		}

		public Statistics statistics
	  	{
		  	get
		  	{
		  		return this._statistics;
		  	}
	  	}
		
		public Analytics analytics
	  	{
		  	get
		  	{
		  		return this._analytics;
		  	}
	  	}
	
		public Links links
	  	{
		  	get
		  	{
		  		return this._links;
		  	}
	  	}
		
		public void Save(string key, string value)
		{
			Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			AppSettingsSection app = config.AppSettings;
			app.Settings.Add(key, value);
			config.Save(ConfigurationSaveMode.Modified);
		}
	}
	
}
