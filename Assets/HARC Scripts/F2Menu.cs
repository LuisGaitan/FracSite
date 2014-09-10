using UnityEngine;
using System.Collections;

public class F2Menu : MonoBehaviour {
	
	public Texture MenuBar, closeMenuBar, bottomBar, Options, emptyTexture, HelpScreen, HelpToggle, ToggleButton;
	public float debounceWait = 0.5f;
	
	
	public GUIStyle button0, button1, button2, button3, leftArrow, rightArrow, text, scrollBackground, scrollSelected;
	public GameObject p0, p1, painter, TheSun;
	
	public GameObject[] SpotLights;
	//private variables
	private bool selected = false, FullScreen, DisplayHelp;
	
	private int showCurrent = 0;
	private int currentlySelected =-1;
	
	private float debounceTime = 0.0f;
	private float volumeSlider = 0.0f;
	
	
	private int lastTip;
	//class used for arrow changing options
	public Material NightSky, DaySky;
	public Flare SunFlare;
	public bool HasCollided;
	public GameObject HotSpots;
	
	public GameObject lowerSkyPlane;
	public GameObject upperSkyPlane;
	public GameObject skyDome;
	
	public Material materialDayLower;
	public Material materialDayUpper;
	public Material materialNightLower;
	public Material materialNightUpper;
	public Material materialSkyDomeDay;
	public Material materialSkyDomeNight;
	
	/*
public GameObject lowerDome;
public GameObject upperDome;

public Material materialDayLower;
public Material materialDayUpper;
public Material materialNightLower;
public Material materialNightUpper;
*/	
	
	[System.Serializable]
	public class arrows
	{
		public int optionCount = 3;
		public GUIStyle option1, option2, option3;
		public bool backToBeginning;
		private int currentSelection =1;//1==low 2==medium 3==high
		
		//changes the current value
		public bool changeCurrent(bool val) //true==+1 false==-1
		{
			if(val)
			{
				if(currentSelection<optionCount)
				{
					currentSelection=++currentSelection;
					return true;
				}
				else
				{
				currentSelection=backToBeginning?1:currentSelection;
					return false;
				}
			}
			else
			{
				if(currentSelection>1)
				{
					currentSelection=--currentSelection;
					return true;
				}
				else
				{
				currentSelection=backToBeginning?optionCount:currentSelection;
					return false;
				}
			}
		}
		
		//sets the current value
		public void setCurrent(int num)
		{
			currentSelection=num;
		}
		
		//returns the picture
		public GUIStyle getPicture()
		{
			if(currentSelection==1)
				return option1;
			else
				if(currentSelection==2)
					return option2;
			else
				return option3;
		}
		
		//returns the option number
		public int getNumber()
		{
			return currentSelection;
		}
	}
	
	//class variables
	
	//Visuals
	public arrows GraphicsOptions = new arrows();
	public arrows ResolutionOptions = new arrows();
	//Day/Night
	public GUIStyle Day, Night;
	//Audio
	public arrows Mute = new arrows();
	
	//displays the options for the first button
	public void options0()
	{
		//graphics
		//GraphicsOptions.getPicture();
		GraphicsOptions.setCurrent(PlayerPrefs.GetInt("playerQuality",0)+1);
		GUI.Label(new Rect(215,42*(2)+58,256,21),GUIC("0"),GraphicsOptions.getPicture());
		if(GUI.Button(new Rect(320,42*(2)+58+42/8,8,14),GUIC("0"),leftArrow)&&GraphicsOptions.changeCurrent(false))
		{
			QualitySettings.DecreaseLevel();
		}
		if(GUI.Button(new Rect(320+130,42*(2)+58+42/8,8,42/4),GUIC("0"),rightArrow)&&GraphicsOptions.changeCurrent(true))
		{
			QualitySettings.IncreaseLevel();
		}
		//resolution
		GUI.Label(new Rect(215,42*(2)+58+42/2,256,42/2),GUIC("0"),ResolutionOptions.getPicture());
		if(GUI.Button(new Rect(320,42*(2)+58+42/8+42/2,8,42/4),GUIC("0"),leftArrow))
		{
			ResolutionOptions.changeCurrent(false);
			Screen.SetResolution(ResolutionOptions.getNumber()==1?1024:1280,ResolutionOptions.getNumber()==1?768:720,false);
		}
		if(GUI.Button(new Rect(320+130,42*(2)+58+42/8+42/2,8,42/4),GUIC("0"),rightArrow))
		{
			ResolutionOptions.changeCurrent(true);
			Screen.SetResolution(ResolutionOptions.getNumber()==1?1024:1280,ResolutionOptions.getNumber()==1?768:720,false);
		}
	}
	
	//displays options for second button
	public void options1()
	{
		
		//AudioListener a1 = this.gameObject.GetComponent<AudioListener>();
		//volumeSlider = a1.volume*100;	
		
		//Mute
		GUI.Label(new Rect(215,42*(3)+58,256,42/2),GUIC("1"),Mute.getPicture());
		if(GUI.Button(new Rect(320,42*(3)+58+42/12,8,42/4),GUIC("1"),leftArrow))
		{
			Mute.changeCurrent(false);
			AudioListener.pause=(Mute.getNumber()==2);
		}
		if(GUI.Button(new Rect(320+130,42*(3)+58+42/12,8,42/4),GUIC("1"),rightArrow))
		{
			Mute.changeCurrent(true);
			AudioListener.pause=(Mute.getNumber()==2);
		}
		//volume slider
		GUILayout.BeginArea(new Rect(215,42*(3)+58+42/3,256,42));
		GUILayout.Space(9);
		GUILayout.BeginHorizontal();
		volumeSlider=GUILayout.HorizontalSlider(volumeSlider,0.0f,100.0f,GUILayout.Width(256-35),GUILayout.Height(42));
		GUILayout.Box(Mathf.Round(volumeSlider).ToString());
		AudioListener.volume=volumeSlider/100;
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
	}
	
	//displays options for third button
	public void options2()
	{
		//day/night

//	if(GUI.Button(new Rect(215,42*(4)+58,256,42/2),GUIC("2"),Day))//&&Application.loadedLevelName!="ModifiedDay")
//	{
//		if(RenderSettings.skybox == NightSky)
//		{
//			for(var i = 0; i < SpotLights.Length; i++)
//			{
//				SpotLights[i].gameObject.SetActive(false);
//				//SpotLights[i].light.flare = null;
//				TheSun.gameObject.active = true;
//			}
//				foreach(Transform Son in painter.transform)
//				{
//					Son.gameObject.SetActive(true);
//				}
//				painter.gameObject.SetActive(true);
//			RenderSettings.skybox = DaySky;
//		}
//		selected = !selected;
//		debounceTime=Time.time;
//		lastTip=-1;
//		this.GetComponent<MouseLook>().isMoving=!selected;
//		p1.GetComponent<MouseLook>().isMoving=!selected;
//		this.GetComponent<CharacterMotor>().isMoving=!selected;
//		Screen.lockCursor=!selected;
//		showCurrent=0;
//	}
//	if(GUI.Button(new Rect(215,42*4+58+42/2,256,42/2),GUIC("2"),Night))//&&Application.loadedLevelName!="ModifiedNight")
//	{
//		if(RenderSettings.skybox == DaySky)
//		{
//			for(var j = 0; j < SpotLights.Length; j++)
//			{
//				SpotLights[j].gameObject.SetActive(true);
//				//SpotLights[i].light.flare = SunFlare;
//				TheSun.gameObject.SetActive(false);
//			}
//			foreach(Transform Child in painter.transform)
//				{
//					Child.gameObject.SetActive(false);
//				}
//				painter.gameObject.SetActive(false);
//			RenderSettings.skybox = NightSky;
//		}
//		selected = !selected;
//		debounceTime=Time.time;
//		lastTip=-1;
//		this.GetComponent<MouseLook>().isMoving=!selected;
//		p1.GetComponent<MouseLook>().isMoving=!selected;
//		this.GetComponent<CharacterMotor>().isMoving=!selected;
//		Screen.lockCursor=!selected;
//		showCurrent=0;
//	}

		
		if(GUI.Button(new Rect(215,42*(4)+58,256,42/2),GUIC("2"),Day))//&&Application.loadedLevelName!="ModifiedDay")
		{
//			//			lowerDome.renderer.material = materialDayLower;
//			//			upperDome.renderer.material = materialDayUpper;
//			lowerSkyPlane.renderer.material = materialDayLower;
//			upperSkyPlane.renderer.material = materialDayUpper;
//			skyDome.renderer.material = materialSkyDomeDay;
			RenderSettings.skybox = DaySky;
			Debug.Log ("it is now Day time");
		}
		
		if(GUI.Button(new Rect(215,42*4+58+42/2,256,42/2),GUIC("2"),Night))//&&Application.loadedLevelName!="ModifiedNight")
		{
//			//			lowerDome.renderer.material = materialNightLower;
//			//			upperDome.renderer.material = materialNightUpper;
//			lowerSkyPlane.renderer.material = materialNightLower;
//			upperSkyPlane.renderer.material = materialNightUpper;
//			skyDome.renderer.material = materialSkyDomeNight;
			RenderSettings.skybox = NightSky;
			Debug.Log ("it is now Night time");
		}
		
	}
	
	//returns a GUIContent with proper tooltip
	public GUIContent GUIC(string str)
	{
		return new GUIContent(emptyTexture,str);
	}
	
	//all gui stuff
	void OnGUI()
	{
		if(!Minimap.isLarge)
		{
			if(selected)
			{
				GUI.tooltip="-1";
				//buttons
				GUI.DrawTexture(new Rect(25,42+50,184,51),Options);//options
				if(showCurrent>=0)
					GUI.Label(new Rect(25,42*(2)+58,184,42),GUIC("0"),button0);//first button
				if(showCurrent>=1)
					GUI.Label(new Rect(25,42*(3)+58,184,42),GUIC("1"),button1);//second button
				if(showCurrent>=2)
					GUI.Label(new Rect(25,42*(4)+58,184,42),GUIC("2"),button2);//third button
				if(showCurrent>=3)
					if(GUI.Button(new Rect(25,42*(5)+57,184,42),GUIC("3"),button3))
				{//fourth button
					if(DisplayHelp == false)
					{
						DisplayHelp = true;
					}
					else
					{
						DisplayHelp = false;
					}
				}
				GUI.DrawTexture(new Rect(15,42*(6)+50,217,46),bottomBar);//bottom
				//bar
				GUI.Label(new Rect(199,42+54,16,42*(showCurrent+2)+4),GUIC(""+lastTip),scrollBackground);//bar behind
				if(lastTip>=0)
					GUI.Label(new Rect(199,42*(2+lastTip)+(lastTip==3?53:54),16,54),GUIC(""+lastTip),scrollSelected);//selection bar
				//display submenus
				if(lastTip==0)
					options0();
				else
					if(lastTip==1)
						options1();
				else
					if(lastTip==2)
						options2();
				//check what is being hovered
				currentlySelected=-1;
				if(System.Int32.Parse(GUI.tooltip) != null)
				{
					currentlySelected=System.Int32.Parse(GUI.tooltip);
				lastTip=currentlySelected>=0?currentlySelected:lastTip;
				}
			}
			//draw menu
			if(DisplayHelp == true)
			{
				GUI.DrawTexture( new Rect(15,15,Screen.width - 30,Screen.height - 30),HelpScreen);
				if(GUI.Button( new Rect( Screen.width - 50, 15, 25, 25),""))
				{
					DisplayHelp = false;
				}
				GUI.DrawTexture( new Rect( Screen.width - 50, 15, 25, 25),HelpToggle);
			}
			GUI.DrawTexture(new Rect(0,0,251,128),selected?closeMenuBar:MenuBar);//menu at top
			GUI.Label (new Rect(Screen.width - (ToggleButton.width * 0.9f),Screen.height - ToggleButton.height, ToggleButton.width, ToggleButton.height),ToggleButton);
			//GUI.Label(Rect(200,0,200,100),"Press Enter/Return",text);
		}
	}
	
	//updates every frame
	void Update()
	{
		if(!Screen.lockCursor)
		{
			if(HotSpots.transform.localScale == new Vector3(0,0,0) || !HotSpots.activeSelf)//if(!Minimap.isLarge && !selected && !globalVars.menuUp)
			{
				if(Input.GetMouseButtonUp(0) && globalVars.menuUp == false && selected == false)
				{
					Screen.lockCursor = true;
				}
			}
			else{
				Screen.lockCursor=false;
			}
		}
		if(Input.GetButtonUp ("AndroidTVButtonY")&&(Time.time-debounceTime)>=debounceWait&&!Minimap.isLarge)
		{
			selected=!selected;
			debounceTime=Time.time;
			lastTip=-1;
			this.GetComponent<MouseLook>().isMoving=!selected;
			p1.GetComponent<MouseLook>().isMoving=!selected;
			this.GetComponent<CharacterMotor>().isMoving=!selected;
			Screen.lockCursor=!selected;
			showCurrent=0;
		}
		if(selected)
			showCurrent=3;
		if(Input.GetKeyUp(KeyCode.F))
		{
			//Application.ExternalCall("fullScreen");
			Screen.SetResolution(Screen.currentResolution.width,Screen.currentResolution.height,FullScreen,Screen.currentResolution.refreshRate);
			FullScreen = !FullScreen;
			//FullScreen = true;
		}
	}
	
	void Start()
	{
		RenderSettings.skybox = DaySky;
	}
	
	public void CloseMenu()
	{
		selected=!selected;
		debounceTime=Time.time;
		lastTip=-1;
		this.GetComponent<MouseLook>().isMoving=!selected;
		p1.GetComponent<MouseLook>().isMoving=!selected;
		this.GetComponent<CharacterMotor>().isMoving=!selected;
		Screen.lockCursor=!selected;
		showCurrent=0;
	}
	void OnTriggerEnter(Collider Other)
	{
		if(Other.gameObject.name == "SignForLevelThree")
		{
			HasCollided = true;
		}
	}
}