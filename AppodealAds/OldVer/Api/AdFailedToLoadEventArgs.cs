using System;
using AppodealAds.Unity.Common;

namespace AppodealAds.Unity.Api
{
	// Event that occurs when an ad fails to load.
	public class AdFailedToLoadEventArgs : EventArgs
	{
		public string Message { get; set; }
	}
}
