using UnityEngine;
using System.Collections;

public class WorldInitializer : MonoBehaviour {

	public static Vector3 tempPos;


	public void InitializeAvatarPos (){

		tempPos.x = PlayerPrefs.GetFloat ("AvatarXPos");
		tempPos.y = PlayerPrefs.GetFloat ("AvatarYPos");

		SelectStage.avatarDisplay.transform.localPosition = tempPos;

	}

}
