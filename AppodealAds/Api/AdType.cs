namespace AppodealAds.Api
{
	// Types of banners.
	public enum AdType
	{
		INTERSTITIAL  = 1,
		VIDEO         = 2,
		BANNER        = 4,
		BANNER_BOTTOM = 8,
		BANNER_TOP    = 16,
		BANNER_CENTER = 32,
		ALL           = 127,
		ANY           = 127
	}
}

