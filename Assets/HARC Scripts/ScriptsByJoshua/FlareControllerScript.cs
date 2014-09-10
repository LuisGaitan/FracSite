using UnityEngine;
using System.Collections;

public class FlareControllerScript : MonoBehaviour 
{
	public ParticleRenderer PR;
	// Use this for initialization
	void Start () 
	{
		InvokeRepeating("TurnOnEmitter",0.1f,2.0f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if(!this.particleEmitter.enabled)
		{
			
		}
	}
	
	//Called every second;
	void TurnOnEmitter()
	{
		PR.enabled = true;
		Invoke("TurnOffEmitter",0.5f);
	}
	void TurnOffEmitter()
	{
		PR.enabled = false;
	}
}
