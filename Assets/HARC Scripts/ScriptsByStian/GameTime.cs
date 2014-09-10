using UnityEngine;
using System.Collections;

public class GameTime : MonoBehaviour
{
	//Controls time and sun movement.

	public Transform[] sun;
	public float dayCycleInMinutes  = 1;

	//Lets me use Words for second, minute, etc.
	//Converts words to # of seconds.
	private const float SECOND = 1;
	private const float MINUTE = 60 * SECOND;
	private const float HOUR = 60 * MINUTE;
	private const float DAY = 24 * HOUR;
	private const float DEGREES_PER_SECOND = 360 / DAY;

	private float _degreeRotation;
	private float _timeOfDay;
	private float _dayCycleInSeconds;

	// Use this for initialization
	void Start ()
	{
		_dayCycleInSeconds = dayCycleInMinutes * MINUTE;
		_timeOfDay = 0;
		_degreeRotation = DEGREES_PER_SECOND * DAY / (_dayCycleInSeconds); //Ammount to rotate
	}
	
	// Update is called once per frame
	void Update ()
	{
		sun[0].Rotate(new Vector3(_degreeRotation, 0, 0) * Time.deltaTime); //One full revolution in one minute

		_timeOfDay +=Time.deltaTime;
		Debug.Log (_timeOfDay);
	}
}
