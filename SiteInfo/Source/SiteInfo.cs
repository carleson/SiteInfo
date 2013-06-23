/*
 * Created by SharpDevelop.
 * User: Carleson
 * Date: 2013-06-18
 * Time: 10:40
 */

using System;

namespace SiteInfo
{
	/// <summary>
	/// Description of SiteInfo.
	/// </summary>
	public class SiteInfo
	{
		//Consts
		private const string _version="0.3.3";
		
		private string _html;
		private string _url;		
		private SiteStatistics _statistics;
		private SiteAnalytics _analytics;
		
		public SiteInfo(string url,string htmlOutput)
		{
			_html = htmlOutput;
			_url = url;
			_statistics = new SiteStatistics(_html);
			_analytics = new SiteAnalytics(this);
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
