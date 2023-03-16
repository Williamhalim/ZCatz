using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class GameManager
{
	public static int level = 1;
	public static int score;
	public static int expPts;

	public static int playerDust;

	public static int freezRemain = 5;
	public static int bFreezRemain = 5;

	public static Image gameOver;
	public static Text exp;
	public static Text levelUp;
	public static int selAvatar;
	public static int selSpell;
	public static int selSlot;

	public static int slot1current;
	public static int slot2current;
	public static int slot3current;

	public static string currentPosition;

	public static void GetTime(){

		Debug.Log (System.DateTime.UtcNow);

	}

	public static void Initialize()
	{
		
	}

	public static void UpdateScore (int randCol)
	{
		switch(randCol)
		{
			case 0:
				expPts+=1;
				break;
			case 1:
				expPts+=2;
				break;
			case 2:
				expPts+=5;
				break;
		case 3:
				//expPts += 10;
				gameOver.gameObject.SetActive (true);
				Time.timeScale = 0;
				break;
			default:

				break;
		}

		SaveGame ();

		if (expPts >= (level*(level-1))* 14+15) 
		{
			level+= 1;
		}

	}

	public static void SaveGame()
	{
		PlayerPrefs.SetInt ("Level", GameManager.level);
		PlayerPrefs.SetInt ("ExperiencePoints", GameManager.expPts);
		PlayerPrefs.SetInt ("TimeFreeze", GameManager.freezRemain);
		PlayerPrefs.SetInt ("ButtonFreeze", GameManager.bFreezRemain);
	}

	public static void LoadGame()
	{
		level = PlayerPrefs.GetInt ("Level");
		expPts = PlayerPrefs.GetInt ("ExperiencePoints");
		freezRemain = PlayerPrefs.GetInt ("TimeFreeze");
		bFreezRemain = PlayerPrefs.GetInt ("ButtonFreeze");
	}

}
