using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour
{
    public float barDisplay; //current progress
    
    public Vector2 size = new Vector2(50,20);
    public Texture2D emptyTex;
    public Texture2D fullTex;
	public DoubleClick2[] HarcHotSpots;
	public System.Collections.Generic.List<Transform> Clicked;
	public int imageDepth = 0;
	
	public float pX;
	public float pY;
	private int curHotspots;
	private float flashTimer; //For counting time of how long the interface glows green
	
	void Start()
	{
		HarcHotSpots = GameObject.FindObjectsOfType(typeof(DoubleClick2)) as DoubleClick2[];
		Debug.Log("Number of hotspots: " + (float)HarcHotSpots.Length);
	}
 
    void OnGUI() 
	{
		if (globalVars.minimapActive == false)
		{
			pX = -(emptyTex.width / 8); //Not exact values due to faulty image
			pY = Screen.height - (emptyTex.height / 1.0f);
			
			GUI.depth = imageDepth;
			
			//draw the filled-in part:
	        GUI.DrawTexture(new Rect(pX + 195, pY + 67, (size.x * barDisplay), size.y/10), fullTex, ScaleMode.StretchToFill);
			
			
			if ((float)Clicked.Count > curHotspots)
			{
				curHotspots++;
				flashTimer = 100;
			}
			if (flashTimer > 0)
			{
				GUI.color = new Color((Mathf.Abs(flashTimer - 100)) / 100, 1, (Mathf.Abs(flashTimer - 100)) / 100);
				--flashTimer;
			}
			
			
	       //draw the background:
	       GUI.DrawTexture(new Rect(pX,pY, size.x, size.y), emptyTex, ScaleMode.StretchToFill);
			
		   GUI.color = new Color(255, 255, 255);
		}
    }
 
    void Update() 
	{
		foreach(DoubleClick2 child in HarcHotSpots)
		{
			if(child.GetComponent<DoubleClick2>().clicked)
			{
				if(!Clicked.Contains(child.gameObject.transform))
				{
					Clicked.Add(child.gameObject.transform);
				}
			}
		}
		
		barDisplay = ((float)Clicked.Count / (float)HarcHotSpots.Length) * 0.45f;
    }
}
