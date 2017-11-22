using UnityEngine;


public class MenuHelper : MonoBehaviour
{
	[SerializeField] public GameObject window;
	[SerializeField] public MenuBarUI targetMenu;
	[SerializeField] public Color imageColor = Color.white;
	[SerializeField] public Color labelColor = Color.black;
	[SerializeField] public Sprite icon;
	[SerializeField] public string title = "Window";


	public void ToMenu()
	{
		if(targetMenu==null)
			Debug.LogWarning ("please set a targetMenu in inspector window.");
		else
			targetMenu.AddMenu (this);
	}
}
