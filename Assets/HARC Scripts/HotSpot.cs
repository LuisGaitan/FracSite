using UnityEngine;
using System.Collections;

public class HotSpot : MonoBehaviour 
{
	public bool boolean = false;//Is the hotspot active?
	public string text = "This will show up when you hover over the point.";//Text to display when hovered over
	public GameObject minimap;//the minimap camera
	public Transform player;//the transform of the player
	public float height = 0.5f;//how much lower to put the object than the dots actual position
	public int offset = 5;//offset off of the mouse position for the GUI
	public GUIStyle textSettings;//GUIStyle for the text of the GUI
	public bool gui = false;//are you displaying the gui?

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		boolean = Minimap.isLarge;
		transform.localScale = boolean? new Vector3(0.03f,0.001f,0.03f): new Vector3(0,0,0);
	}
	void OnGUI()
	{
		if(gui)
		GUI.Label(new Rect(Input.mousePosition.x+offset,Screen.height-Input.mousePosition.y,200,60),new GUIContent(text,""),textSettings);
	}
	
	void OnMouseUpAsButton()
	{
		if(boolean)
		{
			TeleportTo();
			gui=false;
		}
	}
	
	public void TeleportTo()
	{
		player.position=transform.position+Vector3.down*height;
		player.transform.forward = -this.transform.forward;
		Minimap.isLarge = false;
		globalVars.miniCam.GetComponent<Minimap>() .toggleSpots(false);
		Screen.lockCursor = true;
	}
	
	void OnMouseEnter()
	{
		gui = Minimap.isLarge;
	}
	void OnMouseExit()
	{
		gui=false;
		boolean = false;//true;
	}
}
