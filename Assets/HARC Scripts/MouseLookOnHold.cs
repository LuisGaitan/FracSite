using UnityEngine;
using System.Collections;

/// MouseLook rotates the transform based on the mouse delta.
/// Minimum and Maximum values can be used to constrain the possible rotation

/// To make an FPS style character:
/// - Create a capsule.
/// - Add the MouseLook script to the capsule.
///   -> Set the mouse look to use LookX. (You want to only turn character but not tilt it)
/// - Add FPSInputController script to the capsule
///   -> A CharacterMotor and a CharacterController component will be automatically added.

/// - Create a camera. Make the camera a child of the capsule. Reset it's transform.
/// - Add a MouseLook script to the camera.
///   -> Set the mouse look to use LookY. (You want the camera to tilt up and down like a head. The character already turns.)
[AddComponentMenu("Camera-Control/Mouse Look")]
public class MouseLookOnHold : MonoBehaviour {
	public float movementSpeed=1f;
	public bool flip=false;
	public GameObject camera;
	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float sensitivityX = 15F;
	public float sensitivityY = 15F;
	public GUISkin skin;
	public Rect window=new Rect(0,0,200,130);
	
	public float minimumX = -360F;
	public float maximumX = 360F;

	public float minimumY = -60F;
	public float maximumY = 60F;

	float rotationY = 0F;
	
	void instructions(int windowID)
	{
		GUILayout.BeginVertical(GUI.skin.GetStyle("box"));
		GUILayout.Label("Click & hold + mouse movements = Rotate Object");
		GUILayout.Label("Arrow Keys = Move Camera");
		GUILayout.Label("Mouse Scroll = Zoom in/out");
		GUILayout.EndVertical();
		GUI.DragWindow();
	}
	
	void Update()
	{
		
		if(Input.GetButton ("Fire1")){
			
			
		if (axes == RotationAxes.MouseXAndY)
		{
			float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
			
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
			
			transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
		}
		else if (axes == RotationAxes.MouseX)
		{
			transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
		}
		else
		{
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
			
			transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
		}
		}
		Vector3 right=flip?camera.transform.forward:camera.transform.right;
		Vector3 forward=flip?camera.transform.right:camera.transform.forward;
		if(Input.GetKey(KeyCode.RightArrow))
		{
			camera.transform.localPosition+=new Vector3(right.x,0f,right.z)*movementSpeed*Time.deltaTime;
		}
		else if(Input.GetKey(KeyCode.LeftArrow))
		{
			camera.transform.localPosition+=new Vector3(-right.x,0f,-right.z)*movementSpeed*Time.deltaTime;
		}
		if(Input.GetKey(KeyCode.UpArrow))
		{
			camera.transform.localPosition+=new Vector3(forward.x,0f,forward.z)*movementSpeed*Time.deltaTime;
		}
		else if(Input.GetKey(KeyCode.DownArrow))
		{
			camera.transform.localPosition+=new Vector3(-forward.x,0f,-forward.z)*movementSpeed*Time.deltaTime;
		}
	}
	
	void OnGUI()
	{
		GUI.skin=skin;
		window=GUI.Window(0,window,instructions,"Instructions",GUI.skin.GetStyle("Window"));
	}
	
	void Start()
	{
		// Make the rigid body not change rotation
		if (rigidbody)
			rigidbody.freezeRotation = true;
	}
}
