using UnityEngine;
using System.Collections;

public class Chest : MonoBehaviour {
	public enum State 
	{
		open,
		close,
		inbetween
	}
	public GameObject[] part;
	public Color[] _defaultColors;
	public State state;
	public float maxDistance = 2;
	public bool isHover = false;
	
	// Use this for initialization
	void Start () 
	{
		state = Chest.State.close;
		_defaultColors = new Color[part.Length];
		
		if(part.Length > 0)
			for(int cnt = 0; cnt <_defaultColors.Length; cnt++)
		{
			_defaultColors[cnt] = part[cnt].renderer.material.GetColor ("_Color");
		}
	}

	void Update()
	{
		if(isHover)
		{
			HighLight (true);
		}
		else
		{
			HighLight (false);
		}
	}
	
//	public void OnMouseEnter()
//	{
//		if (globalVars.interactToggle == true)
//		{
//			HighLight(true);
//			isHover = true;
//		}
//	}
//	
//	public void OnMouseExit()
//	{
//		HighLight(false);
//		isHover = false;
//	}
	
	public void OnMouseUpAsButton()
	{
		if (globalVars.interactToggle == true)
		{
			Debug.Log(globalVars.interactToggle);
			
			GameObject go = GameObject.FindGameObjectWithTag("Player");
			if(go == null)
				return;
			if(Vector3.Distance (this.transform.position, go.transform.position) > maxDistance)
				return;
			
			if(state == Chest.State.close)
				Open ();
			else
				Close ();
		}
	}
	
	private void Open()
	{
		//Debug.Log("Chest open");
		state = Chest.State.open;
	}
	
	private void Close()
	{
		//Debug.Log("Chest closed");
		state = Chest.State.close;
	}
	
	private void HighLight(bool glow) 
	{
		if(glow)
		{
			if(part.Length > 0)
				for(int cnt = 0; cnt <_defaultColors.Length; cnt++)
					foreach(Material Child in part[cnt].renderer.materials)
				{
					Child.SetColor("_Color", new Color(0.1f, 1, 0.1f, _defaultColors[cnt].a));
				}
		}
		else
		{
			if(part.Length > 0)
				for(int cnt = 0; cnt <_defaultColors.Length; cnt++)
					foreach(Material Child in part[cnt].renderer.materials)
				{
					Child.SetColor("_Color", _defaultColors[cnt]);
				}
		}
	}
}
