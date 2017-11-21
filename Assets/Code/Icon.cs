/*
---------------------------------------

By Rafi Emilio Alam 
for the Game Off game jam

---------------------------------------
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Icon : MonoBehaviour, IPointerDownHandler {

	[Header("Computer Reference")]
	[SerializeField] Computer computer;
	[Space(20)]
	[SerializeField] int desktopIcon;
	[Header("Icons")]
	Image icon;
	[SerializeField] Sprite whiteIcon;
	[SerializeField] Sprite blackIcon;
	[SerializeField] Text title;
	[SerializeField] Image highlight;	

	// Use this for initialization
	void Start () {
		icon = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {

		if (computer.desktopIconSelected == desktopIcon) {
			if (icon.sprite != blackIcon) {
				title.color = new Color (1,1,1);
				highlight.color = new Color(0,0,0);
				icon.sprite = blackIcon;
			}
		} else {
			if (icon.sprite != whiteIcon) {
				title.color = new Color (0,0,0);
				highlight.color = new Color(1,1,1);
				icon.sprite = whiteIcon;
			}
		}
		
	}

	public void OnPointerDown(PointerEventData eventData) {
		computer.desktopIconSelected = desktopIcon;
	}
}
