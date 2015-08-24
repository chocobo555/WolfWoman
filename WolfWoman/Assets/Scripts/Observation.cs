using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Observation : MonoBehaviour 
{
	public Fader fader;

	ParseText parseText;

	public Text descriptionReader;
	public Image textPanel;

	void Start()
	{
		parseText = gameObject.GetComponent<ParseText>();
	}

	public void GenerateObservation(string description)
	{
		descriptionReader.text = description;
		parseText.SearchKeyword(description);

		fader.StartCoroutine(fader.FadeTextIn(descriptionReader));
		fader.StartCoroutine(fader.FadePanelIn (textPanel));

		StartCoroutine(FadeDuration());
	}


	IEnumerator FadeDuration()
	{
		yield return new WaitForSeconds(6);
		fader.StartCoroutine(fader.FadeTextOut(descriptionReader));
		fader.StartCoroutine(fader.FadePanelOut(textPanel));
		yield return null;
	}

}
