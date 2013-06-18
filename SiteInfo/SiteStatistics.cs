/*
 * Created by SharpDevelop.
 * User: a491259
 * Date: 2013-06-18
 * Time: 10:19
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Text;

namespace SiteInfo
{
	/// <summary>
	/// Description of SiteStatistics.
	/// </summary>
	public class SiteStatistics
	{
		private string _htmlOutput;
		
		public SiteStatistics(string htmlOutput)
		{
			_htmlOutput = htmlOutput;
		}		
		
		public string Get()
		{
			string statLengh = _htmlOutput.Length.ToString();
			
			StringBuilder sb = new StringBuilder();
			
			sb.Append(string.Format("Lenght data:{0}",statLengh));
			sb.AppendLine();
			sb.AppendLine(string.Format("Size data:{0} bytes",GetSizeInBytes(_htmlOutput)));
			
			//Word count section
			sb.AppendLine(string.Format("links:{0}",WordCount("<a href=", _htmlOutput)));
			sb.AppendLine(string.Format(".png-files:{0}",WordCount(".png", _htmlOutput)));
			sb.AppendLine(string.Format(".jpg-files:{0}",WordCount(".jpg", _htmlOutput)));
			sb.AppendLine(string.Format("Comments:{0}",WordCount("<!--", _htmlOutput)));

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
				pos = _htmlOutput.IndexOf(word,pos+1);
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
		
	}
}
