using UnityEngine;
using System.Collections;

public class finishLine : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other)
{
		if(globalVars.CurrentLevel == "Level3")
		{
   			if (other.tag == "Player")
				globalVars.missionComplete = true;
        	//	print ("Player has hit collider");
		}
	
}
}
