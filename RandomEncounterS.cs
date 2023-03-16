using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class RandomEncounterS : MonoBehaviour {

	int rand;
	public GameObject battleLoading;

	public AudioClip encounter;
	public AudioClip chestOpen;

	public void Encounter (){

		rand = Random.Range (0, 2);

		switch (rand) {
		case 0:
			print ("You found some food!");
			GetComponent<AudioSource> ().PlayOneShot (chestOpen);
			ScreenDisplay.foodAmt += 15;
			break;
		case 1:
			print ("You are under attack!!!");
			GetComponent<AudioSource> ().PlayOneShot (encounter);
			battleLoading.SetActive (true);
			if (Application.loadedLevelName == "Dungeon") {
				SceneManager.LoadScene ("Keyboard");
			}
			if (Application.loadedLevelName == "Dungeon2") {
				SceneManager.LoadScene ("Keyboard2");
			}
			if (Application.loadedLevelName == "Dungeon3") {
				SceneManager.LoadScene ("Keyboard3");
			}
			if (Application.loadedLevelName == "Dungeon4") {
				SceneManager.LoadScene ("Keyboard4");
			}
				break;
		}

	}

	public static void BossDifficulty(){

	}


	public void DifficultyLevel(){

	}

}