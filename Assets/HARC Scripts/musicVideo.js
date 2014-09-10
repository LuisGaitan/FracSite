@script RequireComponent(AudioSource)
//start doubleClickStart as a float so no ambiguity to the compiler
var doubleClickStart : float = -1.0;
//EDIT TO DISABLE MOUSE CLICKS FOR A TIME AFTER DOUBLE CLICK
var disableClicks = false;
//END EDIT


var blue = false;
var target;
var clicked = false;
var title : String = "An Object";
var description : String = "Enter description here.";
var width : String = "Width goes here.";
var height : String = "Height goes here.";
//buttons and textures



var closeBtn : Texture;
var closeStyle : GUIStyle;

var titleFont : GUIStyle;
var menuFont : GUIStyle;
var labelFont : GUIStyle;
var menuBackground : Texture;

var objectImage : Texture;
var objectImage1 : Texture;
var objectImage2 : Texture;
var objectImage3 : Texture;
var objectImage4 : Texture;
var objectImage5 : Texture;
var objectImage6 : Texture;
var objectImageTemp : Texture;
var index : int;
function OnGUI () {
		
	
	if(clicked)
	{
	if(!audio.isPlaying)
		audio.Play();

	
	 globalVar.menuUp = true;
	Screen.lockCursor=false;
		   //background of menu
			GUI.DrawTexture(Rect(0,0,Screen.width,Screen.height), menuBackground, ScaleMode.StretchToFill);

		   
		    //object image
//InvokeRepeating("ShowVid",2.0,4.0)
		 GUI.DrawTexture(Rect(480.0/1280.0*Screen.width,100.0/720.0*Screen.height,640.0/1280.0*Screen.width,480.0/720.0*Screen.height), objectImage, ScaleMode.StretchToFill);

		   
		   
		   
		   
		    //title text
		  //  GUI.Label (Rect (180, 130, 415, 200), title, titleFont);
			
			//description text
			//GUI.Label (Rect (190, 570, 415, 200), ""+audio.isPlaying);
			
			
			//Width (X-axis) label
			/*GUI.Label (Rect (380, 520, 415, 200), width, labelFont);
			
			//Height (y-axis) label
			GUI.Label (Rect (626, 300, 415, 200), height, labelFont);
			*/
			
		  
		      
			
			//to close menu
			if(GUI.Button(Rect(1210.0/1280.0*Screen.width,5/720.0*Screen.height,60.0/1280.0*Screen.width,60.0/720.0*Screen.height),closeBtn, closeStyle))
			{	
			if(audio.isPlaying)
		audio.Stop();

			  clicked = false;
			  
			  globalVar.menuUp = false;
			  
			}
			
						
showVid();
			


			
			
	
		}
}

function showVid()
{

}



function OnMouseUp()
{
    //EDIT TO DISABLE MOUSE CLICKS FOR A TIME AFTER DOUBLE CLICK
    if (disableClicks)
        return;
    //END EDIT

    //make sure doubleClickStart isn't negative, that'll break things
    if (doubleClickStart > 0 && (Time.time - doubleClickStart) < 0.4)
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
function lockClicks()
{
    disableClicks = true;
    yield WaitForSeconds(0.4);
    disableClicks = false;
}
//END EDIT

function OnDoubleClick()
{   
print(globalVar.menuUp);
if(!globalVar.menuUp)
{
clicked = true;
}
print("Menu up.");


  
   /* target = transform.Find("mySphere");	
		if(!blue)
		{
		target.renderer.material.color = Color.blue;
		blue = true;
		}
		else
		{
			target.renderer.material.color = Color.red;
			blue = false;
		}*/    
}