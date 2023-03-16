using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Reset : MonoBehaviour
{

	// Use this for initialization

	public void DeleteAll() {

		PlayerPrefs.DeleteAll ();

		}

	public void DeleteStageProgress(){

		SelectStage.desert2Locked = 1;
		PlayerPrefs.SetInt ("LockedDesert2", 1);
		SelectStage.desert2Unlocked = 0;
		PlayerPrefs.SetInt ("UnlockedDesert2", 0);
		SelectStage.desert3Locked = 0;
		PlayerPrefs.SetInt ("LockedDesert2", 0);
		SelectStage.desert3Unlocked = 0;
		PlayerPrefs.SetInt ("UnlockedDesert3", 0);
		SelectStage.desert4Locked = 0;
		PlayerPrefs.SetInt ("LockedDesert4", 0);
		SelectStage.desert4Unlocked = 0;
		PlayerPrefs.SetInt ("UnlockedForest", 0);
		SelectStage.boss1Locked = 0;
		PlayerPrefs.SetInt ("LockedBoss1", 0);
		SelectStage.boss1Unlocked = 0;
		PlayerPrefs.SetInt ("UnlockedBoss1", 0);

	}

}
