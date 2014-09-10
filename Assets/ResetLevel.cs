using UnityEngine;
using System.Collections;

public class ResetLevel : MonoBehaviour {
	
	public KeyCode resetButton;
	private bool reset = false;
	
	void FixedUpdate()
	{	 
		if ((Input.GetKey(resetButton)) && (reset == false))
		{
			reset = true;
			globalVars.blowoutComplete = false; //Mission and evacuation has been completed
			globalVars.questionsComplete = false; //Questions have been completed
			globalVars.kaboomAchieved = false; //Whether the "Kaboom" achievement has been gotten yet
			
			Application.LoadLevel(Application.loadedLevelName );
		}
	}
	
	
}
