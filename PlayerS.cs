using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerS : MonoBehaviour {

//	Player Status --------------

	static public PlayerS playerS;

	public static float playerHealth = 100;
	public static float playerMaxHealth = 100;
	public static int playerAtk = 25;
	public static int playerDef = 25;
	public static float playerExp;
	public static int playerLvl = 1;
	public static float expNeeded;
	public static int statPoints; 
	public static int playerDamage;
	public static float playerArmor;

	public static float damagedHp;
	public float damageMovetime;

	public static List<int> spellSlot = new List<int> (3);


	public static int playerScore;


	public static int tempStatPoints;
	public static int healthPts;
	public static int atkPts;
	public static int defPts;
	public static int killCount;


	public Text level;
	public Text exp;
	public Text hp;
	public Text atk;
	public Text def;
	public Text points;
	public Text scoreDisplay;
	public Text catzKills;


//	----------------------------

	public Image lifebar;
	public Image damageBar;
	public Transform expbar;
	public GameObject missionFail_;
	public static GameObject missionFail;
	public static Image lifebar_;
	public static Image damageBar_;
	public static Transform expbar_;

	public static AudioClip healCast;


	void Awake (){
		playerS = this;
		missionFail = missionFail_;
		lifebar_ = lifebar;
		expbar_ = expbar;
		spellSlot.Add(0);
		spellSlot.Add(0);
		spellSlot.Add(0);
		damagedHp = playerHealth;
		playerDamage = playerAtk * 5;
		playerArmor = playerDef * 0.06f;
	}
		

	public void PrintSpellCap(){

		print (spellSlot.Count);

	}
		
	
	public static void Damage(float damage){
		if (playerHealth > 0) {
			damage = Enemy.enemyAtk - (playerArmor * Enemy.enemyAtk / 100);
			if (damage >= 0) {
				playerHealth -= damage;
				lifebar_.transform.localScale = new Vector3 ((playerHealth / playerMaxHealth), 1, 1);
//				PerlinShake.ShakeItBaby_ ();
				Instantiator.ClawEffect_ ();
				Instantiator.RedGlow_ ();
			} else if (damage <= 0) {
				damage = 1;
//				PerlinShake.ShakeItBaby_ ();
				Instantiator.ClawEffect_ ();
				Instantiator.RedGlow_ ();
			}
		}
		if (playerHealth <= 0) {
			playerHealth = 0;
			lifebar_.transform.localScale = new Vector3 ((playerHealth / playerMaxHealth), 1, 1);
			missionFail.SetActive (true);
		}
//		DamageOverTime_ ();	
	}

//	public static void DamageOverTime_(){
//		playerS.StartCoroutine ("DamageOverTime");
//	}
//
//	IEnumerator DamageOverTime()
//	{
//		while (damagedHp > playerHealth) 
//		{
//			damagedHp--;
//			damageBar.transform.localScale -= new Vector3 (1,0,0) * Time.deltaTime * damageMovetime;
//			yield return null;
//		}
//
//	}

	public void HealSmall (){
		if (playerHealth < playerMaxHealth && ItemS.smallPotionRemain > 0) {
			playerHealth += 20;
			damagedHp += 20;
			ItemS.smallPotionRemain -= 1;
			GetComponent<AudioSource>().PlayOneShot (healCast);
			if (playerHealth >= playerMaxHealth) {
				playerHealth = playerMaxHealth;
				GetComponent<AudioSource>().PlayOneShot (healCast);
			}
			lifebar_.transform.localScale = new Vector3 ((playerHealth / playerMaxHealth), 1, 1);
//			damageBar.transform.localScale = new Vector3 ((damagedHp / playerMaxHealth), 1, 1);
			if (Application.loadedLevelName == "WorldMap") {
				ItemS.smallPotionNotif_.SetActive (true);
			}
		}
	}

	public static void SaveGame()
	{
		PlayerPrefs.SetInt ("Level", PlayerS.playerLvl);
		PlayerPrefs.SetFloat ("ExperiencePoints", PlayerS.playerExp);
		PlayerPrefs.SetFloat ("MaxHP", PlayerS.playerMaxHealth);
		PlayerPrefs.SetFloat ("HP", PlayerS.playerHealth);
		PlayerPrefs.SetInt ("ATK", PlayerS.playerAtk);
		PlayerPrefs.SetInt ("DEF", PlayerS.playerDef);
		PlayerPrefs.SetInt ("StatPoints", PlayerS.statPoints);
		PlayerPrefs.SetInt ("PlayerScore", PlayerS.playerScore);
		PlayerPrefs.SetInt ("CatzKills", PlayerS.killCount);


//
//		PlayerPrefs.SetFloat ("AvatarXPos", SelectStage.avatarDisplay.transform.localPosition.x);
//		PlayerPrefs.SetFloat ("AvatarYPos", SelectStage.avatarDisplay.transform.localPosition.y);
	}

	public static void LoadGame()
	{
		playerLvl = PlayerPrefs.GetInt ("Level");
		if (playerLvl == 0) {
			playerLvl = 1;
		}

		playerMaxHealth = PlayerPrefs.GetFloat ("MaxHP");
		if (playerMaxHealth == 0) {
			playerMaxHealth = 100;
		}
		playerHealth = PlayerPrefs.GetFloat ("HP");
		if (playerHealth == 0) {
			playerHealth = 100;
			damagedHp = 100;
		}
		playerAtk = PlayerPrefs.GetInt ("ATK");
		if (playerAtk == 0) {
			playerAtk = 25;
		}
		playerDef = PlayerPrefs.GetInt ("DEF");
		if (playerDef == 0) {
			playerDef = 20;
		}
		playerExp = PlayerPrefs.GetInt ("ExperiencePoints");
		statPoints = PlayerPrefs.GetInt ("StatPoints");
		playerScore = PlayerPrefs.GetInt ("PlayerScore");
		killCount = PlayerPrefs.GetInt ("CatzKills");

		PlayerPrefs.GetInt ("UnlockedDesert2");
		SelectStage.desert2Unlocked = PlayerPrefs.GetInt ("UnlockedDesert2");
		PlayerPrefs.GetInt ("LockedDesert2");
			SelectStage.desert2Locked = PlayerPrefs.GetInt ("LockedDesert2");
		PlayerPrefs.GetInt ("UnlockedDesert3");
			SelectStage.desert3Unlocked = PlayerPrefs.GetInt ("UnlockedDesert3");
		PlayerPrefs.GetInt ("LockedDesert3");
			SelectStage.desert3Locked = PlayerPrefs.GetInt ("LockedDesert3");
		PlayerPrefs.GetInt ("UnlockedDesert4");
			SelectStage.desert4Unlocked = PlayerPrefs.GetInt ("UnlockedDesert4");
		PlayerPrefs.GetInt ("LockedDesert4");
			SelectStage.desert4Locked = PlayerPrefs.GetInt ("LockedDesert4");
		PlayerPrefs.GetInt ("UnlockedBoss1");
			SelectStage.boss1Unlocked = PlayerPrefs.GetInt ("UnlockedBoss1");
		PlayerPrefs.GetInt ("LockedBoss1");
			SelectStage.boss1Locked = PlayerPrefs.GetInt ("LockedBoss1");

		if (WorldInitializer.tempPos.x != null){

			WorldInitializer.tempPos.x = PlayerPrefs.GetFloat ("AvatarXPos");
			WorldInitializer.tempPos.y = PlayerPrefs.GetFloat ("AvatarYPos");

//			SelectStage.avatarDisplay_.transform.localPosition = WorldInitializer.tempPos;

		}
	}
		


	void Update (){

		level.text = "" +(int)playerLvl;
		hp.text = "" + (int)playerHealth + " / " + (int)playerMaxHealth;
		atk.text = "ATK: " + (int)playerAtk;
		def.text = "DEF: " + (int)playerDef;
		points.text = "" + (int)statPoints + " Pts";
		scoreDisplay.text = "" + playerScore;
		catzKills.text = "" + killCount;
		expNeeded = (playerLvl * (playerLvl - 1)) * 28 + 30;
		exp.text = "" + (int)playerExp + " / " + (int) expNeeded;
		expbar_.localScale = new Vector3 ((playerExp / expNeeded), 1, 1);

		lifebar_.transform.localScale = new Vector3 ((playerHealth / playerMaxHealth), 1, 1);

		if (playerHealth >= (playerMaxHealth * 3) / 4) {
			lifebar_.color = new Vector4 (0, 0, 1, 1);
		}

		if (playerHealth <= (playerMaxHealth * 3) / 4) {
			lifebar_.color = new Vector4 (0, 1, 0, 1);
		}

		if (playerHealth <= (playerMaxHealth * 2) / 4) {
			lifebar_.color = new Vector4 (1, 0.92f, 0.016f, 1);
		}

		if (playerHealth <= (playerMaxHealth * 1) / 4) {
			lifebar_.color = new Vector4 (1, 0, 0, 1);
		}

		if (playerExp >= expNeeded) {
			Instantiator.LevelUpNotif_ ();
				playerLvl += 1;
				playerMaxHealth += 15;
//				playerHealth = playerMaxHealth;
				damagedHp = playerMaxHealth;
				playerHealth += 15;
				playerAtk += 1;
				playerDef += 1;
				statPoints += 3;
				playerExp = 0;
			}

		SaveGame ();
			
	}

}