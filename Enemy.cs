using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Enemy : MonoBehaviour {


//	Enemy Status ----------

	public float enemyHealth_;
	float enemyHealth;
	float enemyMaxHP;
	public float enemyAtk_;
	public static float enemyAtk;
	public static float enemyDamage;
	public float enemyDef_;
	public static float enemyDef;
	public static float enemyArmor;
	public float enemyAtkSpd_;
	public static float enemyAtkSpd;
	public int enemyExp_;
	public static int enemyExp;
	public int enemyScore_;
	public static int enemyScore;
	public int enemyDropRate_;
	public static int enemyDropRate;

	public static int enemyLvl_;
	int enemyLvl;

	int dropChance;
	int random;

	public bool isBoss;

	public static Instantiator instantiatorS;

	public Transform vanishEffect;


//	public static Enemy enemyScript;



//	------------------------


	public Text enemyText;
	public Transform lifebar;
	public int index;
	public TimerBarS timeBarS;
	public GameObject frozen;


	void Awake (){
		enemyAtk = (1.1f * Instantiator.stageIndex) + enemyAtk_ ;
		enemyHealth = (27.5f * Instantiator.stageIndex) + enemyHealth_;
		enemyMaxHP = enemyHealth;
		enemyAtkSpd = enemyAtkSpd_;
		enemyDropRate = enemyDropRate_;
		CheckCategory ();
		enemyDamage = enemyAtk_ * 2.75f;
		enemyArmor = enemyDef_ * 0.04f;
		random = Random.Range (0, 2);
	}

	public void CheckCategory(){
		if (tag == "DPS") {
			enemyAtk = enemyAtk * 1.2f;
			enemyDef = enemyDef * 0.8f;
		}
		if (tag == "Speeder") {
			enemyHealth = enemyHealth * 0.8f;
			enemyMaxHP = enemyHealth;
			enemyAtkSpd = enemyAtkSpd * 0.8f;
		}
		if (tag == "Tanker") {
			enemyHealth = enemyHealth * 1.2f;
			enemyMaxHP = enemyHealth;
			enemyAtk = enemyAtk * 0.8f;
			enemyDef = enemyDef * 1.2f;
		}
	}

	public void ChangeWord (){
		int rand = Random.Range (0, WordManager.wordLevel1.Length);
		enemyText.text = WordManager.wordLevel1 [rand];
		WordManager.text[index] = enemyText;
		// "this" keyword refers to the "Enemy" script instance that is attached to the enemy. 
		WordManager.enemyS [index] = this;
		if (tag == "Boss") {
			int randBoss = Random.Range (0, WordManager.wordLevel5.Length);
			enemyText.text = WordManager.wordLevel5 [randBoss];
			WordManager.text[index] = enemyText;
			WordManager.enemyS [index] = this;
		}
	}
		
				

	public void Damage(){
		if (enemyHealth > 0) {
			enemyHealth -= PlayerS.playerAtk - (enemyArmor * PlayerS.playerAtk / 100);
			timeBarS.time = Enemy.enemyAtkSpd;
			StartCoroutine(GetComponent<EnemyShake>().ShakeItBaby_ ());
//			timeBarS.image_.color = new Vector4 (0, 0.5f, 1, 1);
			lifebar.localScale = new Vector3 ((enemyHealth / enemyMaxHP), 1, 1);
		} else {
			enemyHealth = 0;
			lifebar.localScale = new Vector3 ((enemyHealth / enemyMaxHP), 1, 1);
		}
		if (enemyHealth <= 0) {
			WordManager.enemyAmount -= 1;
			Destroy (gameObject);
			print (index + " is killed");
			Instantiate (vanishEffect, new Vector3 (gameObject.transform.position.x,gameObject.transform.position.y,0) , Quaternion.identity);
			Destroy (gameObject);
			PlayerS.killCount += 1;
			PlayerS.playerExp += enemyExp_;
			PlayerS.playerScore += enemyScore_;
			Instantiator.spawnTime = 7;
			Instantiator.TimeToFight_ ();
			Spoils ();
		}
	}

	public void Spoils (){
		dropChance = Random.Range (0, 100);
		if (dropChance <= enemyDropRate_) {
			switch (random) {
//			if (WordManager.spoils1.text != null){
			case 0:
				SpellS.spells [2] += 1;
				WordManager.spoils1.text = "Freeze x1";
				break;
			case 1:
				SpellS.spells [0] += 1;
				WordManager.spoils2.text = "Fireball x1";
				break;
			}
			if (dropChance >= ItemS.smallPotionRarity) {
				WordManager.spoils3.text = "Potion (S) x1";
				ItemS.smallPotionRemain += 1;
			}

		}

	}
		

	public void FireballDamage(){
		
		if (enemyHealth > 0) {
			enemyHealth -= 45;
			lifebar.localScale = new Vector3 ((enemyHealth / enemyMaxHP), 1, 1);
		} else {
			enemyHealth = 0;
			lifebar.localScale = new Vector3 ((enemyHealth / enemyMaxHP), 1, 1);
		}
		if (enemyHealth <= 0) {
			WordManager.enemyAmount -= 1;
			PlayerS.playerExp += enemyExp_;
			PlayerS.playerScore += enemyScore_;
		}
	}

}
