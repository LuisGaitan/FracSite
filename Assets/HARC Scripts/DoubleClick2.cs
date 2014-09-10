using UnityEngine;
using System.Collections;

public class DoubleClick2 : MonoBehaviour {
	
	public float doubleClickStart  = -1.0f; //start doubleClickStart as a float so no ambiguity to the compiler
	public bool disableClicks = false; //EDIT TO DISABLE MOUSE CLICKS FOR A TIME AFTER DOUBLE CLICK
	
	
	public bool blue = false;
	public string target;
	public bool clicked = false;
	public string title = "An Object";
	public string description = "Enter description here.";
	
	//buttons and textures
	public	string level360, GlobeURL, PDFURL, videoURL, videoTitle;
	public Texture closeBtn, playBtn, pdfBtn, _360Btn, globeBtn, menuBackground, objectImage;
	public float imageHeightScale = 1f;
	public Texture MudText, exit, blank;
	public GUIStyle closeStyle, playStyle, pdfStyle, _360Style, globeStyle, titleFont, descriptionFont, menuFont;
//	public MovieTexture movie;	
	public GameObject p0, p1, mini; //used to turn off movement
//	public AudioSource movieSound;
	public GUISkin skin;	
	public pdfNode[] pdfs;
	private bool isOpen=false;
	private new Rect window = new Rect((Screen.width/2)-320,(Screen.height/2)-200, 640,400);
	private bool blnToggleState = false;
	private Vector2 scrollPosition = Vector2.zero;
	
	[System.Serializable]
	public class pdfNode
	{
		public string name, link;	
		bool selected;
		
		public  string getLink()
		{
			return link;
		}
		
		public  string getName()
		{
			return name;
		}
		
		public bool getBool()
		{
			return selected;
		}
		
		public  void change(bool boolean)
		{
			selected=boolean;
		}
	}

	void Start()
	{
		float xRatio = Screen.width / 1680f;
		float yRatio = Screen.height / 1050f;
		float ratio = (xRatio + yRatio) / 2;
		
		descriptionFont.fontSize = Mathf.RoundToInt (descriptionFont.fontSize * ratio);
		titleFont.fontSize = Mathf.RoundToInt (titleFont.fontSize * ratio);
	}
	
	void ListItem(pdfNode item)
	{
		GUILayout.BeginHorizontal();
		item.change(GUILayout.Toggle(item.getBool(), ""));
		GUILayout.Label(item.getName());
		GUILayout.EndHorizontal();
	}
	
//	void videoPlayer(int windowID)
//	{
//		GUILayout.BeginVertical(GUI.skin.GetStyle("box"));
//		GUILayout.Label(movie,GUILayout.Width(320),GUILayout.Height(90),GUILayout.ExpandWidth(true),GUILayout.ExpandHeight(true));
//		
//		if(movie != null)
//		{
//			if(GUILayout.Button(movie.isPlaying?"Pause":"Play"))
//			{
//				if(movie.isPlaying)
//				{
//					movie.Pause();
//					paused=true;
//				}
//				else
//				{
//					movie.Play();
//					paused=false;
//				}
//			}
//		}
//		GUI.contentColor = Color.white;
//		if(GUI.Button(new Rect(580,18,34,20),exit))//GUILayout.Button("Close"))
//		{
//			movieSound.Stop();
//			isMovie=false;
//		}
//		GUI.color = Color.green;
//		GUILayout.EndVertical();
//		GUI.DragWindow();
//	}
	
	void popup(int windowID)
	{
		GUILayout.BeginVertical(GUI.skin.GetStyle("box"));
		scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(160), GUILayout.Height(300));
		int numOpen = 0;
		foreach (pdfNode pdf in pdfs)
		{
			ListItem(pdf);
			if(pdf.getBool())
				numOpen++;
		}
		GUILayout.EndScrollView();
		if(GUILayout.Button(numOpen>0?"Open PDFs":"Close"))
		{
			foreach (pdfNode pdf in pdfs)
			{
				if(pdf.getBool())
				{
					Application.ExternalCall("openPdf",pdf.getLink());
					//Application.OpenURL(pdf.getLink());
					pdf.change(false);
				}
			}
			isOpen=false;
		}
		GUILayout.EndVertical();
		GUI.DragWindow();
	}
	
	//animation variables
	private bool anim = false;
	private float yPos =720.0f;
//	private bool isMovie=false;
	//private var movieTime:Number=0;
	private bool paused = false;
	
	void OnGUI() 
	{
		if(anim)
		{
			GUI.DrawTexture(new Rect(0,yPos,Screen.width,Screen.height),menuBackground,ScaleMode.StretchToFill);
			yPos -= (float)(720*Time.deltaTime*1.3);
			if(yPos <= 0)
			{
				yPos=0;
				anim=false;
			}
		}
		if(clicked && !anim)
		{
			
			//background of menu
			GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), menuBackground, ScaleMode.StretchToFill);
			
			globalVars.menuUp = true;
			
			//object image
			GUI.DrawTexture(new Rect(170.0f/1280.0f*Screen.width, (240.0f/720.0f*Screen.height) + (1f/imageHeightScale * 15), 425.0f/1280.0f*Screen.width, (210.0f/720.0f*Screen.height)* imageHeightScale), objectImage);
//			if(isMovie)
//			{
//				GUI.skin=skin;
//				window=GUI.Window(0,window,videoPlayer,videoTitle,GUI.skin.GetStyle("Window"));
//			}
			
			//title text
			if(this.gameObject.name == "ActiveMudSystem")
			{
				GUI.contentColor = Color.green;
				GUI.Label (new Rect ((float) (180.0/1280.0*Screen.width), (float) ( 130.0/690.0*Screen.height), (float) ( 415.0/1280.0*Screen.width), (float) (200.0/720.0*Screen.height)),"EFD Alternative:",titleFont);
				GUI.contentColor = Color.white;           
				GUI.Label (new Rect ((float) (180.0/1280.0f*Screen.width), (float)(130.0/600.0f*Screen.height),(float)(415.0/1280.0f*Screen.width), (float)(200.0/720.0f*Screen.height)),"Closed Loop Mud System", titleFont);
				
			}
			else if(this.gameObject.name == "CalicheRoadTies")
			{
				GUI.Label (new Rect ((float) (180.0f/1280.0f*Screen.width), (float) (130.0f/600.0f*Screen.height), (float) (415.0f/1280.0f*Screen.width), (float) (200.0/720.0f*Screen.height)),title, titleFont);
			}			
			else
			{
				GUI.Label (new Rect ((float) (180.0f/1280.0f*Screen.width), (float) (130.0f/690.0f*Screen.height), (float)( 415.0f/1280.0f*Screen.width) , (float) (200.0/720.0f*Screen.height)),title, titleFont);
			}
			
			//description text
			GUI.Label (new Rect ((float) (190.0f/1280.0f*Screen.width),(float) ( 570.0f/760.0f*Screen.height), (float) (415.0f/1280.0f*Screen.width), (float) (200.0f/720.0f*Screen.height)), description, descriptionFont);

			if(GUI.Button(new Rect((float) (828.0f/1280.0*Screen.width),(float) (262.0f/720.0*Screen.height),(float) (128.0f/1280.0*Screen.width),128.0f/720.0f*Screen.height),new GUIContent (globeBtn, "Globe Button"),globeStyle))
			{
				Application.ExternalCall("window.open('" + GlobeURL + "','_blank')");
			}
			if(GUI.Button(new Rect((float) (898.0f/1280.0f*Screen.width), (float) (251.0f/720.0f*Screen.height),(float) (197.0f/1280.0f*Screen.width),(float) (274.0f/720.0f*Screen.height)), new GUIContent (pdfBtn, "PDF Button"), pdfStyle))
			{	
				isOpen=!isOpen;
			}
			if(isOpen)
			{
				GUI.skin=skin;
				window=GUI.Window(0,window,popup,"Select PDF",GUI.skin.GetStyle("Window"));
			}
			if(GUI.Button(new Rect(688.0f/1280.0f*Screen.width, 260.0f/720.0f*Screen.height,180.0f/1280.0f*Screen.width,234.0f/720.0f*Screen.height),new GUIContent (_360Btn, "360 Button"), _360Style))
			{	
				globalVars.display=true;
				Application.LoadLevel(level360);
			}
			if(GUI.Button(new Rect(751.0f/1280.0f*Screen.width, 113.0f/720.0f*Screen.height,288.0f/1280.0f*Screen.width,155.0f/720.0f*Screen.height),new GUIContent (playBtn, "Play Button"), playStyle))
			{
				Application.ExternalCall("window.open('" + videoURL + "','_blank')");
			}
			
			//to close menu
			if(GUI.Button(new Rect(1096.0f/1280.0f*Screen.width,93.0f/720.0f*Screen.height,60.0f/1280.0f*Screen.width,60.0f/720.0f*Screen.height),new GUIContent(closeBtn,"close"), closeStyle))
			{	
				clicked = false;
				anim=false;
				yPos=720;
				globalVars.display=true;
				globalVars.menuUp = false;
				p0.GetComponent<MouseLook>().isMoving=true;
				p0.GetComponent<CharacterMotor>().isMoving=true;
				p1.GetComponent<MouseLook>().isMoving=true;
				Screen.lockCursor=true;
			}
			if(GUI.tooltip=="close")
			{
				GUI.Label(new Rect(Input.mousePosition.x+8,Screen.height-Input.mousePosition.y,50,50),"Close",closeStyle);
			}

			if(GUI.tooltip == "Globe Button" )
			{
				GUI.Label (new Rect (850.0f/1280.0f*Screen.width, 620.0f/720.0f*Screen.height, 415.0f/1280.0f*Screen.width, 200.0f/720.0f*Screen.height), "Web Resources", menuFont);
			}	
			
			if(GUI.tooltip == "Play Button" )
			{
				GUI.Label (new Rect (850.0f/1280.0f*Screen.width, 620.0f/720.0f*Screen.height, 415.0f/1280.0f*Screen.width, 200.0f/720.0f*Screen.height), "Play video", menuFont);
			}	
			
			if(GUI.tooltip == "360 Button" )
			{
				GUI.Label (new Rect (850.0f/1280.0f*Screen.width, 620.0f/720.0f*Screen.height, 415.0f/1280.0f*Screen.width, 200.0f/720.0f*Screen.height), "360 Degree View", menuFont);
			}
			
			if(GUI.tooltip == "PDF Button" )
			{
				GUI.Label (new Rect (850.0f/1280.0f*Screen.width, 620.0f/720.0f*Screen.height, 415.0f/1280.0f*Screen.width, 200.0f/720.0f*Screen.height), "View PDF", menuFont);
			}	
			
		}
//		else if(clicked && !anim)
//		{
//			GUI.DrawTexture(new Rect((float) (Screen.width / 2 + 640),0,Screen.width + Screen.width / 2,Screen.height),movie);
//		}
	}

	void Update()
	{
		if(GetComponent<Chest>().isHover == true)
		{
			if(Input.GetButtonDown ("AndroidTVButtonA"))
			{
				if(!Minimap.isLarge && globalVars.interactToggle == true)
				{
					globalVars.menuUp=true;
					clicked=true;
					globalVars.display=false;
					p0.GetComponent<MouseLook>().isMoving=false;
					p0.GetComponent<CharacterMotor>().isMoving=false;
					p1.GetComponent<MouseLook>().isMoving=false;
					Screen.lockCursor=false;
					anim=true;
				}
			}
			else if(Input.GetButtonUp ("AndroidTVButtonA"))
			{
				//EDIT TO DISABLE MOUSE CLICKS FOR A TIME AFTER DOUBLE CLICK
				if (disableClicks)
					return;
				//END EDIT
				
				//make sure doubleClickStart isn't negative, that'll break things
				if (doubleClickStart > 0 && (Time.time - doubleClickStart) < 0.4&&!Minimap.isLarge)
				{
					this.OnDoubleClick();
					doubleClickStart = -1;
					lockClicks();
				}
				else
				{
					doubleClickStart = Time.time;
				}
			}
			else if(Input.GetButtonUp ("AndroidTVButtonB"))
			{
				clicked = false;
				anim=false;
				yPos=720;
				globalVars.display=true;
				globalVars.menuUp = false;
				p0.GetComponent<MouseLook>().isMoving=true;
				p0.GetComponent<CharacterMotor>().isMoving=true;
				p1.GetComponent<MouseLook>().isMoving=true;
				Screen.lockCursor=true;
			}
		}
	}
	
	void OnMouseDown()
	{
		if(!Minimap.isLarge && globalVars.interactToggle == true)
		{
			globalVars.menuUp=true;
			clicked=true;
			globalVars.display=false;
			p0.GetComponent<MouseLook>().isMoving=false;
			p0.GetComponent<CharacterMotor>().isMoving=false;
			p1.GetComponent<MouseLook>().isMoving=false;
			Screen.lockCursor=false;
			anim=true;
		}
	}
	
	void OnMouseUp()
	{
		//EDIT TO DISABLE MOUSE CLICKS FOR A TIME AFTER DOUBLE CLICK
		if (disableClicks)
			return;
		//END EDIT
		
		//make sure doubleClickStart isn't negative, that'll break things
		if (doubleClickStart > 0 && (Time.time - doubleClickStart) < 0.4&&!Minimap.isLarge)
		{
			this.OnDoubleClick();
			doubleClickStart = -1;
			lockClicks();
		}
		else
		{
			doubleClickStart = Time.time;
		}
	}
	
	//EDIT TO DISABLE MOUSE CLICKS FOR A TIME AFTER DOUBLE CLICK
	IEnumerator lockClicks()
	{
		disableClicks = true;
		yield return new WaitForSeconds(0.4f);
		disableClicks = false;
	}
	//END EDIT
	
	void OnDoubleClick()
	{   
		if(!globalVars.menuUp && !Minimap.isLarge && globalVars.interactToggle == true)
		{
			clicked = true;
			globalVars.menuUp=true;
		}
	}
	
	
	
	
	
	
	
	
	
	
	
	
	
	
}
