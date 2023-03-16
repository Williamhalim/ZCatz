using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadLevel : MonoBehaviour 
{

	public void LoadCharStats ()
	{
		SceneManager.LoadScene ("CharacterStatus");
	}

	public void AdventureMap()
	{
		SceneManager.LoadScene ("AdventureMap");
	}

}
