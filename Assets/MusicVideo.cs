using UnityEngine;
using System.Collections;

public class MusicVideo : MonoBehaviour {


	
	
//start doubleClickStart as a float so no ambiguity to the compiler
float doubleClickStart = -1.0f;
//EDIT TO DISABLE MOUSE CLICKS FOR A TIME AFTER DOUBLE CLICK
bool disableClicks = false;
//END EDIT


bool blue = false;
public bool target;
public bool clicked = false;
public string title = "An Object";
public string description = "Enter description here.";
public string width = "Width goes here.";
public string height = "Height goes here.";
//buttons and textures
public Texture closeBtn, menuBackground;
public Texture objectImage, objectImage1, objectImage2, objectImage3, objectImage4, objectImage5, objectImage6, objectImageTemp;
public GUIStyle menuFont, titleFont, labelFont, closeStyle;

void OnGUI () {
		
	
		print("GlobalVars sez menuUp = " + globalVars.menuUp);
	if(clicked)
	{
	if(!audio.isPlaying)
		audio.Play();

	
	 globalVars.menuUp = true;
		print("Clicked and the Menu is up");
	        Screen.lockCursor=false;
		   //background of menu
			GUI.DrawTexture(new Rect(0.0f,0.0f,(float) (Screen.width),(float) (Screen.height)), menuBackground, ScaleMode.StretchToFill);

		   
		    //object image
//InvokeRepeating("ShowVid",2.0,4.0)
		 GUI.DrawTexture(new Rect(480.0f/1280.0f*Screen.width,100.0f/720.0f*Screen.height,640.0f/1280.0f*Screen.width,480.0f/720.0f*Screen.height), objectImage, ScaleMode.StretchToFill);

		   
		   
		   
		   
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
			if(GUI.Button(new Rect(1210.0f/1280.0f*Screen.width,5.0f/720.0f*Screen.height,60.0f/1280.0f*Screen.width,60.0f/720.0f*Screen.height),closeBtn, closeStyle))
			{	
			if(audio.isPlaying)
		audio.Stop();

			  clicked = false;
				Screen.lockCursor = false;
			  
			  globalVars.menuUp = false;
			  
			}
			

			
			
	
		}
}




void OnMouseUp()
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
IEnumerator lockClicks()
{
    	disableClicks = true;
    yield return new WaitForSeconds(0.4f);
    disableClicks = false;
}
//END EDIT

void OnDoubleClick()
{   
print(globalVars.menuUp);
if(!globalVars.menuUp)
{
			print("Clicked is true");
            clicked = true;
		
}
	


  
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
	
	
	
	
	
	
	
	
	
}
