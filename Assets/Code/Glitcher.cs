using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Glitcher : MonoBehaviour, IPointerDownHandler {

	[SerializeField] float speed = 3; 
	[SerializeField] Transform glitch;

	Vector3 targetPosition;

	// Use this for initialization
	void Start () {
		targetPosition = glitch.position;
	}
	
	// Update is called once per frame
	void Update () {
		KeyMove();
	}

	public virtual void OnPointerDown(PointerEventData eventData) {
			if (glitch.position != Input.mousePosition) {
				targetPosition = Input.mousePosition;
			}
	}

	void KeyMove() {

		Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
		move = move.normalized * Time.deltaTime * speed * 10;
	
		if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0) {
			glitch.GetComponent<Rigidbody>().velocity = Vector3.zero;
		}

		if (Input.GetAxis("Vertical") != 0 && Input.GetAxis("Horizontal") == 0) {
			glitch.GetComponent<Rigidbody>().velocity = move;
			if (Input.GetAxis("Vertical") > 0) {
				//animstate = 1;
			} else {
				//animstate = 0;
			}
		}

		if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") != 0) {
			glitch.GetComponent<Rigidbody>().velocity = move;
			//animstate = 2;
			if (Input.GetAxis("Horizontal") > 0) {
				//sprite.transform.localScale = new Vector3 (-1,1,1);
			} else {
				//sprite.transform.localScale = new Vector3 (1,1,1);
			}
		}

	}
}
