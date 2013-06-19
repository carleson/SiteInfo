/*
 * Created by SharpDevelop.
 * User: Carleson
 * Date: 2013-06-19
 * Time: 09:28
 */
using System;

namespace SiteInfo
{
	/// <summary>
	/// Description of Link.
	/// </summary>
	public class Link
	{
		private string _value;
		
		public Link(string lvalue)
		{
			_value=lvalue;
		}
		
		public string Value
        {
            get 
            {
                return _value;
            }
            set { _value = Value; }
        }
	}
}
