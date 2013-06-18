/*
 * Created by SharpDevelop.
 * User: a491259
 * Date: 2013-06-18
 * Time: 10:40
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
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
		private const string Version="0.31";
		
		private string _html;
		private string _url;
		
		public SiteInfo()
		{
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
