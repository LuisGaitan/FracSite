#pragma strict
var XSize:Number=0;
var YSize:Number=0;
var image:Texture2D;
var p0             : GameObject;//used to turn off movement
var p1             : GameObject;//used to turn off movement

function OnGUI()
{
	if(Screen.lockCursor)
	{
		GUI.Label(Rect((Screen.width-XSize)/2,(Screen.height-YSize)/2,XSize,YSize),image);
		if(!p0.GetComponent(MouseLook).isMoving)
		{
			p0.GetComponent(MouseLook).isMoving=true;
			p0.GetComponent(CharacterMotor).isMoving=true;
			p1.GetComponent(MouseLook).isMoving=true;
		}
	}
	else
	{
		if(p0.GetComponent(MouseLook).isMoving)
		{
			p0.GetComponent(MouseLook).isMoving=false;
			p0.GetComponent(CharacterMotor).isMoving=false;
			p1.GetComponent(MouseLook).isMoving=false;
		}
	}
}
