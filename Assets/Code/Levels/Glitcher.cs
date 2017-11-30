/*
---------------------------------------

Rafi Emilio Alam 
for the Game Off game jam

---------------------------------------
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Glitcher : MonoBehaviour {

	[SerializeField] float speed = 3; 
	[SerializeField] Transform glitch;

	Animator anim;
	int animState;

	// Use this for initialization
	void Start () {
		anim = glitch.GetComponent<Animator>();
	}

	// Update is called once per frame
	void FixedUpdate () {
		KeyMove();
	}

	void KeyMove() {

		Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
		move = move.normalized * Time.deltaTime * speed * 10;
	
		if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0) {
			glitch.GetComponent<Rigidbody>().velocity = Vector3.zero;
			if (animState != 0) {
				animState = 0;
				anim.SetInteger("state", animState);
			}
		} else {
			glitch.GetComponent<Rigidbody>().velocity = move;
			if (Input.GetAxis("Vertical") > 0) {
				if (animState != 1) {
					animState = 1;
					anim.SetInteger("state", animState);
				}
			} 
			if (Input.GetAxis("Vertical") < 0) {
				if (animState != 4) {
					animState = 4;
					anim.SetInteger("state", animState);
				}
			}
			if (Input.GetAxis("Horizontal") > 0) {
				if (animState != 3) {
					animState = 3;
					anim.SetInteger("state", animState);
				}
			} 
			if (Input.GetAxis("Horizontal") < 0) {
				if (animState != 2) {
					animState = 2;
					anim.SetInteger("state", animState);
				}
			}
		}


	}
}
