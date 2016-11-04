using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace Aolyn.NuGetTools.ProxySwitcher
{
	public partial class FormProxySwitch : Form
	{
		public FormProxySwitch()
		{
			InitializeComponent();
		}

		private void lsbProxyList_DoubleClick(object sender, EventArgs e)
		{
			var proxyAddr = lsbProxyList.SelectedItem as string;

			SetProxy(proxyAddr);

			chkUseProxy.Checked = true;
			txtProxyAddress.Text = proxyAddr;
		}

		private static void SetProxy(string proxyAddr)
		{
			var configFile = GetConfigPath();
			var doc = new XmlDocument();
			doc.Load(configFile);
			if (doc.DocumentElement == null)
				return;

			var configNode = doc.DocumentElement["config"];
			if (configNode == null)
			{
				configNode = doc.CreateElement("config");
				doc.DocumentElement.AppendChild(configNode);
			}

			var httpProxyNode = configNode.SelectSingleNode("add[@key='http_proxy']");
			if (httpProxyNode == null)
			{
				httpProxyNode = doc.CreateElement("add");
				configNode.AppendChild(httpProxyNode);

				var keyAttr = doc.CreateAttribute("key");
				keyAttr.Value = "http_proxy";
				httpProxyNode.Attributes.Append(keyAttr);
			}

			if (httpProxyNode.Attributes["value"] == null)
			{
				var valueAttr = doc.CreateAttribute("value");
				httpProxyNode.Attributes.Append(valueAttr);
				valueAttr.Value = proxyAddr;
			}
			else
			{
				httpProxyNode.Attributes["value"].Value = proxyAddr;
			}

			doc.Save(configFile);
		}

		private static void RemoveProxy()
		{
			var configFile = GetConfigPath();
			var doc = new XmlDocument();
			doc.Load(configFile);

			var httpProxyNode = doc.DocumentElement.SelectSingleNode("config/add[@key='http_proxy']");
			httpProxyNode?.ParentNode.RemoveChild(httpProxyNode);

			doc.Save(configFile);
		}

		private void FormProxySwitch_Load(object sender, EventArgs e)
		{
			var file = "ProxyList.xml";

			using (var fs = File.OpenRead(file))
			{
				try
				{
					var ser = new XmlSerializer(typeof(string[]));
					var proxyList = ser.Deserialize(fs) as string[];
					if (proxyList != null)
					{
						lsbProxyList.Items.AddRange(proxyList);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(@"Read ProxyList.xml error: " + ex);
				}
			}

			//var file = "ProxyList.xml";
			//var list = new[]
			//{
			//	"a",
			//	"b"
			//};

			//var ser = new XmlSerializer(typeof(string[]));
			//var ms = new MemoryStream();
			//ser.Serialize(ms, list);
			//var str = Encoding.UTF8.GetString(ms.ToArray());

			var configFile = GetConfigPath();
			if (!File.Exists(configFile))
			{
				MessageBox.Show(configFile + " not exist");
				Close();
			}
			txtConfigFile.Text = configFile;

			var doc = new XmlDocument();
			doc.Load(configFile);
			var configNode = doc.DocumentElement["config"];
			var httpProxyNode = configNode?.SelectSingleNode("add[@key='http_proxy']");
			if (httpProxyNode?.Attributes["value"] != null)
			{
				lsbProxyList.Items.Add(httpProxyNode.Attributes["value"].Value);
				txtProxyAddress.Text = httpProxyNode.Attributes["value"].Value;
				chkUseProxy.Checked = true;
			}

		}

		private static string GetConfigPath()
		{
			var path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
			var configFile = Path.Combine(path, @"AppData\Roaming\NuGet\NuGet.Config");
			return configFile;
		}

		private void chkUseProxy_CheckedChanged(object sender, EventArgs e)
		{
		}

		private void chkUseProxy_Click(object sender, EventArgs e)
		{
			if (chkUseProxy.Checked == false)
			{
				RemoveProxy();
				chkUseProxy.Checked = false;
			}
			else
			{
				SetProxy(txtProxyAddress.Text);
			}

		}
	}
}
