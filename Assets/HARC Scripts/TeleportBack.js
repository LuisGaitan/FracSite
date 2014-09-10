var bool:boolean=false;

function Start()
{
	Screen.lockCursor=true;
	var str = PlayerPrefs.GetString("playerPos","notfound");
	if (str != "notfound"){ // if not found...
		var delims: char[] = "(),".ToCharArray(); // define delimiters
		// split the values in an array
		var values: String[] = str.Split(delims);
		var pos: Vector3;
		var rot: Quaternion;
		pos.x = float.Parse(values[1]);
		pos.y = float.Parse(values[2]);
		pos.z = float.Parse(values[3]);
		rot.x = float.Parse(values[5]);
		rot.y = float.Parse(values[6]);
		rot.z = float.Parse(values[7]);
		rot.w = float.Parse(values[8]);
		QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("playerQuality",0));
		//move the player
		transform.position=pos;
		transform.rotation=rot;
    }
}

function Update() 
{
	if(bool)
	{
		var s = transform.position.ToString()+transform.rotation.ToString();
		PlayerPrefs.SetString("playerPos", s);
		PlayerPrefs.SetInt("playerQuality",QualitySettings.GetQualityLevel());
	}
}
