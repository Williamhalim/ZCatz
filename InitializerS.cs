using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InitializerS : MonoBehaviour 
{

	static int loadedAvatar;

	// Use this for initialization
	void Awake()
	{
		PlayerS.LoadGame ();
		loadedAvatar = PlayerPrefs.GetInt ("AvatarNumber");
			PlayerPrefs.SetInt ("LockedDesert2", 1);
				SelectStage.desert2Locked = PlayerPrefs.GetInt ("LockedDesert2");
	}

	void Start () 
	{
	
	}
	
	// Update is called once per frame
//	void Update () 
//	{
//		exp.text = "" + GameManager.expPts;
//		levelUp.text = "" + GameManager.level;
//
//		freezRemain.text = "" + GameManager.freezRemain;
//		if (GameManager.freezRemain < 10) 
//		{
//			freezRemain.text = "0" + GameManager.freezRemain;
//		}
//
//		bFreezRemain.text = "" + GameManager.bFreezRemain;
//		if (GameManager.freezRemain < 10) 
//		{
//			bFreezRemain.text = "0" + GameManager.bFreezRemain;
//		}
//
//	}
}
