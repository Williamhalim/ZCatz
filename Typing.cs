using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Networking;

public class Typing : MonoBehaviour {
	
	static public string letters;

	public Text inputText;
	public Image inputFieldColor;
	public GameObject noEnter;

	public AudioClip Razerblack1;
	public AudioClip RazerblackEnter;
	public AudioClip enemyDmg;

	public static WordManager wordManager;

	
	void Awake (){
		WordManager.typing = this;
	}


	// The "alphabets" is to allow the function to return the keyboard input.
	public void inputLetters (string alphabets){
		//"letters" is a string to store the alphabets as they are inputted from the keyboard one by one. 
		letters += alphabets;
		GetComponent<AudioSource>().PlayOneShot (Razerblack1);
		inputText.text = (letters);
		WordManager.MatchWord ();
	}
	
	public void BackSpace (){
		string tempGetString = inputText.text;
		if (tempGetString.Length > 0) {
			GetComponent<AudioSource>().PlayOneShot (Razerblack1);
			string tempString = tempGetString.Substring(0, tempGetString.Length -1);
			inputText.text = tempString;
			letters = tempString;
			inputFieldColor.color = new Vector4 (0.8f, 0.8f, 0.8f, 1);
		}
		
	}

	public void PrintAttack(){
		// To check the text inside the input field, this is called in the Update function.
		for (int i = 0; i < 4; i++) {
//			CORRECT WORD
			if (WordManager.lockedOnWord != null && inputText.text == WordManager.lockedOnWord || WordManager.lockedOnWord2 != null && inputText.text == WordManager.lockedOnWord2 ||  WordManager.lockedOnWord3 != null && inputText.text == WordManager.lockedOnWord3) {
				inputFieldColor.color = new Vector4 (0, 1, 0, 1);
				WordManager.lockedOnWord = null;
				WordManager.lockedOnWord2 = null;
				WordManager.lockedOnWord3 = null;
				WordManager.lockedOnWord4 = null;
				noEnter.SetActive (false);
			}
//			WRONG WORD
			if (WordManager.lockedOnWord != null && inputText.text.Length == WordManager.lockedOnWord.Length && inputText.text != WordManager.lockedOnWord && inputText.text != WordManager.lockedOnWord2 && inputText.text != WordManager.lockedOnWord3 && inputText.text != WordManager.lockedOnWord4 || 
				WordManager.lockedOnWord4 != null && inputText.text.Length <= WordManager.lockedOnWord4.Length && inputText.text != WordManager.lockedOnWord && inputText.text != WordManager.lockedOnWord2 && inputText.text != WordManager.lockedOnWord3 && inputText.text != WordManager.lockedOnWord4 && inputText.text.Length == 1 && inputText.text.Substring(0, 1) != WordManager.lockedOnWord4.Substring (0,1) || 
				WordManager.lockedOnWord4 != null && inputText.text.Length <= WordManager.lockedOnWord4.Length && inputText.text != WordManager.lockedOnWord && inputText.text != WordManager.lockedOnWord2 && inputText.text != WordManager.lockedOnWord3 && inputText.text != WordManager.lockedOnWord4 && inputText.text.Length == 2 && inputText.text.Substring(1, 1) != WordManager.lockedOnWord4.Substring (1,1) || 
				WordManager.lockedOnWord4 != null && inputText.text.Length <= WordManager.lockedOnWord4.Length && inputText.text != WordManager.lockedOnWord && inputText.text != WordManager.lockedOnWord2 && inputText.text != WordManager.lockedOnWord3 && inputText.text != WordManager.lockedOnWord4 && inputText.text.Length == 3 && inputText.text.Substring(2, 1) != WordManager.lockedOnWord4.Substring (2,1) || 
				WordManager.lockedOnWord4 != null && inputText.text.Length <= WordManager.lockedOnWord4.Length && inputText.text != WordManager.lockedOnWord && inputText.text != WordManager.lockedOnWord2 && inputText.text != WordManager.lockedOnWord3 && inputText.text != WordManager.lockedOnWord4 && inputText.text.Length == 4 && inputText.text.Substring(3, 1) != WordManager.lockedOnWord4.Substring (3,1) || 
				WordManager.lockedOnWord4 != null && inputText.text.Length <= WordManager.lockedOnWord4.Length && inputText.text != WordManager.lockedOnWord && inputText.text != WordManager.lockedOnWord2 && inputText.text != WordManager.lockedOnWord3 && inputText.text != WordManager.lockedOnWord4 && inputText.text.Length == 5 && inputText.text.Substring(4, 1) != WordManager.lockedOnWord4.Substring (4,1) || 
				WordManager.lockedOnWord4 != null && inputText.text.Length <= WordManager.lockedOnWord4.Length && inputText.text != WordManager.lockedOnWord && inputText.text != WordManager.lockedOnWord2 && inputText.text != WordManager.lockedOnWord3 && inputText.text != WordManager.lockedOnWord4 && inputText.text.Length == 6 && inputText.text.Substring(5, 1) != WordManager.lockedOnWord4.Substring (5,1) || 
				WordManager.lockedOnWord4 != null && inputText.text.Length <= WordManager.lockedOnWord4.Length && inputText.text != WordManager.lockedOnWord && inputText.text != WordManager.lockedOnWord2 && inputText.text != WordManager.lockedOnWord3 && inputText.text != WordManager.lockedOnWord4 && inputText.text.Length == 7 && inputText.text.Substring(6, 1) != WordManager.lockedOnWord4.Substring (6,1) || 
				WordManager.lockedOnWord4 != null && inputText.text.Length <= WordManager.lockedOnWord4.Length && inputText.text != WordManager.lockedOnWord && inputText.text != WordManager.lockedOnWord2 && inputText.text != WordManager.lockedOnWord3 && inputText.text != WordManager.lockedOnWord4 && inputText.text.Length == 8 && inputText.text.Substring(7, 1) != WordManager.lockedOnWord4.Substring (7,1) || 
				WordManager.lockedOnWord4 != null && inputText.text.Length <= WordManager.lockedOnWord4.Length && inputText.text != WordManager.lockedOnWord && inputText.text != WordManager.lockedOnWord2 && inputText.text != WordManager.lockedOnWord3 && inputText.text != WordManager.lockedOnWord4 && inputText.text.Length == 9 && inputText.text.Substring(8, 1) != WordManager.lockedOnWord4.Substring (8,1) || 
				WordManager.lockedOnWord != null && inputText.text.Length > WordManager.lockedOnWord.Length || 
				inputText.text.Length == 1 && WordManager.lockedOnWord == null)
//				|| 
//				inputText.text.Length == 2 && WordManager.lockedOnWord.Substring(1,1) != inputText.text.Substring(1,1) ||
//				inputText.text.Length == 2 && WordManager.lockedOnWord2 != null && WordManager.lockedOnWord2.Substring(1,1) != inputText.text.Substring(1,1) || 
//				inputText.text.Length == 2 && WordManager.lockedOnWord3 != null && WordManager.lockedOnWord3.Substring(1,1) != inputText.text.Substring(1,1) )
				{
				inputFieldColor.color = new Vector4 (1, 0, 0, 1);
				noEnter.SetActive (true);
			}
		}
	}

	
	public void PrintLetters (){
		WordManager.EnterWord (letters);
		GetComponent<AudioSource>().PlayOneShot (RazerblackEnter);
		inputFieldColor.color = new Vector4 (0.8f, 0.8f, 0.8f, 1);
	}

	public void DamageSFX(){
		GetComponent<AudioSource>().PlayOneShot (enemyDmg);
	}

	public void ClearText(){
		letters = null;
		inputText.text = (letters);
	}


	public void Meow()
	{
		if (inputText.text == "") 
		{
			inputText.text = "meow..?";
		}
	}

	void Update ()
	{
		PrintAttack ();

		if (Input.anyKeyDown) 
		{
			foreach (char c in Input.inputString) 
			{
				if (c == "\b" [0]) 
				{
					BackSpace ();
				} 
				else 
				{
					if (c == "\n" [0] || c == "\r" [0])
					{
						GetComponent<AudioSource>().PlayOneShot (RazerblackEnter);
						PrintLetters ();
						ClearText ();
					}
					else
					{
						GetComponent<AudioSource>().PlayOneShot (Razerblack1);
						letters += c;
						inputText.text = (letters);
					}
				}
			}
		}
	}
}