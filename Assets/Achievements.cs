using UnityEngine;
using System.Collections;

public class Achievements : MonoBehaviour {
	
	public bool achievementsEnabled;
	public achievement[] achievementList;
	public Texture closeBtn;
	public GUIStyle windowStyle;
	
	private bool windowIsUp;
	private int addingAchievement;
	private int displayedBadges;
	private bool completion = false;
	
	[System.Serializable]
	public class achievement
	{
		public string label;
		public bool isAchieved;
		public Texture badgeIcon;
		public Texture mainGraphic;
	}
	

	
	void OnGUI () 
	{
		float widthRatio = Screen.width / 1920f;
		float heightRatio = Screen.height / 1200f;
		
		if (globalVars.minimapActive == false)
		{
			if (windowIsUp)
			{
				Texture tempGraphic =  achievementList[addingAchievement].mainGraphic;
	
				float xPos = ( Screen.width / 2 )- (tempGraphic.width / 2) * widthRatio;
				float yPos = ( Screen.height / 2 )- (tempGraphic.height / 2) * heightRatio;

					GUI.DrawTexture(new Rect(xPos, yPos,( tempGraphic.width * widthRatio), (tempGraphic.height * heightRatio)), tempGraphic);
					if (GUI.Button(new Rect(xPos + ((( tempGraphic.width * widthRatio) / 1.35f) - closeBtn.width), yPos + ((tempGraphic.height * heightRatio) / 5), closeBtn.width * widthRatio, closeBtn.height * heightRatio), closeBtn))
					{
						ToggleWindow(false);
						achievementList[addingAchievement].isAchieved = true;
						
						//Global variable for the purpose of the blowout fail
						if (achievementList[addingAchievement].label == "Kaboom")
						{
							globalVars.kaboomAchieved = true;
						}
						
					}
			}
			else if ((globalVars.blowoutComplete == true) && (globalVars.questionsComplete == true) && (completion == false))
			{
				completion = true;
				AddAchievement("Completion");
			}
			else if (achievementsEnabled == false)
			{
				//Global variable for the purpose of the blowout fail
				if (achievementList[addingAchievement].label == "Kaboom")
				{
					globalVars.kaboomAchieved = true;
				}
			}
			
			int numBadges = 0;
			
			if (achievementsEnabled == true)
			{
				for( var i = 0; i < achievementList.Length; i++)
				{
					if (achievementList[i].isAchieved == true)
					{
						Texture tempGraphic =  achievementList[i].badgeIcon;
						float resizeRatio = 0.35f;
						float verticalOffset = 190f;
						
						GUI.DrawTexture(new Rect(25, (425 * heightRatio * resizeRatio) + (verticalOffset * numBadges),( tempGraphic.width * widthRatio  * resizeRatio), (tempGraphic.height * heightRatio  * resizeRatio)), tempGraphic);
						++numBadges;
					}
				}
			}
		}
	}

	
	public void ToggleWindow(bool toggle)
	{
		windowIsUp = toggle;
		globalVars.menuUp = toggle;
		globalVars.moveToggle = !toggle;
		globalVars.player.GetComponent<MouseLook>().isMoving =  !toggle;
		globalVars.player.GetComponent<CharacterMotor>().canControl =  !toggle;
		Screen.lockCursor =  !toggle;
		
		globalVars.playerCam.GetComponent<GrayscaleEffect>().enabled = toggle;
		globalVars.playerCam.GetComponent<BlurEffect>().enabled = toggle;
	}
	

	
	public void AddAchievement (string achievementLabel) 
	{
		
		for (var i = 0; i < achievementList.Length; i++)
		{
			if ((achievementList[i].label == achievementLabel) && (achievementList[i].isAchieved == false))
			{
				addingAchievement = i;
			}
		}
		
		Debug.Log(achievementList[addingAchievement].label + " has been achieved.");
		if (achievementsEnabled == true)
		{
			ToggleWindow(true);
			GetComponent<AudioSource>().Play();
		}	
	}
}
