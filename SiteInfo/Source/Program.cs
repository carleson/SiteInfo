/*
 * Created by SharpDevelop.
 * User: Carleson
 * Date: 2013-06-17
 * Time: 09:22
 */
using System;
using System.Windows.Forms;

namespace SiteInfo
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
		
	}
}
