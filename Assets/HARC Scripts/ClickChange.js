#pragma strict

function OnMouseDown()
{
		Screen.lockCursor=false;
		GameObject.Find("First Person Controller").GetComponent(TeleportBack).bool=true;
		Application.LoadLevel("MudPitSystemMenu");
}

function Update () {

}