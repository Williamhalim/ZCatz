using UnityEngine;
using System.Collections;

public class EnemyShake : MonoBehaviour {

	//	Vector3 setPosition;

	public RectTransform recTrans;
	Vector2 newPos;
	public float decayTime = 0.3f;
	public float intensity;
	public float frequency;
//	float minPerlin = -0.1f, maxPerlin = 0.1f;
	Vector2 startPos;
	public static EnemyShake enemyShake;

	// Use this for initialization
	void Start () {
		
		startPos = recTrans.localPosition;
//		setPosition = transform.position;

	}
		

	public void ShakeItBaby(){
		
		StartCoroutine("ShakeItBaby_");

	}

	public IEnumerator ShakeItBaby_ (){

		for (float t = 0; t <= decayTime; t += Time.deltaTime) {
			newPos.x = Mathf.PerlinNoise (newPos.x, newPos.y) * intensity;
//			newPos.y = Mathf.PerlinNoise (newPos.x, newPos.y) * intensity;

			recTrans.localPosition = newPos;
			yield return null;
		}


		recTrans.localPosition = startPos;

	}

}
