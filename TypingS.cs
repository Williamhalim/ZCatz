//using UnityEngine;
//using UnityEngine.UI;
//using System.Collections;
//
//public class TypingS : MonoBehaviour {
//
//	string letters;
//	string enter;
//	public Text inputText;
//	public Text popUpText1;
//	public Text popUpText2;
//	public Text popUpText3;
//	public string[] popUps;
//	int randLetters1;
//	int randLetters2;
//	int randLetters3;
//	int rand;
//	int letterAmount;
//
////	int caps = 0;
////	public GameObject capsKeyboardOn;
////	public GameObject capsKeyboardPerm;
////	public GameObject capsKeyboardOff;
//
//
//	public AudioSource BGM;
//	public AudioClip Keyboard1;
//	public AudioClip Keyboard2;
//	public AudioClip Keyboard3;
//	public AudioClip KeyboardEnter;
//	public AudioClip Typewriter;
//	public AudioClip TypewriterEnter;
//	public AudioClip Razerblack1;
//	public AudioClip Razerblack2;
//	public AudioClip Razerblack3;
//	public AudioClip RazerblackEnter;
//
//	public GameObject enemyHealthbar1;
//	public GameObject enemyHealthbar2;
//	public GameObject enemyHealthbar3;
//	public GameObject playerHealthbar;
//
//	int enemyHealth1 = EnemyS.enemyHealth1;
//	int enemyHealth2 = EnemyS.enemyHealth2;
//	int enemyHealth3 = EnemyS.enemyHealth3;
//	int playerHealth = PlayerS.playerHealth;
//
//	public Transform enemy1;
//	public Transform enemy2;
//	public Transform enemy3;
//
//	void Start (){
//
//		AudioSource audio = GetComponent<AudioSource>();
//		rand = Random.Range (0, 7);
//		DisplayWords (rand);
//
//	}
//
//	void DisplayWords (int rand){
//
//
//			switch (rand) {
//			case 0:
//				randLetters1 = Random.Range (0, 280);
//			EnemyS.enemyHealth1 = 100;
//				popUpText1.text = popUps [randLetters1];
//				enemyHealthbar1.SetActive (true);
//				enemyHealthbar2.SetActive (false);
//				enemyHealthbar3.SetActive (false);
//				letterAmount = 1;
//				break;
//			case 1:
//				randLetters2 = Random.Range (0, 280);
//			EnemyS.enemyHealth2 = 100;
//				popUpText2.text = popUps [randLetters2];
//				enemyHealthbar1.SetActive (false);
//				enemyHealthbar2.SetActive (true);
//				enemyHealthbar3.SetActive (false);
//				letterAmount = 1;
//				break;
//			case 2:
//				randLetters3 = Random.Range (0, 280);
//			EnemyS.enemyHealth3 = 100;
//				popUpText3.text = popUps [randLetters3];
//				enemyHealthbar1.SetActive (false);
//				enemyHealthbar2.SetActive (false);
//				enemyHealthbar3.SetActive (true);
//				letterAmount = 1;
//				break;
//			case 3:
//				randLetters1 = Random.Range (0, 280);
//				randLetters2 = Random.Range (0, 280);
//			EnemyS.enemyHealth1 = 100;
//			EnemyS.enemyHealth2 = 100;
//				popUpText1.text = popUps [randLetters1];
//				popUpText2.text = popUps [randLetters2];
//				enemyHealthbar1.SetActive (true);
//				enemyHealthbar2.SetActive (true);
//				enemyHealthbar3.SetActive (false);
//				letterAmount = 2;
//				break;
//			case 4:
//				randLetters1 = Random.Range (0, 280);
//				randLetters3 = Random.Range (0, 280);
//			EnemyS.enemyHealth1 = 100;
//			EnemyS.enemyHealth3 = 100;
//				popUpText1.text = popUps [randLetters1];
//				popUpText3.text = popUps [randLetters3];
//				enemyHealthbar1.SetActive (true);
//				enemyHealthbar2.SetActive (false);
//				enemyHealthbar3.SetActive (true);
//				letterAmount = 2;
//				break;
//			case 5:
//				randLetters2 = Random.Range (0, 280);
//				randLetters3 = Random.Range (0, 280);
//			EnemyS.enemyHealth2 = 100;
//			EnemyS.enemyHealth3 = 100;
//				popUpText2.text = popUps [randLetters2];
//				popUpText3.text = popUps [randLetters3];
//				enemyHealthbar1.SetActive (false);
//				enemyHealthbar2.SetActive (true);
//				enemyHealthbar3.SetActive (true);
//				letterAmount = 2;
//				break;
//			case 6:
//				randLetters1 = Random.Range (0, 280);
//				randLetters2 = Random.Range (0, 280);
//				randLetters3 = Random.Range (0, 280);
//			EnemyS.enemyHealth1 = 100;
//			EnemyS.enemyHealth2 = 100;
//			EnemyS.enemyHealth3 = 100;
//				popUpText1.text = popUps [randLetters1];
//				popUpText2.text = popUps [randLetters2];
//				popUpText3.text = popUps [randLetters3];
//				enemyHealthbar1.SetActive (true);
//				enemyHealthbar2.SetActive (true);
//				enemyHealthbar3.SetActive (true);
//				letterAmount = 3;
//				break;
//			}
//
//		}
//	
//	public void inputLetters (string alphabets){
//		letters += alphabets;
//		inputText.text = (letters);
//		GetComponent<AudioSource>().PlayOneShot (Razerblack2);
////		popUpText.text = popUpText.text.Remove (0, 1);
////		string newString;
////		newString = popUpText.text.Remove (0,1);
////		if (caps == 1) {
////			caps = 0;
////			capsKeyboardOn.SetActive(false);
////			capsKeyboardOff.SetActive (true);
//		}
//
//	public void BackSpace (){
//		string tempGetString = inputText.text;
//		if (tempGetString.Length > 0) {
//			string tempString = tempGetString.Substring(0, tempGetString.Length -1);
//			inputText.text = tempString;
//			letters = tempString;
//		}
//
//	}
//
//	public void PrintLetters (){
//
//
//		if(letters == popUpText1.text){
//			popUpText1.text = null;
//			letterAmount -= 1;
//			TimerS.time = 10;
//			TimerBarS.time = 10;
////			TimerBarS.transform.localScale = new Vector3 ((TimerBarS.time / 10), transform.localScale.y, transform.localScale.z);
//			EnemyS.enemyHealth1 -= 15;
//			//enemy1.localScale = new Vector3(EnemyS.enemyHealth1/100, 1,1);
//			print (EnemyS.enemyHealth1);
//			if (EnemyS.enemyHealth1 == 0){
//				enemyHealthbar1.SetActive(false);
//			}
//			print ("Good job!");
//			GetComponent<AudioSource>().PlayOneShot (RazerblackEnter);
//		}
//		else if (letters == popUpText2.text){
//			popUpText2.text = null;
//			letterAmount -= 1;
//			TimerS.time = 10;
//			TimerBarS.time = 10;
//			EnemyS.enemyHealth2 -= 15;
//			//enemy2.localScale = new Vector3(EnemyS.enemyHealth2/100, 1,1);
//			print (EnemyS.enemyHealth2);
//			if (EnemyS.enemyHealth2 == 0){
//				enemyHealthbar2.SetActive(false);
//			}
//			print ("Awesome dude!");
//			GetComponent<AudioSource>().PlayOneShot (RazerblackEnter);
//		}
//		else if (letters == popUpText3.text){
//			popUpText3.text = null;
//			letterAmount -= 1;
//			TimerS.time = 10;
//			TimerBarS.time = 10;
//			EnemyS.enemyHealth3 -= 15;
//			//enemy3.localScale = new Vector3(EnemyS.enemyHealth3/100, 1,1);
//			print (EnemyS.enemyHealth3);
//				if (EnemyS.enemyHealth3 == 0){
//				enemyHealthbar3.SetActive(false);
//				}
//			print ("You rock, man!");
//			GetComponent<AudioSource>().PlayOneShot (RazerblackEnter);
//		}
//		else {
//			print ("You suck, dude.");
//		}
//		if (letterAmount == 0) {
//			DisplayWords(Random.Range (0, 7));
//		}
//
//		letters = null;
//		inputText.text = null;
//
//	}
//
//	public void PrintPlayerHP (){
//		print (playerHealth);
//	}
//
//
//	public void PrintEnemyHP1 (){
//		print (enemyHealth1);
//	}
//
//	public void PrintEnemyHP2 (){
//		print (enemyHealth2);
//	}
//
//	public void PrintEnemyHP3 (){
//		print (enemyHealth3);
//	}
//
//	void Update ()
//	{
//
////		if (Input.GetKeyDown (KeyCode.Return)) {
////			PrintLetters();
////		}
////		if (Input.GetKeyDown (KeyCode.Backspace)){
////			BackSpace();
////		}
//	
////		Profiler.BeginSample ("Test");
//
//		if (Input.anyKeyDown) {
//			foreach (char c in Input.inputString) {
//				if (c == "\b"[0]){
//					BackSpace();
//				}
//				else{
//					if (c == "\n"[0] || c == "\r"[0])
//						PrintLetters();
//					else{
//						letters += c;
//						GetComponent<AudioSource>().PlayOneShot (Razerblack1);
//						inputText.text = (letters);
//					}
//				}
//			}
//		}
//
////		Profiler.EndSample ();
//	}
//
//
////	public void Caps (){
////		caps ++;
////		caps = caps % 3;
////		print(caps);
////	capsKeyboardPerm.SetActive(false);
////		if (caps == 2) {
////		capsKeyboardOn.SetActive(true);
////			capsKeyboardPerm.SetActive(true);
////		}
////	}
//}