using UnityEngine;
using System.Collections;

public class XMPS_360 : MonoBehaviour {

	public Texture Close;
	
	void OnGUI()
	{
		Screen.lockCursor = false;
			if (GUI.Button(new Rect ((float)(Screen.width-50),(float)(Screen.height*0),50f,50f), Close))
			{
				//Application.LoadLevel("ModifiedDay");
				Application.LoadLevel("ModifiedDay");
			}
	}
}