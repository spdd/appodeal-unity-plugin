using System;
using AppodealAds.Common;

namespace AppodealAds.Api
{
	// Event that occurs when an ad fails to load.
	public class AdFailedToLoadEventArgs : EventArgs
	{
		public string Message { get; set; }
	}
}
