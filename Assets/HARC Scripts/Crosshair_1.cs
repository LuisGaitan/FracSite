using UnityEngine;
using System.Collections;

public class Crosshair_1 : MonoBehaviour
{
	public float xSize = 50f;
	public float ySize = 50f;
	public float range;
	public Texture image;
	public GameObject p0, p1, hitObj;
	
	// Use this for initialization
	void Start () {
		
	}
	
	void Update ()
	{
		Raycast ();
	}
	
	void Raycast()
	{
		Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
		RaycastHit hit;
		
		if(Physics.Raycast (ray, out hit, range))
		{
			if(hit.collider.GetComponent<Chest>() != null)
			{
				hitObj = hit.collider.gameObject;
				hitObj.GetComponent<Chest>().isHover = true;
			}
			else if(hit.collider.gameObject != hitObj)
			{
				if(hitObj != null)
				{
					hitObj.GetComponent<Chest>().isHover = false;
					hitObj = null;
				}
			}
		}
		else
		{
			if(hitObj != null)
			{
				hitObj.GetComponent<Chest>().isHover = false;
				hitObj = null;
			}
		}
	}
	
	void OnGUI()
	{
		if(Screen.lockCursor)
		{
			GUI.DrawTexture(new Rect((Screen.width-xSize)/2,(Screen.height-ySize)/2,xSize,ySize),image);
			
			p0.GetComponent<MouseLook>().enabled = true;
			p1.GetComponent<MouseLook>().enabled = true;
		}
		else
		{
			p0.GetComponent<MouseLook>().enabled = false;
			p1.GetComponent<MouseLook>().enabled = false;
		}
	}
}
