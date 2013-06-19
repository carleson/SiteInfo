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
		private string _description;
		private string _url;
		
		public Link(string lvalue)
		{
			_value=lvalue;
			
			try
			{
			//Fetch the decription
			int start_pos = lvalue.IndexOf(">");
			int end_pos = lvalue.IndexOf("</a>");
			_description = lvalue.Substring(start_pos+1,end_pos-start_pos-1);
			
			//Fetch the url
			start_pos = lvalue.IndexOf("http://");
			end_pos = lvalue.IndexOf(">");
			
			if (start_pos !=-1 && end_pos !=-1)
			{
				_url = lvalue.Substring(start_pos,end_pos-start_pos-1);	
			}
						
			}
			catch(Exception ex)
			{
				System.Diagnostics.Debug.Print(ex.Message);
			}
			
		}
		
		public string Description
		{
			get
			{
				return _description;	
			}
		}

		public string Url
		{
			get
			{
				return _url;	
			}
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
