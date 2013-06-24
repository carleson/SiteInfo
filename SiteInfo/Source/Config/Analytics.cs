/*
 * Created by SharpDevelop.
 * User: A491259
 * Date: 2013-06-24
 * Time: 11:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Configuration;

namespace SiteInfo.Config
{
	/// <summary>
	/// Description of Analytics.
	/// </summary>
	public class Analytics
	{
		private bool _enable_analytics;
		private bool _fetch_robots;
				
		public Analytics()
		{
			_enable_analytics = bool.Parse(ConfigurationManager.AppSettings["enable_analytics"]);
			_fetch_robots = bool.Parse(ConfigurationManager.AppSettings["analytics_fetch_robots"]);
			
			
		}
		
		public bool Enabled
	  	{
		  	get
		  	{
		  		return this._enable_analytics;
		  	}
		  	set
		  	{
		  		_enable_analytics = value;
		  	}
	  	}
		
		public bool FetchRobots
	  	{
		  	get
		  	{
		  		return this._fetch_robots;
		  	}
		  	set
		  	{
		  		_fetch_robots = value;
		  	}
	  	}
			
				
	}
}
