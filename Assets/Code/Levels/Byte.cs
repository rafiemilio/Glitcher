/*
---------------------------------------

Rafi Emilio Alam 
for the Game Off game jam

---------------------------------------
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Byte : MonoBehaviour {

	[SerializeField] GameObject collect;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Player") {

			GameObject collectClone = Instantiate(collect, transform.position, transform.rotation) as GameObject;
			collectClone.transform.SetParent(transform.parent);
			Destroy(collectClone, 1);
			gameObject.SetActive(false);
		}
	}
}
