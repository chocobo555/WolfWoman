using UnityEngine;
using System.Collections;

public class ObjectVisible : MonoBehaviour 
{

	public string myDescription;
	public float obsvDistance;
	public Observation myObsv;

	RaycastHit hit;

	bool closeEnough = false;
	bool genObsvCalled = false;


	void Start()
	{
		SphereCollider ObsvSphere = gameObject.AddComponent<SphereCollider>();
		ObsvSphere.isTrigger = true;
		ObsvSphere.radius = obsvDistance;
	}

	void OnWillRenderObject()
	{
		if (Camera.current == Camera.main) 
		{
			Vector3 directionToObject = gameObject.transform.position - Camera.main.transform.position;

			if(Physics.Raycast(Camera.main.transform.position, directionToObject, out hit))
			{
				if (hit.collider.gameObject.tag == "SpecialArea" && closeEnough == true && genObsvCalled == false) 
				{
					genObsvCalled = true;
					//print("lookin at special area");
					myObsv.GenerateObservation(myDescription);

				}
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{
			closeEnough = true;
		}
	}

}

