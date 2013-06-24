/*
 * Created by SharpDevelop.
 * User: Carleson
 * Date: 2013-06-24
 * Time: 11:02
 */
using System;
using System.Configuration;

namespace SiteInfo.Config
{
	/// <summary>
	/// Description of ConfigStatistics.
	/// </summary>
	public class Statistics
	{
		private bool _enable_statistics = false;
		
		public Statistics()
		{
			_enable_statistics = bool.Parse(ConfigurationManager.AppSettings["enable_statistics"]);
		}

	
		public bool Enabled
	  	{
		  	get
		  	{
		  		return this._enable_statistics;
		  	}
		  	set
		  	{
		  		_enable_statistics = value;
		  	}
	  	}
	}
}
