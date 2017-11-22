using UnityEngine;
using UnityEngine.EventSystems;
using System;
using System.Collections;


/// <summary>
/// When put it in some UI, it will be dragged as a window.
/// This is only used in overray canvas.
/// </summary>
[Serializable]
public partial class DraggableUI : MonoBehaviour, IDragHandler
{
	[SerializeField] public RectTransform targetTransform;
	[SerializeField] public bool BlockScreenOut;
	[SerializeField] public float padding = 30;

	[NonSerialized] public RectTransform rect;

	protected virtual void Awake()
	{
		rect = GetComponent<RectTransform> ();

		if (targetTransform == null)
			targetTransform = rect;
	}

	public virtual void OnDrag(PointerEventData e)
	{
		if (BlockScreenOut)
		{
			var c1 = rect.TransformPoint(new Vector3(rect.rect.x,rect.rect.y,0));
			var c2 = rect.TransformPoint(new Vector3(rect.rect.xMax,rect.rect.yMax,0));

			var delta = e.delta;
			
			if(c2.x+delta.x<padding)
				delta.x = padding-c2.x;
			if(c1.x+delta.x>Screen.width-padding)
				delta.x = Screen.width-padding-c1.x;
			if(c2.y+delta.y<padding)
				delta.y = padding-c2.y;
			if(c1.y+delta.y>Screen.height-padding)
				delta.y = Screen.height-padding-c1.y;

			targetTransform.position += (Vector3)delta;
		}
		else
			targetTransform.position += (Vector3)e.delta;
	}
}