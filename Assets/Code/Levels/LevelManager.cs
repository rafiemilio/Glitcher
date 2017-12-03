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

public class LevelManager : MonoBehaviour {

	[SerializeField] GameObject source;
	[SerializeField] GameObject glitcher;
	[SerializeField] GameObject[] enemy;
	[SerializeField] GameObject[] bytes;

	[SerializeField] GameObject window;
	[SerializeField] GameObject virusScan;
	[SerializeField] Image scanBar;
	[SerializeField] Text scanning;
 	
 	[SerializeField] float timeLimit = 10;

 	Vector3 windowPosition;
	Vector3 startPosition;
	public Vector3[] enemyPosition;
	static public bool reset;
	
	int byteCount;
	float time;

	// Use this for initialization
	void Start () {

		enemyPosition = new Vector3[enemy.Length];
		windowPosition = window.transform.localPosition;
		startPosition = glitcher.transform.localPosition;
		for (var i = 0; i < enemy.Length; i++) {
			enemyPosition[i] = enemy[i].transform.localPosition; 
		}
	}
	
	void OnDisable () {
		time = 0;
		virusScan.SetActive(false);
		window.transform.localPosition = windowPosition;
		glitcher.transform.localPosition = startPosition;
		for (var i = 0; i < enemy.Length; i++) {
			enemy[i].transform.localPosition = enemyPosition[i];
			enemy[i].GetComponent<AntiVirus>().player = null;
		}

		for (var i = 0; i < bytes.Length; i++) {
			bytes[i].SetActive(true);
		}
		reset = false;
	}

	// Update is called once per frame
	void Update () {

		if (!virusScan.activeSelf) {
			virusScan.SetActive(true);
		}

		if (reset) {
			window.transform.localPosition = windowPosition;
			glitcher.transform.localPosition = startPosition;
			for (var i = 0; i < enemy.Length; i++) {
				enemy[i].transform.localPosition = enemyPosition[i];
				enemy[i].GetComponent<AntiVirus>().player = null;
			}

			for (var i = 0; i < bytes.Length; i++) {
				bytes[i].SetActive(true);
			}
			time = 0;
			byteCount = 0;
			reset = false;
		}

		Scan();		
		CheckBytes();
		
	}

	void CheckBytes () {
		byteCount = 0;
		for (var i = 0; i < bytes.Length; i++) {
			if (!bytes[i].activeSelf) {
				byteCount++;
			}
		}
		if (byteCount >= bytes.Length) {
			if (!source.activeSelf) {
				source.SetActive(true);
			}
		}
	}

	void Scan () {
		
		if (time >= timeLimit) {
			time = timeLimit;
			for (var i = 0; i < enemy.Length; i++) {
				if (enemy[i].GetComponent<AntiVirus>().player == null) {
					enemy[i].GetComponent<AntiVirus>().player = glitcher;
				}	
			}
			scanning.text = "VIRUS FOUND!";
		} else {
			time += Time.deltaTime;
			scanning.text = "SCANNING FOR VIRUS...";
			for (var i = 0; i < enemy.Length; i++) {
				if (enemy[i].GetComponent<AntiVirus>().player != null) {
					time = timeLimit;
				}	
			}
		}

		scanBar.fillAmount = time.Remap(0,timeLimit,0,1);
	}
}
