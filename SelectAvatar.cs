using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SelectAvatar : MonoBehaviour 
{
	public Transform[] allAvatars;
	public Transform avatarDisplay;
	Transform displayAvatar;

	int ava = GameManager.selAvatar;

	void Start()
	{

		if(displayAvatar != null)
		{
			Destroy (displayAvatar.gameObject);
		}

		displayAvatar = Instantiate (allAvatars [ava],avatarDisplay.position,Quaternion.identity) as Transform;
		displayAvatar.SetParent (avatarDisplay);
		displayAvatar.localScale = Vector3.one;
	}

	//SETTING THE SELECTED AVATAR TO SCENE.
	public void SelectAvatars (int avatar)
	{
		GameManager.selAvatar = avatar;
		PlayerPrefs.SetInt ("AvatarNumber", avatar);
	}

	//INSTANTIATING AVATAR FOR DISPLAY.
	public void LoadAvatar ()
	{
		int ava = GameManager.selAvatar;

		//DESTROYING THE PREVIOUSLY SELECTED AVATAR IF A NEW ONE IS SELECTED.
		if(displayAvatar != null)
		{
			Destroy (displayAvatar.gameObject);
		}

		displayAvatar = Instantiate (allAvatars [ava],avatarDisplay.position,Quaternion.identity) as Transform;
		displayAvatar.SetParent (avatarDisplay);
		displayAvatar.localScale = new Vector3 (1, 1, 1);
		GameManager.SaveGame ();
	}

}