using UnityEngine;
using System.Collections;


//This script is for the Quarters to the side of the Drill Rig; It finds that Object, gathers it's children and finds their names; after it has their names, it gives them their appropiate
//textures
public class QuartersScript : MonoBehaviour 
{
	// Use this for initialization
	IEnumerator Start () 
	{
		WWW CabinBodyTexture = new WWW ("http://epicphotogear.com/harc/v15/HUDImages/ImagesForQuarters/CabinBodyTexture.jpg");
		WWW CableTexture = new WWW("http://epicphotogear.com/harc/v15/HUDImages/ImagesForQuarters/CableTexture.jpg");
		WWW StiltTexture = new WWW("http://epicphotogear.com/harc/v15/HUDImages/ImagesForQuarters/StiltTexture.jpg");
		WWW ACTexture = new WWW("http://epicphotogear.com/harc/v15/HUDImages/ImagesForQuarters/ACUnitTexture.jpg");
		WWW MudTexture = new WWW("http://epicphotogear.com/harc/v15/HUDImages/ImagesForQuarters/MudTexture.jpg");
		
		yield return CabinBodyTexture;
		yield return CableTexture;
		yield return StiltTexture;
		yield return ACTexture;
		yield return MudTexture;
		
		GameObject Quarters = GameObject.Find("QUARTERS");
		foreach(Transform Child in Quarters.transform)
		{
			foreach(Transform GChild in Child)
			{
				if(GChild.name == "Stilt")
				{
					GChild.gameObject.renderer.material.mainTexture = StiltTexture.texture;
				}
				if(GChild.name == "Cable")
				{
					GChild.gameObject.renderer.material.mainTexture = CableTexture.texture;
				}
				if(GChild.name == "AC Unit")
				{
					GChild.gameObject.renderer.material.mainTexture = ACTexture.texture;
				}
				if(GChild.name == "CabinBody")
				{
					GChild.gameObject.renderer.material.mainTexture = CabinBodyTexture.texture;
				}
				if(GChild.name == "MudBody")
				{
					GChild.gameObject.renderer.material.mainTexture = MudTexture.texture;
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
