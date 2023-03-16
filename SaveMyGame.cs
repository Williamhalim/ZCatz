using UnityEngine;
using System.Collections;

public class SaveMyGame : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}

	void SaveGame()
	{
		PlayerPrefs.SetInt ("Level", GameManager.level);
		PlayerPrefs.SetInt ("ExperiencePoints", GameManager.expPts);
	}

	void LoadGame()
	{
		PlayerPrefs.GetInt ("Level");
		PlayerPrefs.GetInt ("ExperiencePoints");
	}

	// Update is called once per frame
	void Update () 
	{
	
	}
}
