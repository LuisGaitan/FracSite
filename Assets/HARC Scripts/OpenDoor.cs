using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour
{
	public enum State
	{
		open,
		closed,
		inbetween
	}
	public State state;
	
	public float maxDistance = 1f;
	
	// Use this for initialization
	void Start()
	{
		state = OpenDoor.State.closed;
	}
	
	// Update is called once per frame
	void Update()
	{
		if(GetComponent<Chest>().isHover)
		{
			if(Input.GetButtonUp ("AndroidTVButtonA"))
			{				
				switch(state)
				{
				case State.open:
					state = State.inbetween;
					StartCoroutine(Close());
					break;
				case State.closed:
					state = State.inbetween;
					StartCoroutine(Open());
					break;
				}
			}
		}
	}
	
//	void OnMouseUp()
//	{
//		GameObject go = GameObject.FindGameObjectWithTag("Player");
//		
//		if (go == null)
//			return;
//		
//		if (Vector3.Distance(transform.position, go.transform.position) > maxDistance)
//			return;
//		
//		switch(state)
//		{
//		case State.open:
//			state = State.inbetween;
//			StartCoroutine(Close());
//			break;
//		case State.closed:
//			state = State.inbetween;
//			StartCoroutine(Open());
//			break;
//		}
//		
//	}
	
	//[RPC]
	IEnumerator Open()
	{
		animation.Play("Door_Open");
		yield return new WaitForSeconds(animation["Door_Open"].length);
		state = OpenDoor.State.open;
	}
	
	//[RPC]
	IEnumerator Close()
	{
		animation.Play("Door_Close");
		yield return new WaitForSeconds(animation["Door_Close"].length);
		state = OpenDoor.State.closed;
	}
}
