using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PointsDistribution : MonoBehaviour {


	public Text tempHp_;
	public Text tempAtk_;
	public Text tempDef_;


	void Awake (){

		tempHp_.text = "+" + (int)PlayerS.healthPts;
		tempAtk_.text = "+" + (int)PlayerS.atkPts;
		tempDef_.text = "+" + (int)PlayerS.defPts;
	}

	public void Hp (){
		if (PlayerS.statPoints > 0) {
			PlayerS.healthPts += 1;
			tempHp_.text = "+" + (int)PlayerS.healthPts;
			PlayerS.playerMaxHealth += 15;
//			PlayerS.playerHealth += 10;
			PlayerS.statPoints -= 1;
			PlayerS.tempStatPoints += 1;
		}
	}

	public void Atk (){
		if (PlayerS.statPoints > 0) {
			PlayerS.atkPts += 1;
			tempAtk_.text = "+" + (int)PlayerS.atkPts;
			PlayerS.playerAtk += 2;
			PlayerS.statPoints -= 1;
			PlayerS.tempStatPoints += 1;
		}
	}

	public void Def (){
		if (PlayerS.statPoints > 0) {
			PlayerS.defPts += 1;
			tempDef_.text = "+" + (int)PlayerS.defPts;
			PlayerS.playerDef += 2;
			PlayerS.statPoints -= 1;
			PlayerS.tempStatPoints += 1;
		}
	}



	public void HpUndo (){
		if (PlayerS.tempStatPoints > 0 && PlayerS.healthPts > 0) {
			PlayerS.healthPts -= 1;
			tempHp_.text = "+" + (int)PlayerS.healthPts;
			PlayerS.playerMaxHealth -= 15;
//			PlayerS.playerHealth -= 10;
			PlayerS.tempStatPoints -= 1;
			PlayerS.statPoints += 1;
		}
	}

	public void AtkUndo (){
		if (PlayerS.tempStatPoints > 0 && PlayerS.atkPts > 0) {
			PlayerS.atkPts -= 1;
			tempAtk_.text = "+" + (int)PlayerS.atkPts;
			PlayerS.playerAtk -= 2;
			PlayerS.tempStatPoints -= 1;
			PlayerS.statPoints += 1;
		}
	}

	public void DefUndo (){
		if (PlayerS.tempStatPoints > 0 && PlayerS.defPts > 0) {
			PlayerS.defPts -= 1;
			tempDef_.text = "+" + (int)PlayerS.defPts;
			PlayerS.playerDef -= 2;
			PlayerS.tempStatPoints -= 1;
			PlayerS.statPoints += 1;
		}
	}

	public void ApplyChanges (){

		PlayerS.healthPts = 0;
		PlayerS.atkPts = 0;
		PlayerS.defPts = 0;
		tempHp_.text = "+" + (int)PlayerS.healthPts;
		tempAtk_.text = "+" + (int)PlayerS.atkPts;
		tempDef_.text = "+" + (int)PlayerS.defPts;

	}
		
}
