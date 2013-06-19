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
		private Util _util;
		private SiteStatistics _statistics;
		
		public SiteInfo(string htmlOutput)
		{
			_html = htmlOutput;
			
			_util = new Util();
			_statistics = new SiteStatistics(_html);
		}
	
#region Properies
	  public Util util
	    {
			get
			{
			    return this._util;
			}
	    }
	  
	  public SiteStatistics statistics
	  {
	  	get
	  	{
	  		return this._statistics;
	  	}
	  }
	  
	  public string Source
		{
			get
			{
				return this._html;
			}
			set
			{
				this._html=value;
			}
		}
	  		
	  	public string Version
		{
	  		get
	  		{
	  			return _version;
	  		}
		}
	  	
#endregion


		

		
		
		

	}
}
