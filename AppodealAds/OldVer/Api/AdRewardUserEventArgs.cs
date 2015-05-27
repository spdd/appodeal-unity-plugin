using System;
using AppodealAds.Unity.Common;

namespace AppodealAds.Unity.Api
{
	// Event that occurs when an video has been completed.
	public class AdRewardUserEventArgs : EventArgs
	{
		public int Amount { get; set; }
	}
}