/*
 * Created by SharpDevelop.
 * User: carleson
 * Date: 2013-06-24
 * Time: 11:28
 */
using System;
using System.Configuration;
using System.Windows.Forms;

namespace SiteInfo.Config
{
	/// <summary>
	/// Description of Links.
	/// </summary>
	public class Links
	{
		private bool _enable_links = false;
		
		public Links()
		{
			try
			{
				var x = ConfigurationManager.AppSettings["enable_links"];	
				_enable_links = bool.Parse(ConfigurationManager.AppSettings["enable_links"]);	
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
			
		}
		
		public bool Enabled
	  	{
		  	get
		  	{
		  		return this._enable_links;
		  	}
		  	set
		  	{
		  		_enable_links = value;
//		  		ConfigurationManager.AppSettings["enable_links"] = value.ToString();
		  		ConfigurationManager.AppSettings.Set("enable_links",value.ToString());
		  		
		  	}
	  	}
				
	}
}
