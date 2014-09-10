using UnityEngine;
using System.Collections;

public class OtherHotSpot : MonoBehaviour {
	
	

	bool boolean=false; //Is the hotspot active?
public string Name ="The name of the object";//will be displayed in legend
public string text ="This will show up when you hover over the point.";//Text to display when hovered over
public Camera minimap;//the minimap camera
public GUIStyle textSettings;//GUIStyle for the text of the GUI
public bool gui=false;//are you displaying the gui?

void OnMouseEnter()
{
	gui=boolean;
	globalVars.legend_selected=gameObject;
}

void OnMouseExit()
{
	gui=false;
}

void OnGUI()
{
	if(gui&&Minimap.isLarge && globalVars.legend_selected == gameObject)
	{
		Vector3 screenPos=minimap.WorldToScreenPoint(transform.position);
		GUI.Label(new Rect((screenPos.x-200),Screen.height-screenPos.y,200,100),new GUIContent(text,""),textSettings);
	}
}

void Update()
{
	boolean=Minimap.isLarge;
	transform.localScale=boolean?(new Vector3(0.2f,0.001f,0.2f)):(new Vector3(0,0,0));
}
	
	
}
