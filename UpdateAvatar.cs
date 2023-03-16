using UnityEngine;
using System.Collections;

public class UpdateAvatar : MonoBehaviour
{
	public Transform[] allAvatars;
	public Transform avatarDisplay;
	public Transform displayAvatar;

	void Start () 
	{
		print (gameObject);
		int ava = GameManager.selAvatar;
		displayAvatar = Instantiate (allAvatars [ava],avatarDisplay.position,Quaternion.identity) as Transform;
	}

}
