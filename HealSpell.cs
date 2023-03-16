using UnityEngine;
using System.Collections;

public class HealSpell : MonoBehaviour {

	public static PlayerS playerS;

	public void UsePotionSmall (){
		if (ItemS.smallPotionRemain > 0) {
			playerS.HealSmall ();
			ItemS.smallPotionRemain -= 1;
		}

	}
}