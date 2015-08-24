using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fader : MonoBehaviour 
{

	//If you want it to fade faster, just reduce the time
	public float aTime;

	public Text descriptionReader;


	public IEnumerator FadePanelIn(Image panelToFade)
	{
		float alpha = panelToFade.GetComponent<Image>().color.a;
		
		for(float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
		{
			Color newColor = panelToFade.GetComponent<Image>().color;
			newColor.a = Mathf.Lerp(alpha, .7f, t);
			panelToFade.GetComponent<Image>().color = newColor;
			yield return null;
		}
	}

	public IEnumerator FadeTextIn(Text textToFade)
	{
		float alpha = textToFade.GetComponent<Text>().color.a;

		for (float i = 0f; i < 1f; i += Time.deltaTime / aTime) 
		{
			Color newColor = textToFade.GetComponent<Text>().color;
			newColor.a = Mathf.Lerp(alpha, 1, i);
			textToFade.GetComponent<Text> ().color = newColor;
			yield return null;
		}
	}


	public IEnumerator FadeTextOut(Text textToFade)
	{
		float alpha = textToFade.GetComponent<Text>().color.a;

		float t = 0;
		for (float i = 1f; i > 0f; i -= Time.deltaTime / aTime)
		{
			t += Time.deltaTime / aTime;

			Color newColor = textToFade.GetComponent<Text>().color;
			newColor.a = Mathf.Lerp(alpha, 0, t);
			textToFade.GetComponent<Text>().color = newColor;
			yield return null;
		}
	}

	public IEnumerator FadePanelOut(Image panelToFade)
	{
		float alpha = panelToFade.GetComponent<Image>().color.a;
		
		float t = 0;
		for (float i = 1f; i > 0f; i -= Time.deltaTime / aTime)
		{
			t += Time.deltaTime / aTime;
			
			Color newColor = panelToFade.GetComponent<Image>().color;
			newColor.a = Mathf.Lerp(alpha, 0, t);
			panelToFade.GetComponent<Image>().color = newColor;
			yield return null;
		}
	}

}
		

