using System;
using AppodealAds.Common;

namespace AppodealAds.Api
{
	// Event that occurs when an video has been completed.
	public class AdRewardUserEventArgs : EventArgs
	{
		public int Amount { get; set; }
	}
}