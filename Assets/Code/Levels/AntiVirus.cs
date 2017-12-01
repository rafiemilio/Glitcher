/*
---------------------------------------

Rafi Emilio Alam 
for the Game Off game jam

---------------------------------------
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiVirus : MonoBehaviour {

	public GameObject player;
	[SerializeField] Transform[] nodes;
	[SerializeField] float speed = 1;
	
	[SerializeField] bool clockwise;
	
	int currentNode;

	int animState;
	[SerializeField] Animator anim;
	Vector3 move;
	
	void FixedUpdate () {

		if (player) {
			Follow();	
		} else {
			Patrol();
		}	
	}

	void Patrol () {


		if (currentNode == 0) {
			if (!clockwise) {

				if (animState != 2) {
					animState = 2;
					anim.SetInteger("state", animState);
				}
				if (transform.position.x > nodes[currentNode].position.x) {
					transform.position = new Vector3 (transform.position.x - speed, transform.position.y, transform.position.z);
				} else {
					transform.position = new Vector3 (nodes[currentNode].position.x, transform.position.y , transform.position.z);
					currentNode = 3 ;
				}
			} else {

				if (animState != 2) {
					animState = 2;
					anim.SetInteger("state", animState);
				}

				if (transform.position.x > nodes[currentNode].position.x) {
					transform.position = new Vector3 (transform.position.x - speed, transform.position.y, transform.position.z);
				} else {
					transform.position = new Vector3 (nodes[currentNode].position.x, transform.position.y , transform.position.z);
					currentNode++;
				}
			}
		}

		if (currentNode == 1) {
			if (!clockwise) {
				if (animState != 1) {
					animState = 1;
					anim.SetInteger("state", animState);
				}
				if (transform.position.y < nodes[currentNode].position.y) {
					transform.position = new Vector3 (transform.position.x, transform.position.y + speed, transform.position.z);
				} else {
					transform.position = new Vector3 (transform.position.x, nodes[currentNode].position.y , transform.position.z);
					currentNode = 0;
				}
			} else {
				if (animState != 1) {
					animState = 1;
					anim.SetInteger("state", animState);
				}
				if (transform.position.y < nodes[currentNode].position.y) {
					transform.position = new Vector3 (transform.position.x, transform.position.y + speed, transform.position.z);
				} else {
					transform.position = new Vector3 (transform.position.x, nodes[currentNode].position.y , transform.position.z);
					currentNode++;
				}

			}
		}

		if (currentNode == 2) {
			if (!clockwise) {
				if (animState != 3) {
					animState = 3;
					anim.SetInteger("state", animState);
				}
				if (transform.position.x < nodes[currentNode].position.x) {
					transform.position = new Vector3 (transform.position.x + speed, transform.position.y, transform.position.z);
				} else {
					transform.position = new Vector3 (nodes[currentNode].position.x, transform.position.y , transform.position.z);
					currentNode = 1;
				}
			} else {
				if (animState != 3) {
					animState = 3;
					anim.SetInteger("state", animState);
				}
				if (transform.position.x < nodes[currentNode].position.x) {
					transform.position = new Vector3 (transform.position.x + speed, transform.position.y, transform.position.z);
				} else {
					transform.position = new Vector3 (nodes[currentNode].position.x, transform.position.y , transform.position.z);
					currentNode++;
				}
			}
		}

		if (currentNode == 3) {
			if (!clockwise) {
				if (animState != 0) {
					animState = 0;
					anim.SetInteger("state", animState);
				}

				if (transform.position.y > nodes[currentNode].position.y) {
					transform.position = new Vector3 (transform.position.x, transform.position.y - speed, transform.position.z);
				} else {
					transform.position = new Vector3 (transform.position.x, nodes[currentNode].position.y , transform.position.z);
					currentNode = 2;
				}
			} else {
				if (animState != 0) {
					animState = 0;
					anim.SetInteger("state", animState);
				}
				if (transform.position.y > nodes[currentNode].position.y) {
					transform.position = new Vector3 (transform.position.x, transform.position.y - speed, transform.position.z);
				} else {
					transform.position = new Vector3 (transform.position.x, nodes[currentNode].position.y , transform.position.z);
					currentNode = 0;
				}
			}
		}

	}

	void Follow () {

		//if (Mathf.Abs(player.transform.position.x - transform.position.x) > Mathf.Abs(player.transform.position.y - transform.position.y)) {

			if (transform.position.x > player.transform.position.x) {
				transform.position = new Vector3 (transform.position.x - speed, transform.position.y, transform.position.z);
				if (animState != 2) {
					animState = 2;
					anim.SetInteger("state", animState);
				}
			} else {
				transform.position = new Vector3 (transform.position.x + speed, transform.position.y, transform.position.z);
				if (animState != 3) {
					animState = 3;
					anim.SetInteger("state", animState);
				}

			}

		//} else {

			if (transform.position.y > player.transform.position.y) {
				transform.position = new Vector3 (transform.position.x, transform.position.y - speed, transform.position.z);
				if (animState != 0) {
					animState = 0;
					anim.SetInteger("state", animState);
				}

			} else {
				transform.position = new Vector3 (transform.position.x, transform.position.y + speed, transform.position.z);
				if (animState != 1) {
					animState = 1;
					anim.SetInteger("state", animState);
				}

			}
		//}

	}

	void OnCollisionEnter (Collision other) {
		if (other.gameObject.tag == "Player") {
			LevelManager.reset = true;
		}
	}
}
