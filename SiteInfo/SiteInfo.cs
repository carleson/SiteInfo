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
		private const string Version="0.3.2";
		
		private string _html;
		private string _url;
		
		public Util util;
		
		public SiteInfo()
		{
			util = new Util();
		}
		
		public string GetVersion()
		{
			return Version;
		}
		
		
		
		public string GetSource()
		{
			return _html;
		}
	}
}
