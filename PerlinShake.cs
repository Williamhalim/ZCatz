using UnityEngine;
using System.Collections;

public class PerlinShake : MonoBehaviour {

	public RectTransform recTrans;
	Vector3 setPosition;
	Vector2 newPos;
	public float decayTime = 2;
	public float intensity;
	public float frequency;
//	float minPerlin = -1.0f, maxPerlin = 1.0f;
	Vector2 startPos;
	public static PerlinShake perlinShake;

	void Awake (){
		perlinShake = this;
	}
	// Use this for initialization
	void Start () {
		
		startPos = recTrans.localPosition;
		setPosition = transform.position;

	}

	void Update (){

		//newPos = setPosition;
	}

	public static void ShakeItBaby_(){
		
		perlinShake.StartCoroutine("ShakeItBaby");

	}

	public IEnumerator ShakeItBaby (){

		for (float t = 0; t <= decayTime; t += Time.deltaTime) {
			newPos.x = Mathf.PerlinNoise (newPos.x, newPos.y) * intensity;
			newPos.y = Mathf.PerlinNoise (newPos.x, newPos.y) * intensity;
			//newPos.y = Mathf.PerlinNoise (newPos.y * minPerlin, newPos.y * maxPerlin);

			recTrans.localPosition = newPos;
			yield return null;
		}

		recTrans.localPosition = startPos;

	}

}
