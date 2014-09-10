using UnityEngine;
using System.Collections;

public class AnimateMaterial : MonoBehaviour
{
	//Controls movement and evolution of clouds on skydome.

	public GameObject lowerSkyPlane;
	public GameObject upperSkyPlane;

	public float upperScrollSpeed = .2f; //Speed of upper cloud movement.
	public float lowerScrollSpeed = .4f; //Speed of lower cloud movement.
	public float evolutionSpeed = .2f; //Speed of cloud evolution.

	void Update ()
	{
		cloudScroll ();

		cloudEvolution ();
	}

	void cloudScroll ()
	{
		float offset = (Time.time * (upperScrollSpeed/100)); //Ammount of texture offset.
		float offset1 = (Time.time * (lowerScrollSpeed/100)); //Ammount of texture offset.

		upperSkyPlane.renderer.material.SetTextureOffset ("_MainTexture1", new Vector3(offset, 0, 0)); //Direction of offset.
		upperSkyPlane.renderer.material.SetTextureOffset ("_MainTexture2", new Vector3(offset, 0, 0)); //Direction of offset.

		lowerSkyPlane.renderer.material.SetTextureOffset ("_MainTexture1", new Vector3(offset1, 0, 0)); //Direction of offset.
		lowerSkyPlane.renderer.material.SetTextureOffset ("_MainTexture2", new Vector3(offset1, 0, 0)); //Direction of offset.
	}
	
	void cloudEvolution ()
	{
		float speed = Mathf.PingPong(Time.time * evolutionSpeed, 1.0f); //"speed" var.
		//renderer.material.SetFloat("_Blend", speed);
		lowerSkyPlane.renderer.material.SetFloat ("_Blend", speed); //Lower cloud evolution.
		upperSkyPlane.renderer.material.SetFloat ("_Blend", speed); //Upper cloud evolution.
	}
}
