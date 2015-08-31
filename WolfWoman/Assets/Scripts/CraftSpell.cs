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


	void ActivateAllSpells()
	{

		for (int i = 0; i < allButtons.Count; i++) 
		{
			ActivateSpell(allButtons[i]);
		}

		for (int j = 0; j < spellsToActivate.Count; j++) 
		{
			Vector3 buttonPosition = new Vector3(0, 0, 0);
			Button mySpell = Instantiate(spellsToActivate[j], buttonPosition, Quaternion.Euler(0,0,0)) as Button;
			mySpell.transform.SetParent(this.transform, false);
		}

	}
	void ActivateSpell(Button currButton)
	{
		string[] tempStringArray = GetButtonStrings(currButton);
		
		for(int j = 0; j < myObtainedKeywords.Count; j++)
		{
			for(int i = 0; i < tempStringArray.Length; i++)
			{
				if(tempStringArray[i] == myObtainedKeywords[j])
					spellsToActivate.Add(currButton);  
			} 
		}
	}
	string[] GetButtonStrings(Button myButton)
	{
		string[] words = myButton.transform.GetComponentInChildren<Text>().text.Split(' ');
		return words;
	}


	// Update is called once per frame
	void Update() 
	{

	}

}



