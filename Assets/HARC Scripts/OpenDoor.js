#pragma strict

var isOpen = false;
var OtherDoor : OpenDoor;
var Col : Vector3;
var Go = false;

function Start () 
{
	//0.5284061
}

function Update()
{

	if(isOpen && (this.gameObject.name != "CDoor1" || this.gameObject.name != "CDoor2"))
	{
		if(OtherDoor.gameObject.name == "CDoor2")
		{
			this.transform.rotation = Quaternion.Slerp(this.transform.rotation,Quaternion.Euler(0,270,0),3 * Time.deltaTime);
		}
		else
		{
			this.transform.Rotate(0,60 * Time.deltaTime,0);
		}
	}
	if(OtherDoor != null && OtherDoor.gameObject.name == "CDoor1")
	{
		if(this.gameObject.transform.rotation.y > 0.9434309)
		{
			isOpen = false;
		}
		if(Go)
		{
			Replay();
		}
		if(this.gameObject.transform.rotation.y <= 0)
		{
			Go = false;
		}
	}
	else
	{
		if(this.gameObject.transform.rotation.y > 0.7068599)
		{
			isOpen = false;
		}
		if(Go)
		{
			Replay();
		}
		if(this.gameObject.transform.rotation.y <= -0.5330607 && this.gameObject.transform.eulerAngles.y > 350)
		{
			Go = false;
		}
	}
	//this.transform.RotateAround(Vector3(this.transform.position.x - (transform.localScale.x / 2),this.transform.position.y - (this.transform.localScale.y),this.transform.position.z),Vector3.up,60 * Time.deltaTime);
	//this.transform.position = Vector3(-90,this.transform.position.y,this.transform.position.z);
}

function OnMouseDown () 
{
	if (!isOpen)
	{
		if(this.gameObject.name == "CDoor1" || this.gameObject.name == "CDoor2"){
		OtherDoor.isOpen = true;
		this.transform.renderer.gameObject.SetActive(false);}
		if(this.gameObject.name == "ImportedDoorContainer" && this.gameObject.transform.rotation.y > 0.9434309)
		{
			Go = true;
		}
		else
		{
			isOpen = true;
		}
		if(OtherDoor.gameObject.name == "CDoor2")
		{
			if(Go)
			{
				Go = false;
			}
			else
			{
				Go = true;
			}
		}
//		if(OtherDoor.gameObject.name == "CDoor2" && this.gameObject.transform.rotation.y > 0.7068599)
//		{
//			Go = true;
//		}
//		else
//		{
//			Go = true;
//		}
		
		//this.transform.Rotate(0,0,160);
		//this.gameObject.transform.RotateAround(this.transform.position,Vector3.up,0);
		//animation.wrapMode = WrapMode.Loop;
		//animation.Play("CDoor2",PlayMode.StopSameLayer);
		//isOpen = true;
	}
	else if (isOpen)
	{
		//this.transform.rotation = Quaternion(0,0,0,0);
		//this.gameObject.transform.RotateAround(this.transform.position,Vector3.up,160);
		//animation.wrapMode = WrapMode.Loop;
		//animation.Play("CDoor21",PlayMode.StopSameLayer);
		//isOpen = false;
	}
}
function OnMouseEnter()
{
	for(var Child : Transform in this.gameObject.transform)
	{
		Col = Vector3(this.renderer.material.color.r,this.renderer.material.color.g,this.renderer.material.color.b);
		Child.renderer.material.color = Color.green;
	}
}
function OnMouseExit()
{
	for(var Thing : Transform in this.gameObject.transform)
	{
		//Col = Vector3(this.renderer.material.color.r,this.renderer.material.color.g,this.renderer.material.color.b);
		Thing.renderer.material.color = Color(Col.x,Col.y,Col.z);
	}
}
function Replay()
{
	if(OtherDoor.gameObject.name == "CDoor2")
	{
		this.transform.rotation = Quaternion.Slerp(this.transform.rotation,Quaternion.Euler(0,63,0),3 * Time.deltaTime);
	}
	else
	{
		this.transform.Rotate(0,-60 * Time.deltaTime,0);
	}
}