using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerBarS : MonoBehaviour 
{
	public float time;
	public Image image;
	public Image image_;
	public float atk; 
	public int index;

	void Awake ()
	{
		image_ = image;
		time = Enemy.enemyAtkSpd;
	}

	// Use this for initialization
	void Start () 
	{
		image = GetComponent<Image> ();
		image_ = GetComponent<Image> ();
	} 

	// Update is called once per frame
	void Update ()
	{
		if (FreezeTime.freez == false && Instantiator.time <= 0) {
			time -= Time.deltaTime;
//			transform.localScale = new Vector3 ((time / Enemy.enemyAtkSpd), transform.localScale.y, transform.localScale.z);
//			if (time <= 1) {
//				image_.color = new Vector4 (1, 0, 0, 1);
//			}

			if (time <= 0.01f) {
				PlayerS.Damage (Enemy.enemyAtk);
				time = Enemy.enemyAtkSpd;
//				image_.color = new Vector4 (0, 0.5f, 1, 1);
			}

		}
	}

	public static void TimeStop ()
	{
		Time.timeScale = 0f;
	}
}
