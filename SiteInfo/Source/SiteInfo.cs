/*
 * Created by SharpDevelop.
 * User: Carleson
 * Date: 2013-06-18
 * Time: 10:40
 */

using System;
using SiteInfo.Config;

namespace SiteInfo
{
	/// <summary>
	/// Description of SiteInfo.
	/// </summary>
	public class SiteInfo
	{
		
		private string _html;
		private string _url;		
		private Config.SiteInfo _config;
		private SiteStatistics _statistics;
		private SiteAnalytics _analytics;
		
		public SiteInfo(string url,string htmlOutput, Config.SiteInfo config)
		{
			_html = htmlOutput;
			_url = url;
			_statistics = new SiteStatistics(this);
			_analytics = new SiteAnalytics(this);
			
			if (config != null)
			{
				_config=config;
			}
			else
			{
				_config = new Config.SiteInfo();

			}
		}
	
#region Properies
	  
	  public SiteStatistics statistics
	  {
	  	get
	  	{
	  		return this._statistics;
	  	}
	  }

	  public SiteAnalytics analytics
	  {
	  	get
	  	{
	  		return this._analytics;
	  	}
	  }
	  
	  public string Source
	  {
		get
		{
			return this._html;
		}
	  }
	  
	  public Config.SiteInfo config
	  {
		get
		{
			return this._config;
		}
	  }
	  
	  public string url
	  {
	  	get
	  	{
	  		return this._url;
	  	}
	  	set
	  	{
	  		_url=url;	
	  	}
	  }
	  	
#endregion


		

		
		
		

	}
}
