using UnityEngine;
using System.Collections;

public class XMPS_Menu : MonoBehaviour {
	
	public Texture Close;
	
	void OnGUI()
	{
			if (GUI.Button(new Rect ((float)(Screen.width-50),(float)(Screen.height*0),50f,50f), Close))
			{
				Application.LoadLevel(PlayerPrefs.GetString("Current"));
			}
	}
}
