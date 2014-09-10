
using UnityEngine;
using System.Collections;

public class CloudBlend : MonoBehaviour
{
	public float changeSpeed = 1f;

	// Use this for initialization
	void Start ()
	{
		//renderer.material.shader = Shader.Find("Custom/Blend 2 Textures");
	}
	
	// Update is called once per frame
	void Update ()
	{
		float speed = Mathf.PingPong(Time.time * changeSpeed, 1.0f);
		renderer.material.SetFloat("_Blend", speed);
	}
}
