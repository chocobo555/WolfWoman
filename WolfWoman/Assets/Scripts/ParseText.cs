using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ParseText : MonoBehaviour 
{

	public List<string> AllKeyWords;
	public List<string> ObtainedKeyWords;


	public void SearchKeyword(string description)
	{
		description = description.ToLower();
		description = description.Replace(".", "");

		string[] words;
		words = description.Split(' ');

		foreach(string word in words) 
		{
			print (word);
			for(int i = 0; i < AllKeyWords.Count; i++) 
			{
				if(word == AllKeyWords[i]) 
				{
					ObtainedKeyWords.Add(AllKeyWords[i]);
					print("keyword obtained!!");
					TrimKeyWords(AllKeyWords[i]);
				}
			}
		}

	}

	void TrimKeyWords(string currentKeyWord)
	{
		AllKeyWords.Remove(currentKeyWord);
	}
	
}



