using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Fireball : MonoBehaviour {

	public AudioClip fireballCast;


	public void CastFireball() {

//		if (SpellS.fireballRemain > 0) {
//		if (SpellS.spells[0] > 0){
			for(int i = 0; i < 4; i++) {
				if (WordManager.enemyS [i] != null) {
					WordManager.enemyS [i].FireballDamage ();
					SpellS.spell2Cap.text = "x" + (int)SpellS.spells [0];
					Instantiator.FireEffect ();
					GetComponent<AudioSource>().PlayOneShot (fireballCast);
				}
			}
//			SpellS.fireballRemain -= 1;
//			Destroy (gameObject);
			SpellS.spell2Cap.text = "x" + (int)SpellS.spells [0];
			if (WordManager.enemyAmount == 0) {
				WordManager.victoryScreen.SetActive (true);
				WordManager.keyboardCanvas.SetActive (false);
			}
//		}
	}
		

}