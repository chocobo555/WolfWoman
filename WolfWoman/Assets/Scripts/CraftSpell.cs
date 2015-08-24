using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CraftSpell : MonoBehaviour 
{

	public ParseText myParseText;
	public List<Button> allButtons;

	List<string> myObtainedKeywords;
	List<Button> spellsToActivate;
	Rect myRect;
	bool callActivate = false;


	// Use this for initialization
	void Start() 
	{

		myObtainedKeywords = myParseText.ObtainedKeyWords;
		myRect = gameObject.GetComponent<RectTransform>().rect;

	}


	void ActivateSpell()
	{
		foreach(string keyWord in myObtainedKeywords) 
		{
			if (keyWord == "Veridian") 
			{
				//spellsToActivate.Add(
			}
		}






		for (int i = 0; i < spellsToActivate.Count; i++) 
		{
			Vector3 buttonPosition = new Vector3(myRect.width / 2, myRect.height / 2, 0);
			Button mySpell = Instantiate(spellsToActivate[i], buttonPosition, Quaternion.Euler(0,0,0)) as Button;
			mySpell.transform.SetParent(this.transform, false);
		}

	}


	void LoadSpell()
	{

	}


	// Update is called once per frame
	void Update() 
	{
		if(callActivate == false) 
		{
			ActivateSpell();
			callActivate = true;
		}
	}

}
