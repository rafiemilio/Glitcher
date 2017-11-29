/*
---------------------------------------

Rafi Emilio Alam 
for the Game Off game jam

---------------------------------------
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Window : MonoBehaviour {

	bool closed;
	float size = .5f;
	public float shrinkSpeed = 1;


	[SerializeField] Transform startPosition;
	[SerializeField] Vector3 closePosition;
	[SerializeField] int corruption;
	[SerializeField] GameObject level;
	[SerializeField] GameObject glitch;
	[SerializeField] bool folder;

	void OnEnable () {
		closed = false;
	}

	void Start () {
		closed = false;
		size = .1f;
		transform.position = startPosition.position;
		transform.localScale = new Vector3 (size, size, size);
	}
	
	// Update is called once per frame
	void Update () {

		if (Computer.corruption == corruption && !folder) {
			if (!level.activeSelf) {
				level.SetActive(true);
			}
		}
		if (Computer.corruption > corruption) {
			if (!glitch.activeSelf) {
				glitch.SetActive(true);
			}
		}

		if (closed) {
			Shrink();
			
		} else {
			if (size < .5f) {
				Grow();
				transform.position = Vector3.Lerp (transform.position, closePosition, Time.deltaTime * 15);
				transform.localScale = new Vector3 (size, size, size);
			} else {
				if (size != .5f) {
					size = .5f;	
					transform.position = Vector3.Lerp (transform.position, closePosition, Time.deltaTime * 15);
					transform.localScale = new Vector3 (size, size, size);			
				}
			}
		}
	}

	void Grow () {
		if (size < .5f) {
			size += shrinkSpeed * Time.deltaTime;
		} else {
			size = .5f;
		}


	}

	void Shrink () {
		if (size > .1f) {
			size -= shrinkSpeed * Time.deltaTime;
		} else {
			gameObject.SetActive(false);
		}
		transform.position = Vector3.Lerp (transform.position, startPosition.position, Time.deltaTime * 15);
		transform.localScale = new Vector3 (size, size, size);
	}

	public void CloseWindow () {
		closePosition = transform.position;
		closed = true;
	}

}
