/*
 * Created by SharpDevelop.
 * User: carleson
 * Date: 2013-06-19
 * Time: 09:33
 */
using System;
using System.Collections.Generic;

namespace SiteInfo
{
	/// <summary>
	/// Description of SiteLinks.
	/// </summary>
	public class SiteLinks
	{
		private SiteInfo _site;
		public List<Link> _links;
		
		public SiteLinks(SiteInfo site)
		{
			_site = site;
			_links = new List<Link>();
		}
		
#region Properties
		public bool Enabled
	  	{
		  	get
		  	{
		  		return _site.config.links.Enabled;
		  	}
		}
#endregion

#region Methods
		public List<Link> Get()
		{
			return _links;
		}
		
#endregion
	}
}
