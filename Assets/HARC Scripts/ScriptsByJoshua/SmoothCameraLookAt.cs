using UnityEngine;
using System.Collections;

public class SmoothCameraLookAt : MonoBehaviour {

	public Vector3 OGPosition;
	public float ShakeAmount;
	public float DecayAmount;
	public float Interval;
//	public Vector3 OGPosition;
//	public Transform RefPoint;
//	public float damping = 6.0f;
//	public bool smooth;
	
	
	// Use this for initialization
	void Start () 
	{
		OGPosition = this.transform.localPosition;
//		if (rigidbody)
//		rigidbody.freezeRotation = true;
//		OGPosition = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Interval < 0)
		{
			Interval = 0;
			this.transform.localPosition = OGPosition;
		}
		if(Interval > 0)
		{
			this.transform.localPosition = Random.insideUnitCircle * ShakeAmount;
			Interval -= Time.deltaTime * DecayAmount;
		}
		//target = new Vector3(RefPoint.transform.position.x - 0.25f,this.transform.position.y,RefPoint.transform.position.z);
	}
	
	void LateUpdate()
	{
//		//if (target) 
//		{
//			if (smooth)
//			{
//				// Look at and dampen the rotation
//				Quaternion rotation = Quaternion.LookRotation(target - transform.position);
//				transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
//			}
//			else
//			{
//				// Just lookat
//			    transform.LookAt(RefPoint.transform.position + new Vector3(0,0.15f,0.05f));
//				this.transform.position = RefPoint.transform.position + new Vector3(0.25f,0.25f,0.05f);
//			}
//		}
	}
}
