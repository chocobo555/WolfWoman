



using UnityEngine;
using System.Collections;

public class Breathing : MonoBehaviour 
{
	public float growthFactor = .1F;

	bool breathingIn = false;

	Vector3 normalSize;

	float sizeMax;
	float sizeMin;

	// Use this for initialization
	void Start () 
	{
		normalSize = transform.localScale;

		sizeMax = normalSize.x + .10F;
		sizeMin = normalSize.x - .10F;
	}


	// Update is called once per frame
	void Update () 
	{

		if(transform.localScale.x < sizeMin) 
			breathingIn = true;
		else if(transform.localScale.x > sizeMax) 
			breathingIn = false;

		if(breathingIn == true) 
			transform.localScale += new Vector3(growthFactor, growthFactor, growthFactor) * Time.deltaTime;
		else if(breathingIn == false) 
			transform.localScale -= new Vector3(growthFactor, growthFactor, growthFactor) * Time.deltaTime;

	}
}
