using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerS : MonoBehaviour 
{
	public Text timerText;
	public static float time = 100;

	// Update is called once per frame
	void Update ()
	{
		if (FreezeTime.freez == false) {
			time -= Time.deltaTime;
			if (time < 10) {
				timerText.text = "0" + (int)time;
			}

			if (time < 0.01f) {
				time = 0;
				GameManager.gameOver.gameObject.SetActive (true);
			} else {
				timerText.text = "" + (int)time;
			}
		}
	}
}
