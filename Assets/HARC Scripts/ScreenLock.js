#pragma strict

var isLocked:boolean=true;
function Start() 
{
	Screen.lockCursor=isLocked;
}
