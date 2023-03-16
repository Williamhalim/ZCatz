using UnityEngine;
using System.Collections;

public class FreezeTime : MonoBehaviour 
{
	public static bool freez;
	public static bool buttonFreez;

	public AudioClip freezeCast;
	public AudioClip freezeBreak;


	// Use this for initialization


	public void Freeze ()
	{
//		if (SpellS.freezRemain > 0) {
//		if (SpellS.spells[2] > 0){
			for (int i = 0; i < 4; i++) {
				if (WordManager.enemyS [i] != null) {
					freez = true;
					WordManager.enemyS [i].frozen.SetActive (true);
					Invoke ("ResumeTime", 5);
//					SpellS.freezRemain -= 1;
//					Destroy (gameObject);
					GetComponent<AudioSource> ().PlayOneShot (freezeCast);
					SpellS.spell1Cap.text = "x" + (int)SpellS.spells [2];
				}
//			}
		}
	}





	void ResumeTime()
	{
		freez = false;
		for (int i = 0; i < 4; i++) {
			if (WordManager.enemyS [i] != null) {
				WordManager.enemyS [i].frozen.SetActive (false);
				GetComponent<AudioSource>().PlayOneShot (freezeBreak);
			}
		}
	}
}
	
	
