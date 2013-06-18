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
				SetStatus("added source to clipboard");	
				
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}	
		}
		
		public void SetStatus(string text)
		{
			_status.Text=text;
		}

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
		public string LoadFile(TextBox textbox)
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
					SetStatus(string.Format("Loaded:{0}",openFileDialog1.FileName));
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
			
	}
}
