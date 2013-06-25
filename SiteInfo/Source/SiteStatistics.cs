/*
 * Created by SharpDevelop.
 * User: Carleson
 * Date: 2013-06-18
 * Time: 10:19
 */
using System;
using System.Text;
using System.Linq;
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
			sb.AppendLine(string.Format("Words:{0}",WordCount()));
			sb.AppendLine(string.Format("Common words{0}",CommonWords()));
			//Word count section
			sb.AppendLine(string.Format("links:{0}",WordCount("<a href=")));
			sb.AppendLine(string.Format(".png-files:{0}",WordCount(".png")));
			sb.AppendLine(string.Format(".jpg-files:{0}",WordCount(".jpg")));
			sb.AppendLine(string.Format("Comments:{0}",WordCount("<!--")));

			
			return sb.ToString();
		}
		
		/// <summary>
		/// Count a specified word from aa textblock
		/// </summary>
		/// <param name="word"></param>
		/// <param name="text"></param>
		/// <returns></returns>
		private int WordCount(string word)
		{
			string text = _site.Source;
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
		

		private int WordCount()
		{
			string text = _site.Source;
			
			string[] words = text.Split(new string[] {" ", "\n", "\r"}, StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
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
		
		private string CommonWords()
		{
			string text = _site.Source;
			
			  // Number of words
            string[] words = text.Split(new string[] {" ", "\n", "\r"}, StringSplitOptions.RemoveEmptyEntries);
            //int numWords = words.Length;


            // Number of letters
//            int numLetters = 0;
//            foreach (char c in text)
//            {
//                if (char.IsLetter(c))
//                    numLetters ++;
//            }


            // Number of symbols
//            int numSymbols = 0;
//            foreach (char c in text)
//            {
//                if (char.IsPunctuation(c))
//                    numSymbols ++;
//            }


            // Most common words
            var dictionary = new Dictionary<string, int>(StringComparer.InvariantCultureIgnoreCase);

            foreach (string word in words)
            {
                if (dictionary.ContainsKey(word))
                    dictionary[word] = dictionary[word] + 1;
                else
                    dictionary[word] = 1;
            }

            var sortedDictionary = from item in dictionary
                              orderby item.Value descending
                              select item;

            string[] commonWords = new string[3];
            int count = 0;

            foreach (KeyValuePair<string, int> item in sortedDictionary.Take(3))
            {
                commonWords[count] = item.Key;
                count++;
            }

			 Console.WriteLine("Top three most common words: {0}, {1}, {2}", commonWords[0], commonWords[1], commonWords[2]);
			 string output = string.Format("Top three most common words: {0}, {1}, {2}", commonWords[0], commonWords[1], commonWords[2]);
			 return output;
		}
		
#endregion

	}
}
