/*
---------------------------------------

Rafi Emilio Alam 
for the Game Off game jam

---------------------------------------
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Source : MonoBehaviour {

	[SerializeField] Window win;
	[SerializeField] int corruption;

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Player") {
			if (Computer.corruption < corruption) {
				Computer.corruption++;
			}
			win.CloseWindow();
		}
	}
}
