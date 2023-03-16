using UnityEngine;
using System.Collections;

public class SFX : MonoBehaviour {

	public AudioClip enter;
	public AudioClip toggle;
	public AudioClip plus;
	public AudioClip minus;
	public AudioClip apply;
	public AudioClip bzzt;

	public static AudioSource audioSource;

	public void Awake (){

		audioSource = GetComponent<AudioSource> ();

	}

	public void EnterSFX(){
		audioSource.PlayOneShot (enter);
	}
		

	public void ToggleSFX(){
		audioSource.PlayOneShot (toggle);
	}
		

	public void PlusSFX(){
		audioSource.PlayOneShot (plus);
	}
		

	public void MinusSFX(){
		audioSource.PlayOneShot (minus);
	}


	public void ApplySFX(){
		audioSource.PlayOneShot (apply);
	}
		

	public void BzztSFX(){
		audioSource.PlayOneShot (bzzt);
	}
		

}
