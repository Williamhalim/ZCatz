using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public AudioClip enter;
	public static string lastlevel;

	AsyncOperation async; //for loadlevel progress
	public Image progressBar;
	public Image tapToContinue;
	float loadProgress;


	public void LoadCharStats ()
	{
		lastlevel = SceneManager.GetActiveScene().name;
		print ("roger");
		SceneManager.LoadScene ("CharacterStatus");
	}


	public void MainMenu()
	{
		lastlevel = SceneManager.GetActiveScene().name;
		async = Application.LoadLevelAsync ("MainMenu");
		GetComponent<AudioSource>().PlayOneShot (enter);
		StartCoroutine ("LoadProgress");
	}

	public void CatzDen()
	{
		lastlevel = SceneManager.GetActiveScene().name;
		SceneManager.LoadScene ("CatzDen");
	}

	public void Settings()
	{
		lastlevel = SceneManager.GetActiveScene().name;
		async = Application.LoadLevelAsync ("Settings");
	}

//	public void Dungeon()
//	{
//		lastlevel = SceneManager.GetActiveScene().name;
//		SceneManager.LoadScene ("Dungeon");
//	}
//

	public void Land1()
	{
		lastlevel = SceneManager.GetActiveScene().name;
		SceneManager.LoadScene ("Land1");
	}

	public void BossKeyboard1()
	{
		lastlevel = SceneManager.GetActiveScene().name;
		SceneManager.LoadScene ("BossBattle1");
		RandomEncounterS.BossDifficulty ();
	}


	public void WorldMap()
	{
		lastlevel = SceneManager.GetActiveScene().name;
		SceneManager.LoadScene ("WorldMap");
	}

	public void Back()
	{
		if (PlayerS.playerHealth <= 0) {
			SceneManager.LoadScene ("MainMenu");
		} else {
			SceneManager.LoadScene (lastlevel);
		}
	}


	IEnumerator LoadProgress()
	{
		print (async.progress);
		Debug.Log("Load Complete");
		yield return async;
	}
		
}
