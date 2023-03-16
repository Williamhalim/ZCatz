using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ListTest : MonoBehaviour {

	public List<int> mySpells = new List<int>();

	public Transform[] locatorsIcon;
	public Transform[] iconsTest;

	Transform[] spellNew = new Transform[3];

	bool slot1occ;
	bool slot2occ;
	bool slot3occ;


	public void At1(){


		spellNew [0] = Instantiate (iconsTest [0], locatorsIcon [0].position, Quaternion.identity) as Transform;
		spellNew [0].SetParent (locatorsIcon [0]);
		spellNew [0].localScale = Vector3.one;
		UseSpell1 ();
		slot1occ = true;

	}

	public void At2(){

		if (slot1occ == false) {
			spellNew [0] = Instantiate (iconsTest [1], locatorsIcon [0].position, Quaternion.identity) as Transform;
			spellNew [0].SetParent (locatorsIcon [0]);
			spellNew [0].localScale = Vector3.one;
			UseSpell2 ();
			slot1occ = true;
		}
		if (slot1occ == true) {
			spellNew [1] = Instantiate (iconsTest [1], locatorsIcon [1].position, Quaternion.identity) as Transform;
			spellNew [1].SetParent (locatorsIcon [1]);
			spellNew [1].localScale = Vector3.one;
			UseSpell3 ();
			slot2occ = true;
		}


	}

	public void At3(){


		spellNew [2] = Instantiate (iconsTest [2], locatorsIcon [2].position, Quaternion.identity) as Transform;
		spellNew [2].SetParent (locatorsIcon [2]);
		spellNew [2].localScale = Vector3.one;

	}



	public void AddSpell (){

		mySpells.Add (SpellS.spells[2]);

	}

	public void Add9(){

		mySpells.Add (1);
	}

	public void RemoveSpell1(){
		if (mySpells [0] != null) {
			mySpells.RemoveAt (0);
		}
	}

	public void RemoveSpell2(){
		if (mySpells [1] != null) {
			mySpells.RemoveAt (1);
		}
	}

	public void RemoveSpell3(){
		if (mySpells [2] != null) {
			mySpells.RemoveAt (2);
		}
	}

	public void UseSpell1(){
		if (mySpells [0] >= 1) {
			mySpells[0] -= 1;
		}
	}

	public void UseSpell2(){
		if (mySpells [1] >= 1) {
			mySpells[1] -= 1;
		}
	}

	public void UseSpell3(){
		if (mySpells [2] >= 1) {
			mySpells[2] -= 1;
		}
	}

	public void AddSpell1(){
		if (mySpells[0] == 0) {
			mySpells[0] += 1;
		}
	}

	public void AddSpell2(){
		if (mySpells[1] == 0) {
			mySpells[1] += 1;
		}
	}

	public void AddSpell3(){
		if (mySpells[2] == 0) {
			mySpells[2] += 1;
		}
	}


}
