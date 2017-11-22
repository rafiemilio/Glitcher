using UnityEngine;


public class MenuBarUI : MonoBehaviour
{
	[SerializeField] public GameObject buttonPrefab;

	public virtual void AddMenu(MenuHelper helper)
	{
		var obj = Instantiate (buttonPrefab) as GameObject;
		obj.transform.SetParent(transform);

		var wrapper = obj.GetComponent<MenuButtonWrapper> ();
		if (wrapper == null)
			Debug.Log (string.Format("there's no MenuButtonWrapper in {0}.",buttonPrefab.name));
		else
		{
			wrapper.icon.sprite = helper.icon;
			wrapper.image.color = helper.imageColor;
			wrapper.text.text = helper.title;
			wrapper.text.color = helper.labelColor;
			wrapper.button.onClick.AddListener(()=>{
				helper.window.SetActive (true);
				helper.window.transform.SetAsLastSibling();
				Destroy( wrapper.gameObject );
			});
			helper.window.SetActive (false);
		}
	}
}
