using UnityEngine;
using System.Collections;
public class Minimap : MonoBehaviour {

//-------------------------//
//--variable declarations--//
//-------------------------//
public Transform player;//the player to be tracked
	 
public static bool isLarge=false;
public static bool debounce = false;//if it is enlarged or not, debounce for map enlargement
public float dTime=0;//time passed since debounce
public float height =20.0f;//how high the camera is above the player
public float smallFieldOfView =50;//small field of view
 public float largeFieldOfView =100;//large field of view
public float smallX =0.18f;//small view width
public float smallY =0.3f;//small view height
public float largeX=1f;//large view width
public float  largeY=1f;//large view height
GameObject[] stopParts;//the things to stop their chest
public GUIStyle style0, style1;//style for open
public GameObject hotspots;
public GameObject redSpots;
public GameObject legendary;
public bool firstRun = true;
public int X=0, Y=0, x0=0, y0=0;
GUISkin skin;

//private variables
	Vector2 scrollPosition = Vector2.zero; //for the scroll area
Rect window = new Rect(15,180,225,500);//window for legend

//-------------------------//
//--function declarations--//
//-------------------------//

//the list thingy
	
	
	
void legend(int windowID)
{
	GUILayout.BeginVertical(GUI.skin.GetStyle("box"));
	scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(200), GUILayout.Height(440));
	float num=0f;
	GUI.skin.button.fontSize = 12;
		
			
					
		
     foreach(Transform child in hotspots.transform)
	{
		GameObject obj=child.gameObject;
		num++;
		
		float widthRatio = Screen.width / 1920f;
		float heightRatio = Screen.height / 1200f;
		/*
		if(Application.platform == RuntimePlatform.WindowsWebPlayer)
		{
			if(GUILayout.Button(num+". "+child.GetComponent<OtherHotSpot>().Name))
			{
				globalVars.legend_selected=obj;
				Debug.Log ("Minimap.cs setting legend_selected to " + obj.name);
				obj.GetComponent<OtherHotSpot>().gui=true;
					Debug.Log("Test");
			}
		}
		else if(Application.platform == RuntimePlatform.OSXWebPlayer)
		{
			if(GUILayout.Button(num+". "+child.GetComponent<OtherHotSpot>().Name))
			{
				globalVars.legend_selected=obj;
				obj.GetComponent<OtherHotSpot>().gui=true;
					Debug.Log("Test");
			}
		}
		else if(Application.platform == RuntimePlatform.OSXPlayer)
		{
				
			float xx = (float) (window.left + 5 + 0.0f) * widthRatio;	
		 	float xy = (float) (Screen.width / 6.3 + 0.0f) * heightRatio;
				
			if(GUI.Button( new Rect(xx,(num * 25) - (num + 3), xy, 25), num+". "+child.GetComponent<OtherHotSpot>().Name) )
			{
				globalVars.legend_selected=obj;
				obj.GetComponent<OtherHotSpot>().gui=true;
					Debug.Log("Test");
			}
		}
		else if(Application.platform == RuntimePlatform.WindowsPlayer)*/
		{
				
			float xz = (float) (window.left + 5 + 0.0f) * widthRatio;	
		 	float yz = (float) (Screen.width / 6.3 + 0.0f) * heightRatio;
				//Debug.Log(window.xMin + " " +window.xMax);
			if(GUI.Button(new Rect(15,(num * 25) - (num + 3),170, 25),num+". "+child.GetComponent<OtherHotSpot>().Name))
			{
				globalVars.legend_selected=obj;
				obj.GetComponent<OtherHotSpot>().gui=true;
			}
		}
	}
	GUILayout.EndScrollView();
	GUILayout.EndVertical();
	GUI.DragWindow();
}

//runs when the script first compiles
void Start()
{
	
	camera.fieldOfView=isLarge?largeFieldOfView:smallFieldOfView;
	camera.rect=isLarge?(new Rect(1-largeX,1-largeY,largeX,largeY)):(new Rect(1-smallX,1-smallY,smallX,smallY));
	if(firstRun)
	{
		foreach(Transform t in hotspots.transform)
		{
			
				GameObject obj=t.gameObject;
				obj.SetActive(false);
		}
		
			foreach(Transform t in redSpots.transform)
			{
				
				GameObject obj=t.gameObject;
				obj.SetActive(false);
			}
		
		firstRun = false;
	}
}

//updates every frame
void Update() 
{
	
	if(debounce&&dTime<1)
		dTime+=0.1f;
	else
		if(debounce)
		{
			debounce=false;
			dTime=0f;
		}
	//checks for map open/close
	if(Input.GetButtonUp ("AndroidTVButtonX")&&!debounce && globalVars.minimapToggle == true)
	{
			if(isLarge)
			{
				toggleSpots(false);
				isLarge = false;
				globalVars.minimapActive = false;
			}
			else
			{
				isLarge = true;
				globalVars.minimapActive = true;
			}
		//isLarge=!isLarge;
		Screen.lockCursor=!isLarge;
		debounce=true;
	}	
		//doubleCheckThis!
		if (!globalVars.display)
		{
			camera.rect = new Rect(0,0,0,0);
		}
	else if (isLarge)
		{
			camera.rect = new Rect(1-largeX,1-largeY,largeX,largeY);
		}
		else
		{
			camera.rect = new Rect(1-smallX,1-smallY,smallX,smallY);
		}
		
	camera.rect=!globalVars.display?(new Rect(0,0,0,0)):(isLarge? (new Rect(1-largeX,1-largeY,largeX,largeY)): ( new Rect(1-smallX,1-smallY,smallX,smallY)));
	if(isLarge)
		{
			camera.fieldOfView = largeFieldOfView;
		}
		else
		{
			camera.fieldOfView = smallFieldOfView;
		}
	camera.fieldOfView=isLarge?largeFieldOfView:smallFieldOfView;
}
	
public void toggleSpots(bool toggle)
{
		foreach(Transform t in hotspots.transform)
			{	
				GameObject obj=t.gameObject;
				obj.SetActive(toggle);
			}
				
			foreach(Transform t in redSpots.transform)
			{		
				GameObject obj=t.gameObject;
			 	 obj.SetActive(toggle);
			}
}

//updates every frame, creates GUI's
void OnGUI()
{
	//spacebar GUI
	if(globalVars.display)
	{
		if(isLarge)
		{
			toggleSpots(true);				
			GUI.Label(new Rect((Screen.width-256)/2+34,Screen.height-32,256,32),"Spacebar to close",style0); //legend
			GUI.skin=skin;
			window=GUI.Window(0,window,legend,"Legend",GUI.skin.GetStyle("Window"));
			globalVars.minimapActive = true;
		}
			
		else
		{
		GUI.Label(new Rect((1-smallX)*Screen.width,(smallY)*Screen.height,smallX*Screen.width,0.05f*Screen.height),"",style1);
			globalVars.minimapActive = false;
		}
	}
}

}
