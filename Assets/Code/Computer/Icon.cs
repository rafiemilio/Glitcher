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
using UnityEngine.EventSystems;

public class Icon : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler {

	[Header("Computer Reference")]
	[SerializeField] Computer computer;
	[Space(20)]
	
	[SerializeField] int desktopIcon;
	[Header("Icons")]
	Image icon;
	[SerializeField] Sprite whiteIcon;
	[SerializeField] Sprite blackIcon;
	[SerializeField] Text title;
	[SerializeField] Image titleImage;
	[SerializeField] Image highlight;	
	[Space(20)]
	
	[SerializeField] Transform dragLayer;

	static public GameObject draggedItem;
	Vector3 startPosition;
	Transform startParent;

	[SerializeField] GameObject window;
	[SerializeField] int corruption;
	[SerializeField] GameObject glitch;

	// Use this for initialization
	void Start () {
		icon = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {

		if (Computer.corruption > corruption) {
			if (!glitch.activeSelf) {
				glitch.SetActive(true);
			}
		}

		if (computer.desktopIconSelected == desktopIcon) {
			if (icon.sprite != blackIcon) {
				if (titleImage) {
					titleImage.color = new Color (1,0,0);
				} else {
					title.color = new Color (1,1,1);
				}
				
				highlight.color = new Color(0,0,0);
				icon.sprite = blackIcon;
			}
		} else {
			if (icon.sprite != whiteIcon) {
				if (titleImage) {
					titleImage.color = new Color (1,1,1);
				} else {
					title.color = new Color (0,0,0);
				}

				highlight.color = new Color(1,1,1);
				icon.sprite = whiteIcon;
			}
		}
		
	}

	public void OnPointerDown(PointerEventData eventData) {
		if (computer.desktopIconSelected == desktopIcon) {
			window.GetComponent<RectTransform>().SetAsLastSibling();
			window.SetActive(true);
		} else {
			computer.desktopIconSelected = desktopIcon;
		}
		
	}

	public void OnBeginDrag (PointerEventData eventData) {
		draggedItem = gameObject;
		startPosition = transform.position;
		startParent = transform.parent;
		transform.SetParent(dragLayer);
		GetComponent<CanvasGroup>().blocksRaycasts = false;

	}
	public void OnDrag (PointerEventData eventData) {
		transform.position = Input.mousePosition;
	}
	public void OnEndDrag (PointerEventData eventData) {
		draggedItem = null;
		transform.position = startPosition;
		transform.SetParent(startParent);
		GetComponent<CanvasGroup>().blocksRaycasts = true;
	}
}
