﻿using System;
using Microsoft.Win32;

namespace MD.RemoteDesktopPortChanger
{
	public class RegistryHelpers
	{
		public static RegistryKey GetRegistryKey()
		{
			return GetRegistryKey(null);
		}

		public static RegistryKey GetRegistryKey(string keyPath)
		{
			RegistryKey localMachineRegistry = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32);
			return string.IsNullOrEmpty(keyPath) ? localMachineRegistry : localMachineRegistry.OpenSubKey(keyPath, true);
		}

		public static object GetRegistryValue(string keyPath, string keyName)
		{
			RegistryKey registry = GetRegistryKey(keyPath);
			return registry.GetValue(keyName);
		}

		public static void SetRegistryValue(string keyPath, string keyName, string value)
		{
			RegistryKey registry = GetRegistryKey(keyPath);
			registry.SetValue(keyName, value, RegistryValueKind.DWord);
		}
	}
}
