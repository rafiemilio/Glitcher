using UnityEngine;
using UnityEngine.EventSystems;
using System;


/// <summary>This class bring a UI to front, when on click.</summary>
[Serializable]
public partial class BringToFrontUI : MonoBehaviour, IPointerDownHandler
{
	[NonSerialized] public RectTransform rect;

	protected virtual void Awake()
	{
		rect = GetComponent<RectTransform> ();
	}

	public virtual void OnPointerDown(PointerEventData e)
	{
			rect.SetAsLastSibling ();
	}

	public void BringForward () {
		rect.SetAsLastSibling();
	}
}