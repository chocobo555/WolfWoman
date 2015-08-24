using UnityEngine;
using System.Collections;

[AddComponentMenu("Camera/Simple Smooth Mouse Look")]

public class MouseLook : MonoBehaviour 
{
	Vector2 mouseAbsolute;
	Vector2 smoothMouse;

	public Vector2 clampInDegrees = new Vector2(360, 180);
	public bool lockCursor;
	public Vector2 sensitivity = new Vector2(2, 2);
	public Vector2 smoothing = new Vector2(3, 3);
	public Vector2 targetDirection;
	public Vector2 targetCharacterDirection;

	// Assign this if there's a parent object controlling motion, such as a Character Controller.
	// Yaw rotation will affect this object instead of the camera if set.
	public GameObject characterBody;


	// Use this for initialization
	void Start () 
	{
		targetDirection = transform.localRotation.eulerAngles;

		if (characterBody)
			targetCharacterDirection = characterBody.transform.localRotation.eulerAngles;
	}


	// Update is called once per frame
	void Update () 
	{
		// Ensure the cursor is always locked when set
		if (lockCursor == true) 
			Cursor.lockState = CursorLockMode.Locked;
		
		if (lockCursor == false) 
			Cursor.lockState = CursorLockMode.None;


		// Allow the script to clamp based on a desired target value.
		Quaternion targetOrientation = Quaternion.Euler(targetDirection);
		Quaternion targetCharacterOrientation = Quaternion.Euler(targetCharacterDirection);

		// Get raw mouse input for a cleaner reading on more sensitive mice.
		Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

		// Scale input against the sensitivity setting and multiply that against the smoothing value.
		mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity.x * smoothing.x, sensitivity.y * smoothing.y));

		// Interpolate mouse movement over time to apply smoothing delta.
		smoothMouse.x = Mathf.Lerp (smoothMouse.x, mouseDelta.x, 1F / smoothing.x);
		smoothMouse.y = Mathf.Lerp (smoothMouse.y, mouseDelta.y, 1F / smoothing.y);

		// Find the absolute mouse movement value from point zero.
		mouseAbsolute += smoothMouse;

		// Clamp and apply the local x value first, so as not to be affected by world transforms.
		if (clampInDegrees.x < 360) 
			mouseAbsolute.x = Mathf.Clamp(mouseAbsolute.x, -clampInDegrees.x * .5F, clampInDegrees.x * .5F);

		Quaternion xRotation = Quaternion.AngleAxis(-mouseAbsolute.y, targetOrientation * Vector3.right);
		transform.localRotation = xRotation;

		if (clampInDegrees.y < 360) 
			mouseAbsolute.y = Mathf.Clamp (mouseAbsolute.y, -clampInDegrees.y * .5F, clampInDegrees.y * .5F);
		

		transform.localRotation *= targetOrientation;

		// If there's a character body that acts as a parent to the camera
		if (characterBody) 
		{
			Quaternion yRotation = Quaternion.AngleAxis(mouseAbsolute.x, characterBody.transform.up);
			characterBody.transform.localRotation = yRotation;
			characterBody.transform.localRotation *= targetCharacterOrientation;
		}
		else 
		{
			Quaternion yRotation = Quaternion.AngleAxis(mouseAbsolute.x, transform.InverseTransformDirection(Vector3.up));
			transform.localRotation *= yRotation;
		}
	}

}





