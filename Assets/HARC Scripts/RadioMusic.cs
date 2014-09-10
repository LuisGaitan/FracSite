//Script created by: David Crawley

using UnityEngine;
using System.Collections;

public class RadioMusic : MonoBehaviour {
	
	//Public variables
	public AudioClip[] songList;
	public Texture menuBackground;
	public Texture closeBtn;
	public GUIStyle closeStyle;
	public int width;
	public int xOffset;
	public int yOffset;
	
	//Private variables
	private bool clicked = false;
	private int currentSong = -1;
	private int height; //Private variable since height will be determined by number of songs
	
	void Start () {
		//print(Screen.width);
		height = 100 + (songList.Length * 50);
		//width = (width * (1920))/Screen.width;
		//yOffset = yOffset*1200/Screen.height;
		//xOffset = xOffset*1920/Screen.width;
	}
	
	void OnGUI () {
		if (clicked)
		{
			globalVars.menuUp = true;
			Screen.lockCursor = false;
			
			//Draws background
			GUI.DrawTexture(new Rect(xOffset,yOffset,width,height), menuBackground, ScaleMode.StretchToFill);
			
			var closeBtnWidth = 60.0f/1920*Screen.width;
			var closeBtnHeight = 60.0f/1200*Screen.height;
			//Draws close button
			if(GUI.Button(new Rect(xOffset + width - closeBtnWidth, yOffset, closeBtnWidth, closeBtnHeight), closeBtn, closeStyle))
			{
				clicked = false;
				globalVars.menuUp = false;
			}
			
			
			
			
			var songBtnWidth = (width * 0.8f);//*1920/Screen.width;
			var songBtnHeight = 55.0f;///1200*Screen.height;
			//Sequentially draws buttons for the different songs based on size of list
			for (int i = 0; i <  songList.Length; i++)
			{
				if (GUI.Button(new Rect(xOffset + 20, yOffset + 70 + (i*50), songBtnWidth, songBtnHeight), songList[i].name ))
				{
					audio.Stop();
					audio.PlayOneShot(songList[i], 0.5f);
				}
			}
			
			//Draws stop button
			if(GUI.Button(new Rect(xOffset + 20, yOffset + 30, songBtnWidth / 2, closeBtnHeight / 2), "Stop"))
			{
				audio.Stop();
			}
		}
	}
	
	void OnMouseUp()
	{
		clicked = true;
		
		//Play-through Song Array
		/*
		++currentSong;
		if (currentSong >= songList.Length )
		{
			currentSong = -1;
		}
		
		if (currentSong != -1)
		{
			audio.Stop();
			audio.PlayOneShot(songList[currentSong], 0.5f);
			print (songList[currentSong]);
		}
		else
		{
			audio.Stop();
		}
		*/
	}
}
