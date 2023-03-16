using UnityEngine;
using System.Collections;

public class DoLoop : MonoBehaviour {

	float testTime = 4;

	// Use this for initialization
	void Start () {
	
		do {

			print ("spawned");


		} while(testTime <= 0);
		testTime = 4;
	}
	
	// Update is called once per frame
	void Update () {
		testTime -= Time.deltaTime;
		print (testTime);

	}
}
