using UnityEngine;
using System.Collections;

public class LinkDoubleClick : MonoBehaviour {
	
	public string linkURL = "Link goes here";
	
	public float doubleClickStart  = -1.0f;
	//EDIT TO DISABLE MOUSE CLICKS FOR A TIME AFTER DOUBLE CLICK
	public bool disableClicks = false;

	Color defaultColor;

	void Start()
	{
		defaultColor = renderer.material.color;
	}
	
	void OnMouseUp()
	{
		//EDIT TO DISABLE MOUSE CLICKS FOR A TIME AFTER DOUBLE CLICK
	    if (disableClicks)
	        return;
	
	    //make sure doubleClickStart isn't negative, that'll break things
	    if (doubleClickStart > 0 && (Time.time - doubleClickStart) < 0.4 && !Minimap.isLarge)
	    {
	        this.OnDoubleClick();
	        doubleClickStart = -1;
	            lockClicks();
	    }
	    else
	    {
	        doubleClickStart = Time.time;
	    }
	}
	
	IEnumerator lockClicks()
	{
	    disableClicks = true;
	 	yield return new WaitForSeconds(0.4f);
	    disableClicks = false;
	}
	
	void OnDoubleClick()
	{   
		Application.ExternalCall("window.open('" + linkURL + "','_blank')");
	}
	
	void OnMouseEnter()
	{
		this.renderer.material.color = new Color(0f,1f,0f,1f);
	}
	void OnMouseExit()
	{
		this.renderer.material.color = defaultColor;
	}
}
