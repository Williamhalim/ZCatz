using UnityEngine;
using System.Collections;

public class FadeS : MonoBehaviour {

	public static FadeS fadeS;

	void Awake (){

		fadeS = this;

	}

	public static void FadeAway(){

		fadeS.StartCoroutine ("FadeMe");
	}

	public void FadeAway_ (){
		StartCoroutine (FadeMe ());
	}


	public IEnumerator FadeMe(){
		CanvasGroup canvasGroup = GetComponent <CanvasGroup> ();
		while (canvasGroup.alpha > 0) {
			canvasGroup.alpha -= Time.deltaTime;
			yield return null;
		}
		Destroy (gameObject);
	}

}