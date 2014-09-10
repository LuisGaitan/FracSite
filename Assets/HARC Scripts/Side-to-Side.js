#pragma strict

var rotation=0.5;

function Update() 
{
	if(Input.GetKey("right")||Input.GetKey("left")||Input.GetKey("down")||Input.GetKey("up"))
	{
		var x=transform.localEulerAngles;
		rotation*=-1;
		transform.localEulerAngles=Vector3(x.x,x.y,x.z+rotation);
	}
}
