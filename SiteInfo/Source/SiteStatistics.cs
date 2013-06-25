/*
 * Created by SharpDevelop.
 * User: Carleson
 * Date: 2013-06-18
 * Time: 10:19
 */
using System;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
namespace SiteInfo
{
	/// <summary>
	/// Description of SiteStatistics.
	/// </summary>
	public class SiteStatistics
	{
		private SiteInfo _site;
			
		public string name {get;set;}
		
		public SiteStatistics(SiteInfo site)
		{
			_site = site;
		}		
		
#region Properties
		public bool Enabled
	  	{
		  	get
		  	{
		  		return _site.config.statistics.Enabled;
		  	}
		}
#endregion

#region Methods
		public string Get()
		{
			string statLengh = _site.Source.Length.ToString();
			
			StringBuilder sb = new StringBuilder();
			
			sb.Append(string.Format("Lenght data:{0}",statLengh));
			sb.AppendLine();
			sb.AppendLine(string.Format("Size data:{0} bytes",GetSizeInBytes(_site.Source)));
			
			//Word count section
			sb.AppendLine(string.Format("links:{0}",WordCount("<a href=", _site.Source)));
			sb.AppendLine(string.Format(".png-files:{0}",WordCount(".png", _site.Source)));
			sb.AppendLine(string.Format(".jpg-files:{0}",WordCount(".jpg", _site.Source)));
			sb.AppendLine(string.Format("Comments:{0}",WordCount("<!--", _site.Source)));

			
			return sb.ToString();
		}
		
		/// <summary>
		/// Count a specified word from aa textblock
		/// </summary>
		/// <param name="word"></param>
		/// <param name="text"></param>
		/// <returns></returns>
		private int WordCount(string word, string text)
		{
			int pos = 0;
			int count = 0;
			pos = text.IndexOf(word);
			while (pos != -1 && text.Length >= pos)
			{
				count++;
				pos = _site.Source.IndexOf(word,pos+1);
			}
			return count;
		}
		

		/// <summary>
		/// Calculates the true size of a string, in bytes
		/// </summary>
		/// <param name="input">String to get the size of</param>
		/// <returns></returns>
		public int GetSizeInBytes(string input)
		{
			//X = (8 + 4 + 2 + (2 * LEN)) + 4 - 1) / 4 * 4
			int size = (8 + 4 + 2 + (2 * input.Length)) + 4 - 1; // / 4 * 4;
			size = size/4 * 4;
			
			return size;
		}
		
#endregion

	}
}
