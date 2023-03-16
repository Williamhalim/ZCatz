using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HPBarStuff : MonoBehaviour 
{
	public Text hpPts;

	public float maxHp;
	public float currentHp;
	public float damagedHp;
	public float overTime;

	public float damage;

	public float heal;

	public Image greenBar;
	public Image damageTakenBar;




	public void Hit()
	{
		currentHp = currentHp - damage;
		greenBar.transform.localScale = new Vector3 ((currentHp / maxHp), greenBar.transform.localScale.y, greenBar.transform.localScale.z);

		if ((currentHp / maxHp) <= 0) 
		{
			currentHp = 0;
			greenBar.transform.localScale = new Vector3 (0, greenBar.transform.localScale.y, greenBar.transform.localScale.z);
		}

		StartCoroutine (DamageOverTime ());
	}

	public void HitHarder()
	{
		float harderDamage = damage * 2;
		currentHp = currentHp - harderDamage;
		greenBar.transform.localScale = new Vector3 ((currentHp / maxHp), greenBar.transform.localScale.y, greenBar.transform.localScale.z);

		if ((currentHp / maxHp) <= 0) 
		{
			currentHp = 0;
			greenBar.transform.localScale = new Vector3 (0, greenBar.transform.localScale.y, greenBar.transform.localScale.z);
		}

		StartCoroutine (DamageOverTime ());
	}



	public void Heal()
	{
		currentHp = currentHp + heal;
		greenBar.transform.localScale = new Vector3 ((currentHp / maxHp), greenBar.transform.localScale.y, greenBar.transform.localScale.z);
		damagedHp = damagedHp + heal;
		damageTakenBar.transform.localScale = new Vector3 ((currentHp / maxHp), greenBar.transform.localScale.y, greenBar.transform.localScale.z);

		if ((currentHp / maxHp) >= 1) 
		{
			currentHp = maxHp;
			greenBar.transform.localScale = new Vector3 (1, greenBar.transform.localScale.y, greenBar.transform.localScale.z);
			damageTakenBar.transform.localScale = new Vector3 (1, greenBar.transform.localScale.y, greenBar.transform.localScale.z);
		}
	}

	public void GreaterHeal()
	{
		float greaterHeal = heal * 2;
		currentHp = currentHp + greaterHeal;
		greenBar.transform.localScale = new Vector3 ((currentHp / maxHp), greenBar.transform.localScale.y, greenBar.transform.localScale.z);
		damagedHp = damagedHp + greaterHeal;
		damageTakenBar.transform.localScale = new Vector3 ((currentHp / maxHp), greenBar.transform.localScale.y, greenBar.transform.localScale.z);

		if ((currentHp / maxHp) >= 1) 
		{
			currentHp = maxHp;
			greenBar.transform.localScale = new Vector3 (1, greenBar.transform.localScale.y, greenBar.transform.localScale.z);
			damageTakenBar.transform.localScale = new Vector3 (1, greenBar.transform.localScale.y, greenBar.transform.localScale.z);
		}
	}

	IEnumerator DamageOverTime()
	{
		float timer = 0;

		while (damagedHp > currentHp) 
		{
			damagedHp--;
			timer += Time.deltaTime;
			damageTakenBar.transform.localScale -= new Vector3 (1,0,0) * Time.deltaTime * overTime;
			yield return null;
		}

	}


}
