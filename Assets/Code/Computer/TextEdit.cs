using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextEdit : MonoBehaviour {

	[SerializeField] Text text;
	List<string> fontlist = new List<string>() { "SANS-SERIFF", "SERIFF"};
	List<string> sizelist = new List<string>() { "8", "10", "12", "14", "16", "18", "20", "22", "24", "26", "28", "30"};
	[SerializeField] Dropdown fonts;
	[SerializeField] Dropdown sizes;

	[SerializeField] Font sansSeriff;
	[SerializeField] Font seriff;

	[SerializeField] RectTransform box;

	[SerializeField] int activeFont;
	bool isBold;
	bool isItalic;
	bool isItalicbold;


	// Use this for initialization
	void Start () {

		fonts.AddOptions(fontlist);
		sizes.AddOptions(sizelist);
	}

	void Update () {

	}

	public void ChooseFont(int fontchosen) {

		if (fontchosen == 0) {
			text.font = sansSeriff;
			text.fontSize = text.fontSize*2;
			activeFont = fontchosen;
		}

		if (fontchosen == 1) {
			text.font = seriff;
			text.fontSize = text.fontSize/2;
			activeFont = fontchosen;
		}
		
	}
	public void ChooseFontSize (int sizechosen) {
		if (sizechosen == 0) {
			if (activeFont == 0) {
				text.fontSize = 16*2;
			}
			if (activeFont == 1) {
				text.fontSize = 16;	
			}
			box.sizeDelta = new Vector2(box.sizeDelta.x, 850);
		}

		if (sizechosen == 1) {
			if (activeFont == 0) {
				text.fontSize = 18*2;
			}
			if (activeFont == 1) {
				text.fontSize = 18;
			}
			box.sizeDelta = new Vector2(box.sizeDelta.x, 1050);
		}

		if (sizechosen == 2) {
			if (activeFont == 0) {
				text.fontSize = 20*2;
			}
			if (activeFont == 1) {
				text.fontSize = 20;
			}
			box.sizeDelta = new Vector2(box.sizeDelta.x, 1250);
		}

		if (sizechosen == 3) {
			if (activeFont == 0) {
				text.fontSize = 22*2;
			}
			if (activeFont == 1) {
				text.fontSize = 22;
			}
			box.sizeDelta = new Vector2(box.sizeDelta.x, 1450);
		}

		if (sizechosen == 4) {
			if (activeFont == 0) {
				text.fontSize = 24*2;
			}
			if (activeFont == 1) {
				text.fontSize = 24;
			}
			box.sizeDelta = new Vector2(box.sizeDelta.x, 1650);
		}

		if (sizechosen == 5) {
			if (activeFont == 0) {
				text.fontSize = 26*2;
			}
			if (activeFont == 1) {
				text.fontSize = 26;
			}
			box.sizeDelta = new Vector2(box.sizeDelta.x, 1850);
		}

		if (sizechosen == 6) {
			if (activeFont == 0) {
				text.fontSize = 28*2;
			}
			if (activeFont == 1) {
				text.fontSize = 28;
			}
			box.sizeDelta = new Vector2(box.sizeDelta.x, 2050);
		}

		if (sizechosen == 7) {
			if (activeFont == 0) {
				text.fontSize = 30*2;
			}
			if (activeFont == 1) {
				text.fontSize = 30;
			}
			box.sizeDelta = new Vector2(box.sizeDelta.x, 2250);
		}

		if (sizechosen == 8) {
			if (activeFont == 0) {
				text.fontSize = 32*2;
			}
			if (activeFont == 1) {
				text.fontSize = 32;
			}
			box.sizeDelta = new Vector2(box.sizeDelta.x, 2450);
		}

		if (sizechosen == 9) {
			if (activeFont == 0) {
				text.fontSize = 34*2;
			}
			if (activeFont == 1) {
				text.fontSize = 34;
			}
			box.sizeDelta = new Vector2(box.sizeDelta.x, 2650);
		}

		if (sizechosen == 10) {
			if (activeFont == 0) {
				text.fontSize = 36*2;
			}
			if (activeFont == 1) {
				text.fontSize = 36;
			}
			box.sizeDelta = new Vector2(box.sizeDelta.x, 2850);
		}

		if (sizechosen == 11) {
			if (activeFont == 0) {
				text.fontSize = 38*2;
			}
			if (activeFont == 1) {
				text.fontSize = 38;
			}
			box.sizeDelta = new Vector2(box.sizeDelta.x, 3800);
		}

		
	}

	public void Bold () {
		if (!isBold) {
			if (isItalic) {
				text.fontStyle = FontStyle.BoldAndItalic;
			} else {
				text.fontStyle = FontStyle.Bold;
			}
			
		} else {
			if (isItalic) {
				text.fontStyle = FontStyle.Italic;
			} else {
				text.fontStyle = FontStyle.Normal;
			}
			
		}

		isBold = !isBold;
		
	}
	public void Italic () {
		if (!isItalic) {
			if (isBold) {
				text.fontStyle = FontStyle.BoldAndItalic;
			} else {
				text.fontStyle = FontStyle.Italic;
			}
		} else {
			if (isBold) {
				text.fontStyle = FontStyle.Bold;
			} else {
				text.fontStyle = FontStyle.Normal;
			}
			
		}

		isItalic = !isItalic;
		
	}
	public void Underline () {
		text.fontStyle = FontStyle.Normal;
	}

	public void AlignLeft () {
		text.alignment = TextAnchor.UpperLeft;
	}
	public void AlignCenter () {
		text.alignment = TextAnchor.UpperCenter;
		
	}
	public void AlignRight () {
		text.alignment = TextAnchor.UpperRight;
		
	}
}
