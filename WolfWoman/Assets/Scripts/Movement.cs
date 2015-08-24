using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour 
{
	float moveSpeed = 6F;


	// Use this for initialization
	void Start () 
	{
	
	}

	
	// Update is called once per frame
	void Update () 
	{
		float translateV = Input.GetAxis("Vertical") * moveSpeed;

		float translateH = Input.GetAxis("Horizontal") * moveSpeed;

		translateV *= Time.deltaTime;
		translateH *= Time.deltaTime;

		transform.Translate(translateH, 0, translateV);
	
	

	}
}
