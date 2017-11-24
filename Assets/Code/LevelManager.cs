using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	[SerializeField] GameObject source;
	[SerializeField] GameObject glitcher;
	[SerializeField] GameObject[] enemy;
	[SerializeField] GameObject[] bytes;

	[SerializeField] GameObject window;
 
 	Vector3 windowPosition;
	Vector3 startPosition;
	public Vector3[] enemyPosition = new Vector3[5];

	static public bool reset;
	
	int byteCount;


	// Use this for initialization
	void Start () {
		windowPosition = window.transform.localPosition;
		startPosition = glitcher.transform.localPosition;
		for (var i = 0; i < enemy.Length; i++) {
			enemyPosition[i] = enemy[i].transform.localPosition; 
		}
	}
	
	// Update is called once per frame
	void Update () {

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
			reset = false;
		}
		
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
}
