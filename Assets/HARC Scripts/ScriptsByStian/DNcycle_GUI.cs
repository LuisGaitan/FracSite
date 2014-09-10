using UnityEngine;
using System.Collections;

public class DNcycle_GUI : MonoBehaviour
{
	//Controls GUI location, size of GUI, and function for DAY & Night cycle Textures

	public GameObject lowerSkyPlane;
	public GameObject upperSkyPlane;
	public GameObject skyDome;

	public Material materialDayLower;
	public Material materialDayUpper;
	public Material materialNightLower;
	public Material materialNightUpper;
	public Material materialSkyDomeDay;
	public Material materialSkyDomeNight;
	

	void OnGUI()
	{
		GUI.Box (new Rect(10, 10, 100, 70), ""); //Box for button.

		//If clicked, switch Dome Material to "DAY"
		if(GUI.Button (new Rect(35,20, 50, 20), "Day")) //Day Button size & location.
		{
			//lowerDome.renderer.material = materialDayLower; //Texture Selection Slot
			//upperDome.renderer.material = materialDayUpper; //Texture Selection Slot
			lowerSkyPlane.renderer.material = materialDayLower;
			upperSkyPlane.renderer.material = materialDayUpper;
			skyDome.renderer.material = materialSkyDomeDay;
			Debug.Log ("it is now Day time");
		}

		/*	Obsolete
	 	if(GUI.Button (new Rect(20,50, 80, 20), "Night")) //Night Button size & location.
		{
			renderer.material.mainTexture = materialNight; ////Texture Selection Slot
		}
		*/

		//If clicked, switch Dome Material to "NIGHT"
		if(GUI.Button (new Rect(20,50, 80, 20), "Night")) //Night Button size & location.
		{
			//lowerDome.renderer.material = materialNightLower; //Texture Selection Slot
			//upperDome.renderer.material = materialNightUpper; //Texture Selection Slot
			lowerSkyPlane.renderer.material = materialNightLower;
			upperSkyPlane.renderer.material = materialNightUpper;
			skyDome.renderer.material = materialSkyDomeNight;
			Debug.Log ("it is now Night time");
		}
	}
}
