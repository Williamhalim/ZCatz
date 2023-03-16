using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemS : MonoBehaviour {

	public Text smallPotionDisplay;
	public GameObject smallPotionNotif;
	public static GameObject smallPotionNotif_;

	public static int smallPotionRemain = 3000;

	public static int smallPotionRarity = 20;

	void Awake(){
		smallPotionNotif_ = smallPotionNotif;
	}

	void Update (){

		smallPotionDisplay.text = "" + (int)smallPotionRemain;

	}

}
