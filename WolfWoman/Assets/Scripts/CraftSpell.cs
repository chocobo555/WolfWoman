using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CraftSpell : MonoBehaviour 
{

	public ParseText myParseText;


	public List<Button> allButtons;
		//public Button SAVC;
	List<Button> spellsToActivate;


	List<string> myObtainedKeywords;

	Rect myRect;
	bool callActivate = false;



	// Use this for initialization
	void Start() 
	{
		spellsToActivate = new List<Button>();
		myObtainedKeywords = myParseText.ObtainedKeyWords;
		myRect = gameObject.GetComponent<RectTransform>().rect;

	}


	void ActivateSpell()
	{

		for (int i = 0; i < allButtons.Count; i++) 
		{
			string tempString = allButtons[i].transform.GetComponentInChildren<Text>().text;
			string[] words;
			words = tempString.Split(' ');

			foreach(string keyWord in myObtainedKeywords) 
			{
				//veridian = SAVC
				for (int j = 0; j < words.Length; j++) 
				{
					if (keyWord == words[j]) 
					{
						spellsToActivate.Add(allButtons[i]);
					}
				}
			}
		}
	

		for (int i = 0; i < spellsToActivate.Count; i++) 
		{
			Vector3 buttonPosition = new Vector3(0, 0, 0);
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



