using UnityEngine;

public class Demo : MonoBehaviour 
{
	private string appKey;
	private bool interstitial = true;
	private bool video = false;

    private void Start()
    {
		//Simply call initialize method once, when app is starting
		appKey = "cdefd229902583f073a2d7da5fdbb26ef82f5cb72ba0c37b";
		Appodeal.initialize (appKey);  //initializing all Appodeal ads
		//Appodeal.initialize (appKey, Appodeal.INTERSTITIAL);  //initializing Appodeal with choosen ad type
	}

    private void OnGUI()
    {
    
		if (Appodeal.isLoaded (Appodeal.INTERSTITIAL)) { //checking interstitial availability
			if (GUI.Button(new Rect(Screen.width / 10, 100, Screen.width * 8/10, Screen.height / 15), "Interstitial")) { //if interstitial available, show button

				//showing appodeal INTERSTITIAL
				Appodeal.show (Appodeal.INTERSTITIAL);
			
			}
		}

		if (Appodeal.isLoaded (Appodeal.VIDEO)) { //checking video availability
			if (GUI.Button(new Rect(Screen.width / 10, 200, Screen.width * 8/10, Screen.height / 15), "Video")) { //if video available, show button
				
				//showing appodeal Video
				Appodeal.show (Appodeal.VIDEO); 
				
			}
		}

		if (Appodeal.isLoaded (Appodeal.ANY)) { //checking availability
			if (GUI.Button(new Rect(Screen.width / 10, 300, Screen.width * 8/10, Screen.height / 15), "Show Any")) { //if available, show button
				
				//showing appodeal ads (showing video first if available)
				Appodeal.show (Appodeal.ANY); 
				
			}
		}

		if (GUI.Button(new Rect(Screen.width / 10, 400, Screen.width * 8/10, Screen.height / 15), "Show Banner")) {
			
			//show banner
			Appodeal.show (Appodeal.BANNER_BOTTOM); 
			
		}

		if (GUI.Button(new Rect(Screen.width / 10, 500, Screen.width * 8/10, Screen.height / 15), "Hide Banner")) { 
			
			//hide banner
			Appodeal.hide (Appodeal.BANNER); 
			
		}

	}
	
}