using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpellS : MonoBehaviour {

	public static int[] spells = new int[6];

	public static Text spell1Cap;
	public static Text spell2Cap;

	public Text spell1Cap_;
	public Text spell2Cap_;

	public Transform[] slots;
	Transform iconSpell1;
	Transform iconSpell2;
	Transform iconSpell3;
	public Transform[] spellIcons;

	public static int slot1current;
	public static int slot2current;
	public static int slot3current;

	static bool slot1empty;
	static bool slot2empty;
	static bool slot3empty;

	int selectedSlot;
	int equippedSpell;

	public int slottedBool;


//		SPELL INDEX   -----------------------------------------

//		0 = Fireball
//		1 = Lightning
//		2 = Freeze
//		3 = Shield
//		4 = Rage
//		5 = Reflect
//		-------------------------------------------------------


	public static Transform fireEffect;

	void Awake (){

		spell1Cap = spell1Cap_;
		spell2Cap = spell2Cap_;

		print (slot1empty);
		print (slot2empty);
		print (slot3empty);

		if (slot1empty == false) {
			slot1current = GameManager.slot1current;

			iconSpell1 = Instantiate (spellIcons [slot1current], slots [0].position, Quaternion.identity) as Transform;
			iconSpell1.SetParent (slots [0]);
			iconSpell1.localScale = new Vector3 (1, 1, 1);
		}

		if (slot2empty == false) {
			slot2current = GameManager.slot2current;

			iconSpell2 = Instantiate (spellIcons [slot2current], slots [1].position, Quaternion.identity) as Transform;
			iconSpell2.SetParent (slots [1]);
			iconSpell2.localScale = new Vector3 (1, 1, 1);

		}

		if (slot3empty == false) {
			slot3current = GameManager.slot3current;

			iconSpell3 = Instantiate (spellIcons [slot3current], slots [2].position, Quaternion.identity) as Transform;
			iconSpell3.SetParent (slots [2]);
			iconSpell3.localScale = new Vector3 (1, 1, 1);
		}
			
	}

	void Update(){
		spell1Cap_.text = "x" + (int)spells [2];
		spell2Cap_.text = "x" + (int)spells [0];
	}




	public void SelectSpells(int pickedSpell){
		GameManager.selSpell = pickedSpell;
	}

	public void SelectSlot(int slotSelected){
		GameManager.selSlot = slotSelected;
	}

	public void LoadSpell ()
	{
		equippedSpell = GameManager.selSpell;
		selectedSlot = GameManager.selSlot;
		if (selectedSlot == 0) {
			if (iconSpell1 != null) {
				Destroy (iconSpell1.gameObject);
			}
			if (spells [equippedSpell] >= 1) {
				iconSpell1 = Instantiate (spellIcons [equippedSpell], slots [selectedSlot].position, Quaternion.identity) as Transform;
				iconSpell1.SetParent (slots [selectedSlot]);
				iconSpell1.localScale = new Vector3 (1, 1, 1);

				spells [equippedSpell] -= 1;

				GameManager.slot1current = equippedSpell;
				slot1empty = false;
				print (GameManager.slot1current);
			}
		}

		if (selectedSlot == 1) {
			if (iconSpell2 != null) {
				Destroy (iconSpell2.gameObject);
			}
			if (spells [equippedSpell] >= 1) {
				iconSpell2 = Instantiate (spellIcons [equippedSpell], slots [selectedSlot].position, Quaternion.identity) as Transform;
				iconSpell2.SetParent (slots [selectedSlot]);
				iconSpell2.localScale = new Vector3 (1, 1, 1);

				spells [equippedSpell] -= 1;

				GameManager.slot2current = equippedSpell;
				slot2empty = false;
				print (GameManager.slot2current);
			}
		}

		if (selectedSlot == 2) {
			if (iconSpell3 != null) {
				Destroy (iconSpell3.gameObject);
			}
			if (spells [equippedSpell] >= 1) {
				iconSpell3 = Instantiate (spellIcons [equippedSpell], slots [selectedSlot].position, Quaternion.identity) as Transform;
				iconSpell3.SetParent (slots [selectedSlot]);
				iconSpell3.localScale = new Vector3 (1, 1, 1);

				spells [equippedSpell] -= 1;

				GameManager.slot3current = equippedSpell;
				slot3empty = false;
				print (GameManager.slot3current);
			}
		}

	}

	public void Unequip(){
		selectedSlot = GameManager.selSlot;
		if (selectedSlot == 0) {
			Destroy (iconSpell1.gameObject);
			slot1empty = true;
			print (slot1empty);
		}
		if (selectedSlot == 1) {
			Destroy (iconSpell2.gameObject);
			slot2empty = true;
			print (slot2empty);
		}
		if (selectedSlot == 2) {
			Destroy (iconSpell3.gameObject);
			slot3empty = true;
			print (slot3empty);
		}
	}


	public void AddFreeze(){
		spells [2] += 1;
	}

	public void AddFire(){
		spells [0] += 1;
	}

	public void ReduceFreeze(){
		spells [2] -= 1;
	}

	public void ReduceFire(){
		spells [0] -= 1;
	}
		

//	public void Print2(){
//		print(spells[2]);
//	}
//
//	public void Print0(){
//		print(spells[0]);
//	}
//
//	public void Bingo(){
//		if (spells[2] >= 9){
//			print ("Bingo!");
//		}
//		else {
//			print ("Boo.");
//		}
//
//	}

}
