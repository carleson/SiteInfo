/*
 * Created by SharpDevelop.
 * User: Carleson
 * Date: 2013-06-18
 * Time: 11:11
 */
using System;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace SiteInfo
{
	/// <summary>
	/// Description of Util.
	/// </summary>
	public class Util
	{
		
		private ToolStripStatusLabel _status;
		
		public Util()
		{
		}
		
		public void InitStatus(ToolStripStatusLabel status)
		{
			_status=status;
		}
				
		public void CopyTextFromTextBox(TextBox txt)
		{
			try
			{
				if (txt.Text.Length == 0) return;
				
				txt.SelectAll();
				Clipboard.SetText(txt.Text);
				
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}	
		}
		
//		public void SetStatus(string text)
//		{
//			_status.Text=text;
//		}

		/// <summary>
		/// Method to save a given string into a file
		/// </summary>
		/// <param name="text"></param>
		public void SaveStringToFile(string text)
		{
			string _filename = "SiteInfo.html";
			string _path = Directory.GetCurrentDirectory();
			
			try
			{
				SaveFileDialog saveFileDialog = new SaveFileDialog();
				
				saveFileDialog.FileName=_filename;
				saveFileDialog.Filter="html files (*.html)|*.html|All files (*.*)|*.*" ;
				saveFileDialog.FilterIndex = 1 ;
				saveFileDialog.InitialDirectory=_path;
				saveFileDialog.ShowDialog();
				
				System.IO.File.WriteAllText(@saveFileDialog.FileName, text);
			}
			
			catch (Exception ex)
			{
			    MessageBox.Show(ex.Message);
			}
		}
		
		/// <summary>
		/// Metod to load filecontent into a specified textbox
		/// </summary>
		/// <param name="textbox"></param>
		/// <returns></returns>
		public string LoadFileToTextbox(TextBox textbox)
		{

			try
			{
				OpenFileDialog openFileDialog1 = new OpenFileDialog();
				
				openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
				openFileDialog1.Filter = "html files (*.html)|*.html|All files (*.*)|*.*" ;
				openFileDialog1.FilterIndex = 1;
				openFileDialog1.Multiselect=false;
				openFileDialog1.RestoreDirectory = true ;
			
				if(openFileDialog1.ShowDialog() == DialogResult.OK)
				{
					string text = File.ReadAllText(openFileDialog1.FileName,Encoding.Default);
					textbox.Text= text;
					return openFileDialog1.FileName;
				}
				
				return string.Empty;
			}
			catch (Exception ex)
			{
			    MessageBox.Show(ex.Message);
			    return string.Empty;
			}
		}
			
		public List<Link> GetLinks(string text)
		{
			int startpos = 0;
			int endpos = 0;
			
			try
			{
				List<Link> list = new List<Link>();
				Link _link;
				
				while (startpos != -1 && text.Length >= startpos)
				{
					startpos = text.IndexOf("<a href=",startpos+1);
					
					//Found be beginning of an URL
					if (startpos != -1)
					{
						endpos = text.IndexOf("</a>",startpos+1);
						
						if (endpos != -1) 
						{
							_link = new Link(text.Substring(startpos,(endpos-startpos)+4));
							//string url = text.Substring(startpos,(endpos-startpos)+4);
							list.Add(_link);
						}
						
						startpos++;	                           
					}
				}
							
			return list;
				
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
				return null;
			}
		}
	}
}
