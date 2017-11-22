using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Collections;


/// <summary>This make UI resizable by dragging.</summary>
[Serializable]
public partial class ResizableUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
	[Flags]
	public enum CursorFlag
	{
		None = 0,
		Left = 1,
		Right = 2,
		Top = 4,
		Bottom = 8,
		TL = 5,
		TR = 6,
		BL = 9,
		BR = 10
	}

	[SerializeField] public Texture2D WE_Cursor; // '-'.
	[SerializeField] public Texture2D NS_Cursor; // '|'.
	[SerializeField] public Texture2D NWSE_Cursor; // '\'.
	[SerializeField] public Texture2D NESW_Cursor; // '/'.

	[SerializeField] public float edgeWidth = 5;
	[SerializeField] public Vector2 minSize = new Vector2 (120, 35);
	[SerializeField] public Vector2 maxSize = new Vector2 (800, 600);
	[SerializeField] public Vector2 MinimizeMaximizePivot = new Vector2 (1, 1);

	[SerializeField] public bool _BlockScreenOut;
	public bool BlockScreenOut{ get{return _BlockScreenOut;} set{_BlockScreenOut = value;} }

	[SerializeField] public float padding = 30;

	[NonSerialized] public bool onUI;
	[NonSerialized] public RectTransform rect;
	[NonSerialized] public CursorFlag flags;
	[NonSerialized] public Canvas canvas;

	[NonSerialized] public static CursorFlag grip;

	/// <summary>Minimize the UI.</summary>
	public virtual void Minimize()
	{
		var diff = rect.sizeDelta - minSize;
		Vector3 pos = rect.anchoredPosition;
		pos.x += diff.x * (MinimizeMaximizePivot.x-rect.pivot.x);
		pos.y += diff.y * (MinimizeMaximizePivot.y-rect.pivot.y);
		rect.anchoredPosition = pos;

		rect.sizeDelta = minSize;
	}

	/// <summary>Maximize the UI.</summary>
	public virtual void Maximize()
	{
		var diff = rect.sizeDelta - maxSize;
		Vector3 pos = rect.anchoredPosition;
		pos.x += diff.x * (MinimizeMaximizePivot.x-rect.pivot.x);
		pos.y += diff.y * (MinimizeMaximizePivot.y-rect.pivot.y);
		rect.anchoredPosition = pos;
		
		rect.sizeDelta = maxSize;
	}

	protected virtual void Awake()
	{
		rect = GetComponent<RectTransform> ();
		canvas = GetComponentInParent<Canvas> ();
	}

	protected virtual void OnEnable()
	{
		onUI = false;
		flags = grip = CursorFlag.None;
	}

	protected virtual void Update()
	{
		if (!onUI || grip != CursorFlag.None) return;

		var r = rect.rect;

		var v2 = rect.InverseTransformPoint(Input.mousePosition);

		if(v2.x <= r.x+edgeWidth)
			flags |= CursorFlag.Left;
		else
			flags &= ~CursorFlag.Left;

		if(v2.y <= r.y+edgeWidth)
			flags |= CursorFlag.Bottom;
		else
			flags &= ~CursorFlag.Bottom;

		if(v2.x >= r.x+r.width-edgeWidth)
			flags |= CursorFlag.Right;
		else
			flags &= ~CursorFlag.Right;

		if(v2.y >= r.y+r.height-edgeWidth)
			flags |= CursorFlag.Top;
		else
			flags &= ~CursorFlag.Top;


		if ((flags & CursorFlag.TL) == CursorFlag.TL || (flags & CursorFlag.BR) == CursorFlag.BR )
			Cursor.SetCursor (NWSE_Cursor, new Vector2 (16, 16), CursorMode.Auto);
		else if ((flags & CursorFlag.TR) == CursorFlag.TR || (flags & CursorFlag.BL) == CursorFlag.BL )
			Cursor.SetCursor (NESW_Cursor, new Vector2 (16, 16), CursorMode.Auto);
		else if ((flags & CursorFlag.Top) == CursorFlag.Top || (flags & CursorFlag.Bottom) == CursorFlag.Bottom )
			Cursor.SetCursor (NS_Cursor, new Vector2 (16, 16), CursorMode.Auto);
		else if ((flags & CursorFlag.Left) == CursorFlag.Left || (flags & CursorFlag.Right) == CursorFlag.Right )
			Cursor.SetCursor (WE_Cursor, new Vector2 (16, 16), CursorMode.Auto);
		else
			Cursor.SetCursor (null, Vector2.zero, CursorMode.Auto);
	}

	public virtual void OnPointerEnter(PointerEventData e){ onUI = true; }
	public virtual void OnPointerExit(PointerEventData e)
	{
		onUI = false;
		if (grip != CursorFlag.None)
			return;
		flags = CursorFlag.None;
		Cursor.SetCursor (null, Vector2.zero, CursorMode.Auto);
	}

	public virtual void OnPointerDown(PointerEventData e)
	{
		if (flags == CursorFlag.None)
			return;
		grip = flags;
		OnDrag (e);
	}

	public virtual void OnPointerUp(PointerEventData e)
	{
		grip = CursorFlag.None;
		if(!onUI)
		{
			flags = CursorFlag.None;
			Cursor.SetCursor (null, Vector2.zero, CursorMode.Auto);
		}
	}

	public virtual void OnDrag(PointerEventData e)
	{
		if (grip == CursorFlag.None)
			return;

		var pos = rect.position;
		var size = rect.sizeDelta;
		var delta = e.delta;

		var c1 = rect.TransformPoint(new Vector3(rect.rect.x,rect.rect.y,0));
		var c2 = rect.TransformPoint(new Vector3(rect.rect.xMax,rect.rect.yMax,0));

		if ((grip&CursorFlag.Left)== CursorFlag.Left)
		{
			if(BlockScreenOut)
			{
				if (c1.x+delta.x < 0)
					delta.x = -c1.x;
				else if (c1.x+delta.x > Screen.width-padding)
					delta.x = Screen.width-padding-c1.x;
			}

			if (size.x-delta.x < minSize.x)
				delta.x = size.x-minSize.x;
			else if(size.x-delta.x > maxSize.x)
				delta.x = size.x-maxSize.x;

			pos.x += delta.x*(1-rect.pivot.x);
			size.x -= delta.x;
		}
		else if ((grip&CursorFlag.Right)== CursorFlag.Right)
		{
			if(BlockScreenOut)
			{
				if (c2.x+delta.x < padding)
					delta.x = padding-c2.x;
				else if (c2.x+delta.x > Screen.width)
					delta.x = Screen.width-c2.x;
			}

			if (size.x+delta.x < minSize.x)
				delta.x = minSize.x-size.x;
			else if(size.x+delta.x > maxSize.x)
				delta.x = maxSize.x-size.x;

			pos.x += delta.x*(rect.pivot.x);
			size.x += delta.x;
		}
		if ((grip&CursorFlag.Top)== CursorFlag.Top)
		{
			if(BlockScreenOut)
			{
				if (c2.y+delta.y < padding)
					delta.y = padding-c2.y;
				else if (c2.y+delta.y > Screen.height)
					delta.y = Screen.height-c2.y;
			}

			if (size.y+delta.y < minSize.y)
				delta.y = minSize.y-size.y;
			else if(size.y+delta.y > maxSize.y)
				delta.y = maxSize.y-size.y;

			pos.y += delta.y*(rect.pivot.y);
			size.y += delta.y;
		}
		else if ((grip&CursorFlag.Bottom)== CursorFlag.Bottom)
		{
			if(BlockScreenOut)
			{
				if (c1.y+delta.y < 0)
					delta.y = -c1.y;
				else if (c1.y+delta.y > Screen.height-padding)
					delta.y = Screen.height-padding-c1.y;
			}

			if (size.y-delta.y < minSize.y)
				delta.y = size.y-minSize.y;
			else if(size.y-delta.y > maxSize.y)
				delta.y = size.y-maxSize.y;
			
			pos.y += delta.y*(1-rect.pivot.y);
			size.y -= delta.y;
		}

		rect.position = pos;
		rect.sizeDelta = size;
	}
}