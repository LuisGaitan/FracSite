using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	public Transform Cam;
	public GameObject player;
	public Camera pCamera;
	public Camera mCamera;
	
	public GameObject[] workers;
	
	void Start ()
	{
		globalVars.workers = workers;
		globalVars.workerOrigPos = new Vector3[workers.Length]; //Makes sure that the position vector array is as large as the workers'....
		globalVars.workerOrigRot = new Quaternion[workers.Length];
		globalVars.player = player;
		globalVars.playerCam = pCamera;
		globalVars.miniCam = mCamera;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//this.transform.Translate(new Vector3(Input.GetAxis("Horizontal") * 5 * Time.deltaTime,0,Input.GetAxis("Vertical") * 5 * Time.deltaTime));
		Cam.transform.rotation = new Quaternion(0,this.transform.rotation.y,0,this.transform.rotation.w);
		player.GetComponent<FPSInputController>().movement = globalVars.moveToggle;
	}
}
