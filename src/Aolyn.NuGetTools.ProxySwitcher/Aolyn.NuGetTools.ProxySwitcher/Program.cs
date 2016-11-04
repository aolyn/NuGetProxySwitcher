using System;
using System.Windows.Forms;

namespace Aolyn.NuGetTools.ProxySwitcher
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new FormProxySwitch());
		}
	}
}
