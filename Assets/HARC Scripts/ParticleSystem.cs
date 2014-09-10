//Created by David Crawley

using UnityEngine;
using System.Collections;

public class PipeParticleSystem : MonoBehaviour {
	
	bool testBool = false;
	
	public void Activate(bool boolean)
	{
		if (boolean == true)
		{
			this.particleSystem.Play();
		}
		else
		{
			this.particleSystem.Stop();
		}
		
	}
	
	void Update()
	{
		
		if (Input.GetKeyDown(KeyCode.F)) 
		{
        	testBool = !testBool;
			Activate(testBool);
    	}
	}
}
