using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class SelectStage : MonoBehaviour 
{
	public static AudioSource audioSource;
	public AudioClip bzzt;

	public Transform[] allAvatars;
	Transform displayAvatar;
	public static Transform avatarDisplay;
	public Transform avatarDisplay_;

	int ava = GameManager.selAvatar;

	public static int difficultyLevel;

	public GameObject unlockedNotif;
	public GameObject notEnoughPoints;

	public GameObject enterDesert1;
	public GameObject enterDesert2;
	public GameObject enterDesert3;
	public GameObject enterDesert4;
	public GameObject enterBoss1;

	public GameObject unlockedDesert2;
	public GameObject unlockedDesert3;
	public GameObject unlockedDesert4;
	public GameObject unlockedBoss1;

	public GameObject lockedDesert2;
	public GameObject lockedDesert3;
	public GameObject lockedDesert4;
	public GameObject lockedBoss1;

	public static int desert2Unlocked;
	public static int desert3Unlocked;
	public static int desert4Unlocked;
	public static int boss1Unlocked;

	public static int desert2Locked;
	public static int desert3Locked;
	public static int desert4Locked;
	public static int boss1Locked;


	public float speed = 2.2f;
	float t;
	bool canSelect = true;



	void Start()
	{
		audioSource = GetComponent<AudioSource> ();


		avatarDisplay = avatarDisplay_;

		if (desert2Unlocked == 1) {
			unlockedDesert2.SetActive (true);
		}
			else {
				unlockedDesert2.SetActive (false);
			}


		if (desert2Locked == 1) {
			lockedDesert2.SetActive (true);
		}
			else {
				lockedDesert2.SetActive (false);
			}

		if (desert3Unlocked == 1) {
			unlockedDesert3.SetActive (true);
		}
			else {
				unlockedDesert3.SetActive (false);
			}

		if (desert3Locked == 1) {
			lockedDesert3.SetActive (true);
		}
			else {
				lockedDesert3.SetActive (false);
			}

		if (desert4Unlocked == 1) {
			unlockedDesert4.SetActive (true);
		}
			else {
				unlockedDesert4.SetActive (false);
			}

		if (desert4Locked == 1) {
			lockedDesert4.SetActive (true);
		}
			else {
				lockedDesert4.SetActive (false);
			}

		if (boss1Unlocked == 1) {
			unlockedBoss1.SetActive (true);
		}
			else {
				unlockedBoss1.SetActive (false);
			}

		if (boss1Locked == 1) {
			lockedBoss1.SetActive (true);
		}
			else {
				lockedBoss1.SetActive (false);
			}





		//INSTANTIATING SELECTED AVATAR FROM GAMEMANAGER.
		displayAvatar = Instantiate (allAvatars [ava],avatarDisplay.position,Quaternion.identity) as Transform;
		displayAvatar.SetParent (avatarDisplay);
		displayAvatar.localScale = new Vector3(2,2,2);
		//PLAYS RUNNING ANIMATION FOR AVATAR.
//		displayAvatar.transform.GetChild (0).GetComponent<Animator> ().SetBool ("Run", true);
		displayAvatar.transform.GetComponent<Animator> ().SetBool ("Loading...", true);

		if (GameManager.currentPosition != null) 
		{
			avatarDisplay_.transform.position = GameObject.Find (GameManager.currentPosition).transform.position;

			PlayerPrefs.SetFloat ("AvatarXPos", SelectStage.avatarDisplay.transform.localPosition.x);
			PlayerPrefs.SetFloat ("AvatarYPos", SelectStage.avatarDisplay.transform.localPosition.y);
		}
			
	}
		

	int selectedPos;
	int currentPos;
	List<Transform> paths = new List<Transform>();


	//ENTER THE LEVEL WHEN THE BUTTON IS CLICKED
	public void StageSelect ()
	{
		if (!canSelect) 
		{
			return;
		}
		canSelect = false;
		//CLEAR paths LIST
		paths.Clear ();
		//RECCORDING THE TRANSFORM POSITION OF THE CLICKED GAMEOBJECT.
		GameObject selected = EventSystem.current.currentSelectedGameObject;
		//CONVERTING STRINGS TO INT.
		int.TryParse(GameManager.currentPosition, out currentPos);
		int.TryParse (selected.gameObject.name, out selectedPos);
		//COLLECTING AND STORING STAGE BUTTON TRANSFORM TO paths LIST FOR AVATAR TO MOVE TOWARDS.
		if (currentPos < selectedPos) 
		{
			for (int i = currentPos; i <= selectedPos; i++) 
			{
				if (i != currentPos) 
				{
					Transform s = GameObject.Find (i.ToString ()).transform;
					paths.Add (s);
				}
			}
		} 
		else 
		{
			for (int i = currentPos; i >= selectedPos; i--) 
			{
				if (i != currentPos) 
				{
					Transform s = GameObject.Find (i.ToString ()).transform;
					paths.Add (s);
				}
			}
		}
			

		//TELEPORTS AVATAR IF SELECTION IS +/- 5 STAGES DIFFERENCE.
		if (currentPos - selectedPos  > 4 || selectedPos - currentPos > 4) 
		{
			avatarDisplay.transform.position = selected.transform.position;
			canSelect = true;
		}
		//CAUSE AVATAR TO RUN IF SELECTION IS WITHIN 5 STAGES.
		else
		{
			StopCoroutine("Move");
			StartCoroutine ("Move", selected.transform);
		}
		//OPENING enterStage MENU WHEN AVATAR REACHES SELECTED STAGE. (unused script)
//		if (avatarDisplay.transform.localPosition == selected.transform.localPosition)
//		{
//			print ("test");
//			enterDesert.SetActive (true);
//		}

		print ("avatarpos"+ avatarDisplay.transform.localPosition);
		print ("buttonpos" + selected.transform.localPosition);

		//SAVING NAME OF LAST CLICKED BUTTON TO GAME MANAGER FOR FUTURE LOAD.
		GameManager.currentPosition = selected.gameObject.name;
		GameManager.SaveGame();
	}

	public void ChangeDirection()
	{

	}


	// MOVING AVATAR TO CLICKED POSITION
	IEnumerator Move(Transform location)
	{
		//RECALLING THE FUNCTION FOR EVERY TRANSFORM p IN paths LIST.
		foreach (Transform p in paths) 
		{
			Vector3 initPos = avatarDisplay.transform.localPosition;
			float distance = 1;
			t = 0;
			if (avatarDisplay.transform.localPosition.x < p.localPosition.x) 
			{
				displayAvatar.localScale = new Vector3 (2,2,2);
			} 
			else 
			{
				displayAvatar.localScale = new Vector3 (-2, 2, 2);
			}
			while (distance > 0.01f) 
			{
				//MOVING TOWARDS TARGET POSITION.
				t += Time.deltaTime * speed * 2;
				avatarDisplay.transform.localPosition = Vector3.MoveTowards (initPos, p.localPosition, t);
				distance = Vector3.Distance (avatarDisplay.transform.localPosition, p.localPosition);
				//CHANGES AVATAR FACING DIRECTIONS.
				//WILLLIAM FIX THE GLITCH------------------


				yield return null;
			}
			yield return null;
		}
			
		canSelect = true;
		if (avatarDisplay.transform.localPosition.x == -928 && avatarDisplay.transform.localPosition.y == -1187) { 
			enterDesert1.SetActive (true);
//			SFX.ToggleSFX ();
		}
		if (avatarDisplay.transform.localPosition.x == -712 && avatarDisplay.transform.localPosition.y == -1198) { 
			enterDesert2.SetActive (true);
//			SFX.ToggleSFX ();
		}
		if (avatarDisplay.transform.localPosition.x == -503 && avatarDisplay.transform.localPosition.y == -1200) { 
			enterDesert3.SetActive (true);
//			SFX.ToggleSFX ();
		}
		if (avatarDisplay.transform.localPosition.x == -531 && avatarDisplay.transform.localPosition.y == -1010) { 
			enterDesert4.SetActive (true);
//			SFX.ToggleSFX ();
		}
		if (avatarDisplay.transform.localPosition.x == -626 && avatarDisplay.transform.localPosition.y == -846) { 
			enterBoss1.SetActive (true);
//			SFX.ToggleSFX ();
		}
	}

	public void Stage1 (){
		Instantiator.stageIndex = 1;
	}

	public void Stage2 (){
		Instantiator.stageIndex = 2;
		difficultyLevel = 2;
	}

	public void Stage3 (){
		Instantiator.stageIndex = 3;
		difficultyLevel = 3;
	}

	public void Stage4 (){
		Instantiator.stageIndex = 4;
		difficultyLevel = 4;
	}

	public void Stage5 (){
		Instantiator.stageIndex = 5;
		difficultyLevel = 5;
	}

	public void UnlockDesert2 (){
		if (PlayerS.playerScore >= 50) {
			PlayerS.playerScore -= 50;
			unlockedDesert2.SetActive (true);
			PlayerPrefs.SetInt ("UnlockedDesert2", 1);
			desert2Unlocked = PlayerPrefs.GetInt ("UnlockedDesert2");

			lockedDesert2.SetActive (false);
			PlayerPrefs.SetInt ("LockedDesert2", 0);
			desert2Locked = PlayerPrefs.GetInt ("LockedDesert2");

			lockedDesert3.SetActive (true);
			PlayerPrefs.SetInt ("LockedDesert3", 1);
			desert3Locked = PlayerPrefs.GetInt ("LockedDesert3");

			unlockedNotif.SetActive (true);
////			SFX.EnterSFX ();
		} else if (PlayerS.playerScore < 50) {
			BzztSFX ();
			notEnoughPoints.SetActive (true);
		}
//		else {
////			SFX.BzztSFX ();
//		}
	}

	public void UnlockDesert3 (){
		if (PlayerS.playerScore >= 80) {
			PlayerS.playerScore -= 80;
			unlockedDesert3.SetActive (true);
			PlayerPrefs.SetInt ("UnlockedDesert3", 1);
			desert3Unlocked = PlayerPrefs.GetInt ("UnlockedDesert3");

			lockedDesert3.SetActive (false);
			PlayerPrefs.SetInt ("LockedDesert3", 0);
			desert3Locked = PlayerPrefs.GetInt ("LockedDesert3");

			lockedDesert4.SetActive (true);
			PlayerPrefs.SetInt ("LockedDesert4", 1);
			desert4Locked = PlayerPrefs.GetInt ("LockedDesert4");
//			SFX.EnterSFX ();
			unlockedNotif.SetActive (true);
		}
//		else {
//			SFX.BzztSFX ();
//		}
	}

	public void UnlockDesert4 (){
		if (PlayerS.playerScore >= 110) {
			PlayerS.playerScore -= 110;
			unlockedDesert4.SetActive (true);
			PlayerPrefs.SetInt ("UnlockedDesert4", 1);
			desert4Unlocked = PlayerPrefs.GetInt ("UnlockedDesert4");

			lockedDesert4.SetActive (false);
			PlayerPrefs.SetInt ("LockedDesert4", 0);
			desert4Locked = PlayerPrefs.GetInt ("LockedDesert4");

			lockedBoss1.SetActive (true);
			PlayerPrefs.SetInt ("LockedBoss1", 1);
			boss1Locked = PlayerPrefs.GetInt ("LockedBoss1");

			unlockedNotif.SetActive (true);
//			SFX.EnterSFX ();
		}
//		else {
//			SFX.BzztSFX ();
//		}
	}

	public void UnlockBoss1 (){
		if (PlayerS.playerScore >= 150) {
			PlayerS.playerScore -= 150;
			unlockedBoss1.SetActive (true);
			PlayerPrefs.SetInt ("UnlockedBoss1", 1);
				boss1Unlocked = PlayerPrefs.GetInt ("UnlockedBoss1");

			lockedBoss1.SetActive (false);
			PlayerPrefs.SetInt ("LockedBoss1", 0);
			boss1Locked = PlayerPrefs.GetInt ("LockedBoss1");

			unlockedNotif.SetActive (true);
//			SFX.EnterSFX ();
		}
//		else {
//			SFX.BzztSFX();
//		}
	}		

	public void BzztSFX(){
			audioSource.PlayOneShot (bzzt);
	}


}
