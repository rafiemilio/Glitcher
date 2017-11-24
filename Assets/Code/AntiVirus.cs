using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiVirus : MonoBehaviour {

	[SerializeField] GameObject player;
	[SerializeField] Transform[] nodes;
	[SerializeField] float speed = 1;
	
	[SerializeField] bool clockwise;
	
	[SerializeField] int currentNode;
	
	bool following;
	int animState;
	Animator anim;

	void Start () {
		anim = GetComponent<Animator>();
	}
	
	void FixedUpdate () {

		Patrol();
		
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
}
