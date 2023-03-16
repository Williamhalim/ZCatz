using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScreenDisplay : MonoBehaviour {

	public Text foodText;
	public static int foodAmt;


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		foodText.text = "" + foodAmt;

		} 

}
