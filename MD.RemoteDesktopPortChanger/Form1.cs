using System;
using System.Windows.Forms;

namespace MD.RemoteDesktopPortChanger
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			
			//
			labelMessage.Text = string.Empty;
		}

		const string KeyPath = @"SYSTEM\CurrentControlSet\Control\Terminal Server\WinStations\RDP-Tcp";
		const string KeyName = "PortNumber";

		private void buttonChange_Click(object sender, EventArgs e)
		{
			string portString = maskedTextBoxPortNumber.Text.Trim();
			int port;
			if (!int.TryParse(portString, out port))
			{
				MessageBox.Show("Port number is wrong !");
				return;	
			}

			object remoteDesktopRegistryKey = RegistryHelpers.GetRegistryValue(KeyPath, KeyName);
			if (remoteDesktopRegistryKey == null)
			{
				labelMessage.Text = "nothing found";
				return;
			}

			RegistryHelpers.SetRegistryValue(KeyPath, KeyName, port.ToString());
			labelMessage.Text = "Value Changed Successfully";
		}

		private void buttonGetCurrentValue_Click(object sender, EventArgs e)
		{
			object remoteDesktopRegistryKey = RegistryHelpers.GetRegistryValue(KeyPath, KeyName);
			if (remoteDesktopRegistryKey == null)
			{
				labelMessage.Text = "nothing found";
				return;
			}
			textBoxCurrentValue.Text = RegistryHelpers.GetRegistryValue(KeyPath, KeyName).ToString();
		}


	}
}
