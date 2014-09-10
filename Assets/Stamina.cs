using UnityEngine;
using System.Collections;

public class Stamina : MonoBehaviour {

	public float maxStamina;
	public float regenRate = 0.5f;
	public float degenRate = 1f;
	public KeyCode runButton;
	public Texture runIndicator;
	public Texture runBackground;
	
	
	private float pX;
	private float pY;
	private float newWidth;
	private float newHeight;
	
	private float curStamina;
	private bool running;
	
	private float percentage;
	
	void FixedUpdate()
	{
		percentage = (curStamina / maxStamina);
		 
		if ((Input.GetKey(runButton)) && (running == false))
		{
			running = true;
			//Debug.Log("Running");
			GetComponent<CharacterMotor>().movement.maxForwardSpeed = 0.6f;
		}
		if (((Input.GetKey(runButton) == false) && (running == true)) || (curStamina >= maxStamina))
		{
			running = false;
			//Debug.Log("Not running");
			GetComponent<CharacterMotor>().movement.maxForwardSpeed = 0.3f;
			curStamina -= 0.1f;
		}
		
		if (running)
		{
			curStamina += degenRate;
		}
		else if (curStamina > 0)
		{
			curStamina -= regenRate;
		}
	}
	
	void OnGUI()
	{
		if (globalVars.minimapActive == false)
		{
			float gaugeX = GetComponent<HealthScript>().pX;
			float gaugeY = GetComponent<HealthScript>().pY;
			
			
			
			newHeight = runBackground.height / 3f;
			newWidth = runBackground.width / 2.5f;
			
			pX = gaugeX + 55;
			pY = gaugeY - (newHeight / 1.2f);
			
			
			GUI.DrawTexture(new Rect(pX, pY, newWidth, newHeight), runBackground);
			GUI.color = new Color(percentage, Mathf.Abs(1 - percentage), 0);
			GUI.DrawTexture(new Rect(pX + 16, pY + 20, runIndicator.width / 5.75f, runIndicator.height / 5.75f), runIndicator);
		}
	}
}
