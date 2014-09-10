using UnityEngine;
using System.Collections;

public class EmptyResourceAndLoadNextScene : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
	{
		Resources.UnloadUnusedAssets();
		//Application.LoadLevelAsync("ModifiedDay");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Application.GetStreamProgressForLevel("ModifiedDay") == 1.0f)
		{
			Application.LoadLevel("ModifiedDay");
		}
	}
	void OnGUI()
	{
		GUI.Box(new Rect(0,Screen.height / 2 - 80, Screen.width, 80),"Loading Rig Scene..." + "  " + (Application.GetStreamProgressForLevel("ModifiedDay") * 100 + "%"));
		StartCoroutine(LoadLevel());
	}
	IEnumerator LoadLevel()
	{
		AsyncOperation async = Application.LoadLevelAsync("ModifiedDay");
		yield return async;
	}
}
