#pragma strict

function OnMouseDown()
{
	GameObject.Find("First Person Controller").GetComponent(TeleportBack).bool=true;
	Application.LoadLevel("Mats360");
}

function Update () {

}