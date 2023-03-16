using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Instantiator : MonoBehaviour {
	public Transform[] enemies;
	public Transform[] locators;
	public Transform[] clawLocs;
	public Transform[] clawFX;
	public Transform[] glowLoc;
	public Transform[] glowFX;

	public Transform[] textNotifs;
	public Transform notifLoc;

	public AudioClip clawedSFX;

	public Text timerText;
	public GameObject timerScreen;

	public static float time;
	public static float spawnTime = 0;
	public static float spawnInterval = 7;

	public bool enemy1spawned;
	public bool enemy2spawned;
	public bool enemy3spawned;
	public bool enemy4spawned;

	public static Instantiator instantiatorS;

	public static int stageIndex;

	int random;

	int randEnemy;
	int glowRange;

	public Transform fireEffect;
	public Transform fireLoc;


	// Use this for initialization
	void Start () {
		if (Application.loadedLevelName != "WorldMap") {
		randEnemy = Random.Range (0, 2);
		glowRange = Random.Range (0, 1);
		instantiatorS = this;
		random = Random.Range (0, 2);
			enemy1spawned = false;
			enemy2spawned = false;
			enemy3spawned = false;
			enemy4spawned = false;
			spawnTime = 0;

			timerScreen.SetActive (true);
			time = 4;
			InvokeRepeating ("TimeToFight", 4, 1);
		}
	}

	public static void TimeToFight_(){
		instantiatorS.StartCoroutine ("TimeToFight");
	}

	public void TimeToFight(){
		instantiatorS.StartCoroutine ("RandomPlacement");
	}
		

	void Update(){
		if (Application.loadedLevelName != "WorldMap") {
			time -= Time.deltaTime;
			timerText.text = "" + (int)time;
			if (time <= 1) {
				timerText.text = "FIGHT!";
			}
			if (time <= 0) {
				timerScreen.SetActive (false);
			}
		}


	}

	public void Test(){

		print ("enemy1spawned: " + (enemy1spawned));
		print ("enemy2spawned: " + (enemy2spawned));
		print ("enemy3spawned: " + (enemy3spawned));
		print ("enemy4spawned: " + (enemy4spawned));

		print ("Spawn Time: " + (float)spawnTime);
		print ("Enemy Amount: " + (int)WordManager.enemyAmount);

	}
		
	IEnumerator RandomPlacement (){
			Transform[] enemy = new Transform[3];
		switch (stageIndex) {
		case 1:
			if (spawnTime <= 1 && enemy1spawned == false) {
				WordManager.enemyAmount = 3;
				enemy [0] = Instantiate (enemies [0], locators [0].position, Quaternion.identity) as Transform;
				enemy [0].SetParent (locators [0]);
				enemy [0].localScale = Vector3.one;
				enemy [0].GetComponent<Enemy> ().index = 0;
				enemy [0].GetComponent<Enemy> ().ChangeWord ();
				instantiatorS.StartCoroutine ("SpawnTime");
				enemy1spawned = true;
			}

			yield return null;

//			yield return new WaitForSeconds (7);

			if (spawnTime >= 7 && enemy2spawned == false) {
				enemy [1] = Instantiate (enemies [0], locators [1].position, Quaternion.identity) as Transform;
				enemy [1].SetParent (locators [1]);
				enemy [1].localScale = Vector3.one;
				enemy [1].GetComponent<Enemy> ().index = 1;
				enemy [1].GetComponent<Enemy> ().ChangeWord ();
				spawnTime = 0;
				enemy2spawned = true;
				instantiatorS.StartCoroutine ("SpawnTime");
			}
			yield return null;
		
//			yield return new WaitForSeconds (7);

			if (spawnTime >= 7 && enemy3spawned == false) {
				enemy [2] = Instantiate (enemies [0], locators [2].position, Quaternion.identity) as Transform;
				enemy [2].SetParent (locators [2]);
				enemy [2].localScale = Vector3.one;
				enemy [2].GetComponent<Enemy> ().index = 2;
				enemy [2].GetComponent<Enemy> ().ChangeWord ();
				spawnTime = 0;
				enemy3spawned = true;
			}

			break;

		case 2:
			if (spawnTime <= 1 && enemy1spawned == false) {
				WordManager.enemyAmount = 2;
				randEnemy = Random.Range (0, 3);
				enemy [0] = Instantiate (enemies [1], locators [0].position, Quaternion.identity) as Transform;
				enemy [0].SetParent (locators [0]);
				enemy [0].localScale = Vector3.one;
				enemy [0].GetComponent<Enemy> ().index = 0;
				enemy [0].GetComponent<Enemy> ().ChangeWord ();

				instantiatorS.StartCoroutine ("SpawnTime");
				enemy1spawned = true;
			}
			yield return null;

//			yield return new WaitForSeconds (7);
			if (spawnTime >= 7 && enemy2spawned == false) {
				
				enemy [1] = Instantiate (enemies [randEnemy], locators [1].position, Quaternion.identity) as Transform;
				enemy [1].SetParent (locators [1]);
				enemy [1].localScale = Vector3.one;
				enemy [1].GetComponent<Enemy> ().index = 1;
				enemy [1].GetComponent<Enemy> ().ChangeWord ();

				enemy2spawned = true;
				spawnTime = 0;
			}
			break;

		case 3:

			if (spawnTime <= 1 && enemy1spawned == false) {
				WordManager.enemyAmount = 3;
				randEnemy = Random.Range (0, 3);
				enemy [0] = Instantiate (enemies [randEnemy], locators [0].position, Quaternion.identity) as Transform;
				enemy [0].SetParent (locators [0]);
				enemy [0].localScale = Vector3.one;
				enemy [0].GetComponent<Enemy> ().index = 0;
				enemy [0].GetComponent<Enemy> ().ChangeWord ();
				instantiatorS.StartCoroutine ("SpawnTime");
				enemy1spawned = true;
			}
			yield return null;

//			yield return new WaitForSeconds (7);

			if (spawnTime >= 7 && enemy2spawned == false) {
				enemy [1] = Instantiate (enemies [randEnemy], locators [1].position, Quaternion.identity) as Transform;
				enemy [1].SetParent (locators [1]);
				enemy [1].localScale = Vector3.one;
				enemy [1].GetComponent<Enemy> ().index = 1;
				enemy [1].GetComponent<Enemy> ().ChangeWord ();
				instantiatorS.StartCoroutine ("SpawnTime");
				enemy2spawned = true;
				spawnTime = 0;
			}
			yield return null;

//			yield return new WaitForSeconds (7);
			if (spawnTime >= 7 && enemy3spawned == false) {
				enemy [2] = Instantiate (enemies [randEnemy], locators [2].position, Quaternion.identity) as Transform;
				enemy [2].SetParent (locators [2]);
				enemy [2].localScale = Vector3.one;
				enemy [2].GetComponent<Enemy> ().index = 2;
				enemy [2].GetComponent<Enemy> ().ChangeWord ();
				enemy3spawned = true;
				spawnTime = 0;
			}
			break;

		case 4:

			if (spawnTime <= 1 && enemy1spawned == false) {
				WordManager.enemyAmount = 3;
				enemy [0] = Instantiate (enemies [0], locators [0].position, Quaternion.identity) as Transform;
				enemy [0].SetParent (locators [0]);
				enemy [0].localScale = Vector3.one;
				enemy [0].GetComponent<Enemy> ().index = 0;
				enemy [0].GetComponent<Enemy> ().ChangeWord ();

				instantiatorS.StartCoroutine ("SpawnTime");
				enemy1spawned = true;
			}
			yield return null;

//			yield return new WaitForSeconds (7);
			if (spawnTime >= 7 && enemy2spawned == false) {
				enemy [1] = Instantiate (enemies [1], locators [1].position, Quaternion.identity) as Transform;
				enemy [1].SetParent (locators [1]);
				enemy [1].localScale = Vector3.one;
				enemy [1].GetComponent<Enemy> ().index = 1;
				enemy [1].GetComponent<Enemy> ().ChangeWord ();
				instantiatorS.StartCoroutine ("SpawnTime");
				enemy2spawned = true;
				spawnTime = 0;
			}
			yield return null;
//			yield return new WaitForSeconds (7);

			if (spawnTime >= 7 && enemy3spawned == false) {
				enemy [2] = Instantiate (enemies [2], locators [2].position, Quaternion.identity) as Transform;
				enemy [2].SetParent (locators [2]);
				enemy [2].localScale = Vector3.one;
				enemy [2].GetComponent<Enemy> ().index = 2;
				enemy [2].GetComponent<Enemy> ().ChangeWord ();
				enemy3spawned = true;
				spawnTime = 0;
			}
			break;

		case 5:
			enemy = new Transform[5];

			if (spawnTime <= 1 && enemy1spawned == false) {
				WordManager.enemyAmount = 4;
				enemy [1] = Instantiate (enemies [1], locators [1].position, Quaternion.identity) as Transform;
				enemy [1].SetParent (locators [1]);
				enemy [1].localScale = Vector3.one;
				enemy [1].GetComponent<Enemy> ().index = 1;
				enemy [1].GetComponent<Enemy> ().ChangeWord ();

				instantiatorS.StartCoroutine ("SpawnTime");
				enemy1spawned = true;
			}
			yield return null;
//			yield return new WaitForSeconds (7);

			if (spawnTime >= 7 && enemy2spawned == false) {
				enemy [2] = Instantiate (enemies [1], locators [2].position, Quaternion.identity) as Transform;
				enemy [2].SetParent (locators [2]);
				enemy [2].localScale = Vector3.one;
				enemy [2].GetComponent<Enemy> ().index = 2;
				enemy [2].GetComponent<Enemy> ().ChangeWord ();
				instantiatorS.StartCoroutine ("SpawnTime");
				enemy2spawned = true;
				spawnTime = 0;
			}
			yield return null;
//			yield return new WaitForSeconds (7);
			if (spawnTime >= 7 && enemy3spawned == false) {
				enemy [0] = Instantiate (enemies [1], locators [0].position, Quaternion.identity) as Transform;
				enemy [0].SetParent (locators [0]);
				enemy [0].localScale = Vector3.one;
				enemy [0].GetComponent<Enemy> ().index = 0;
				enemy [0].GetComponent<Enemy> ().ChangeWord ();
				instantiatorS.StartCoroutine ("SpawnTime");
				enemy3spawned = true;
				spawnTime = 0;
			}
			yield return null;

//			yield return new WaitForSeconds (7);

			if (spawnTime >= 7 && enemy4spawned == false && WordManager.enemyAmount == 1) {
				enemy [3] = Instantiate (enemies [0], locators [3].position, Quaternion.identity) as Transform;
				enemy [3].SetParent (locators [3]);
				enemy [3].localScale = Vector3.one;
				enemy [3].GetComponent<Enemy> ().index = 3;
				enemy [3].GetComponent<Enemy> ().ChangeWord ();
				enemy4spawned = true;
				spawnTime = 0;
			}
			break;
		}
	}

	public void VanishFX(){

	}
		

	IEnumerator SpawnTime()
	{
		while (spawnTime <= spawnInterval)
		{
			spawnTime += Time.deltaTime;
			yield return null;
		}
	}

		

	public static void ClawEffect_ (){		
		instantiatorS.StartCoroutine ("ClawEffect");
	}

	public void LevelUpNotif(){

		Transform[] levelUp = new Transform[1];

		levelUp [0] = Instantiate (textNotifs [0], notifLoc.position, Quaternion.identity) as Transform;
		levelUp [0].SetParent (notifLoc);
		levelUp [0].localScale = Vector3.one;
		FadeS.FadeAway ();
	}

	public static void LevelUpNotif_ (){
		if (Application.loadedLevelName != "WorldMap") {
			instantiatorS.StartCoroutine ("LevelUpNotif");
		}
	}	


	public void ClawEffect (){
		Transform[] claw = new Transform[3];
		switch (random) {
		case 0:
			claw [0] = Instantiate (clawFX [0], clawLocs [0].position, Quaternion.identity) as Transform;
			claw [0].SetParent (clawLocs [0]);
			claw [0].localScale = Vector3.one;
			FadeS.FadeAway ();
			GetComponent<AudioSource>().PlayOneShot (clawedSFX);
			break;
		case 1:
//			for (int i = 0; i < 2; i++) {
			claw [1] = Instantiate (clawFX [1], clawLocs [1].position, Quaternion.identity) as Transform;
			claw [1].SetParent (clawLocs [1]);
			claw [1].localScale = Vector3.one;
			FadeS.FadeAway ();
			GetComponent<AudioSource>().PlayOneShot (clawedSFX);
//			}
			break;
		case 2:
//			for (int i = 0; i < 3; i++) {
			claw [2] = Instantiate (clawFX [2], clawLocs [2].position, Quaternion.identity) as Transform;
			claw [2].SetParent (clawLocs [2]);
			claw [2].localScale = Vector3.one;
			FadeS.FadeAway ();
			GetComponent<AudioSource>().PlayOneShot (clawedSFX);
//			}
			break;
		}
	}

	public static void RedGlow_ (){
		instantiatorS.StartCoroutine ("RedGlow");
	}


	public void RedGlow(){
		Transform[] glow = new Transform[3];
		switch (random){
		case 0:
			glow [0] = Instantiate (glowFX [glowRange], glowLoc [glowRange].position, Quaternion.identity) as Transform;
			glow [0].SetParent (glowLoc [glowRange]);
			glow [0].localScale = Vector3.one;
			FadeS.FadeAway ();
			break;
		case 1:
			glow [1] = Instantiate (glowFX [glowRange], glowLoc [glowRange].position, Quaternion.identity) as Transform;
			glow [1].SetParent (glowLoc [glowRange]);
			glow [1].localScale = Vector3.one;
			FadeS.FadeAway ();
			break;
		case 2:
			glow [2] = Instantiate (glowFX [glowRange], glowLoc [glowRange].position, Quaternion.identity) as Transform;
			glow [2].SetParent (glowLoc [glowRange]);
			glow [2].localScale = Vector3.one;
			FadeS.FadeAway ();
			break;
		}
	}

	public static void FireEffect(){
		instantiatorS.StartCoroutine ("FireEffect_");
	}

	public void FireEffect_(){
		Transform[] fire = new Transform[2];
		switch (0){
		case 0:
			fire [0] = Instantiate (fireEffect, fireLoc.position, Quaternion.identity) as Transform;
			fire [0].SetParent (fireLoc);
			break;
		}
	}
		
		
}
