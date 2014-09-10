using UnityEngine;
using System.Collections;

public class globalVars : MonoBehaviour {
	
	public static bool interactToggle = true; //Determines whether the player can interact with objects
	public static bool moveToggle = true; //Determines whether the player is capable of movement
	public static bool minimapToggle = true; //Determines whether the minimap can be used
	public static GameObject player; //Container for the player
	public static Camera playerCam; //Container for the player's camera
	public static Camera miniCam; //Container for the minimap camera
	
	public static GameObject[] workers; //Container array for the workers
	public static Vector3[] workerOrigPos; //Contains the positions of the workers before they run away
	public static Quaternion[] workerOrigRot; //Original rotation of the workers
	
	public static  bool menuUp = false;//is the menu currently up?
	public  static bool display = true;//display the GUI's ( for when the menu covers everything up )
	public static bool missionComplete = false;
	public  static GameObject legend_selected;//the current legend option selected
	public static string CurrentLevel;
	public static bool fail = false;
	
	public static bool minimapActive = false;	
	
	
	public static bool blowoutComplete = false; //Mission and evacuation has been completed
	public static bool questionsComplete = false; //Questions have been completed
	public static bool kaboomAchieved = false; //Whether the "Kaboom" achievement has been gotten yet
}
