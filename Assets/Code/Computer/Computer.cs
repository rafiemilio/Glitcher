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

public class Computer : MonoBehaviour {

	static public int corruption;
	[Header("Boot Sequence")]
	[SerializeField] GameObject bootImage;
	[SerializeField] GameObject muifwegoLogo;
	[SerializeField] GameObject menuBar;
	[SerializeField] GameObject desktop;
	[SerializeField] GameObject desktopGlitch;
	[SerializeField] Text timer;
	[SerializeField] int maxCorruption;

	[Header("Desktop Icons")]
	public int desktopIconSelected;

	AudioSource aud;
	float time;
	bool windowOpen;

	[SerializeField] int corruptionTest;
	[SerializeField] bool test;

	bool ending;
	bool restartReady;
	[SerializeField] GameObject bsod;
	[SerializeField] Text score;

	void Awake () {
		BootUp();
	}

	void Start () {	
		aud = GetComponent<AudioSource>();
		StartCoroutine("BootSequence");
	}

	public void Restart () {
		corruption = 0;
		Application.LoadLevel(0);
	}

	IEnumerator End () {
		yield return new WaitForSeconds(3);
		bsod.SetActive(true);
		time += Time.deltaTime;
		string minSec = string.Format("{0}:{1:00}:{2:00}", (int)time / 3600, ((int)time % 3600) / 60, ((int)time % 3600) % 60); 
		score.text = minSec;
		yield return new WaitForSeconds(1);
		restartReady = true;
	}
	
	void Update () {

		if (restartReady) {
			if (Input.GetKeyDown(KeyCode.Return)) {
				bsod.GetComponent<Image>().color = new Color (0,0,0);
				Restart();
			}
		}

		if (test) {
			corruption = corruptionTest;
		}

		if (corruption >= maxCorruption) {
			if (!desktopGlitch.activeSelf) {
				desktopGlitch.SetActive(true);
			}

			if (!ending) {
				StartCoroutine("End");
				ending = true;
			}


		}

		if (desktopIconSelected > 5) {
			if (!windowOpen) {
				windowOpen = true;
			}
			
		} else {
			if (windowOpen) {
				windowOpen = false;
			}
		}

		if (!windowOpen) {
			DesktopKeys();
		}

		time += Time.deltaTime;
		string minSec = string.Format("{0}:{1:00}:{2:00}", (int)time / 3600, ((int)time % 3600) / 60, ((int)time % 3600) % 60); 
		timer.text = minSec;
	}

	void DesktopKeys () {

		if (Input.GetKeyDown(KeyCode.C)) {
			desktopIconSelected = 1;
		}
		if (Input.GetKeyDown(KeyCode.D)) {
			desktopIconSelected = 2;
		}
		if (Input.GetKeyDown(KeyCode.T)) {
			desktopIconSelected = 3;
		}
		if (Input.GetKeyDown(KeyCode.B)) {
			desktopIconSelected = 4;
		}
		if (Input.GetKeyDown(KeyCode.E)) {
			desktopIconSelected = 5;
		}

		if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			if (desktopIconSelected == 0) {
				desktopIconSelected = 1;
			}
			else if (desktopIconSelected == 1) {
				desktopIconSelected = 5;
			}
			else if (desktopIconSelected == 2) {
				desktopIconSelected = 5;
			}
			else if (desktopIconSelected == 3) {
				desktopIconSelected = 4;
			}
			else if (desktopIconSelected == 4) {
				desktopIconSelected = 5;
			}
			else if (desktopIconSelected == 5) {
				desktopIconSelected = 5;
			}
		}
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			if (desktopIconSelected == 0) {
				desktopIconSelected = 1;
			}
			else if (desktopIconSelected == 1) {
				desktopIconSelected = 1;
			}
			else if (desktopIconSelected == 2) {
				desktopIconSelected = 1;
			}
			else if (desktopIconSelected == 3) {
				desktopIconSelected = 2;
			}
			else if (desktopIconSelected == 4) {
				desktopIconSelected = 2;
			}
			else if (desktopIconSelected == 5) {
				desktopIconSelected = 1;
			}

		}
		if (Input.GetKeyDown(KeyCode.DownArrow)) {
			if (desktopIconSelected == 0) {
				desktopIconSelected = 1;
			}
			else if (desktopIconSelected == 1) {
				desktopIconSelected = 2;
			}
			else if (desktopIconSelected == 2) {
				desktopIconSelected = 3;
			}
			else if (desktopIconSelected == 3) {
				desktopIconSelected = 3;
			}
			else if (desktopIconSelected == 4) {
				desktopIconSelected = 3;
			}
			else if (desktopIconSelected == 5) {
				desktopIconSelected = 4;
			}
		}
		if (Input.GetKeyDown(KeyCode.RightArrow)) {
			if (desktopIconSelected == 0) {
				desktopIconSelected = 1;
			}
			else if (desktopIconSelected == 1) {
				desktopIconSelected = 1;
			}
			else if (desktopIconSelected == 2) {
				desktopIconSelected = 2;
			}
			else if (desktopIconSelected == 3) {
				desktopIconSelected = 3;
			}
			else if (desktopIconSelected == 4) {
				desktopIconSelected = 3;
			}
			else if (desktopIconSelected == 5) {
				desktopIconSelected = 2;
			}
		}
	}

	public void ClickIcon (int clickedIcon) {
		desktopIconSelected = clickedIcon;
	}

	void BootUp () {
		bootImage.SetActive(false);
		bootImage.SetActive(false);
		muifwegoLogo.SetActive(false);
		muifwegoLogo.SetActive(false);
		menuBar.SetActive(false);
		desktop.SetActive(false);
	}

	IEnumerator BootSequence () {
		yield return new WaitForSeconds(.5f);
		bootImage.SetActive(true);
		yield return new WaitForSeconds(1);
		bootImage.SetActive(false);
		muifwegoLogo.SetActive(true);
		yield return new WaitForSeconds(3);
		muifwegoLogo.SetActive(false);
		menuBar.SetActive(true);
		yield return new WaitForSeconds(1f);
		desktop.SetActive(true);

	}
}
