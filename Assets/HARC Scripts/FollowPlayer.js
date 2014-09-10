var player:Transform;//player to follow
var height:Number=0;//height up from the transform

function Update() 
{
	transform.position=player.position+Vector3.up*height;
}
