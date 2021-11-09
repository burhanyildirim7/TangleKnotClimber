using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
	private bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
	private bool isDragging = false;
	private Vector2 startTouch, swipeDelta;


	private void Start()
	{
		StartCoroutine(GetMousePosition());
	}

	private void Update()
	{
		tap = swipeDown = swipeLeft = swipeRight = swipeUp = false;

		#region Standolone Inputs
		if (Input.GetMouseButtonDown(0))
		{
			tap = true;
			isDragging = true;
			startTouch = Input.mousePosition;
		}
		else if (Input.GetMouseButtonUp(0))
		{
			isDragging = false;
			Reset();
		}

		#endregion

		#region Mobile Inputs
		if (Input.touches.Length > 0)
		{
			if (Input.touches[0].phase == TouchPhase.Began)
			{
				tap = true;
				isDragging = true;
				startTouch = Input.touches[0].position;
			}
			else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
			{
				isDragging = false;
				Reset();
			}
		}


		#endregion

		// calculate distance
		swipeDelta = Vector2.zero;
		if (isDragging)
		{
			if (Input.touches.Length > 0) swipeDelta = Input.touches[0].position - startTouch;
			else if (Input.GetMouseButton(0)) swipeDelta = (Vector2)Input.mousePosition - startTouch;
		}


		// which direction
		float x = swipeDelta.x;
		float y = swipeDelta.y;



		if (Mathf.Abs(x) > Mathf.Abs(y))
		{
			// left or right
			if (x < 0) swipeLeft = true;
			else swipeRight = true;
		}
		else
		{
			// up or down
			if (y < 0)
			{
				swipeUp = false;
				swipeDown = true;
			}
			else
			{
				swipeDown = false;
				swipeUp = true;
			}

		}

	}

	private void Reset()
	{
		startTouch = swipeDelta = Vector2.zero;
		isDragging = false;
		swipeDown = false;
		swipeLeft = false;
	}

	IEnumerator GetMousePosition()
	{
		while (true)
		{
			yield return new WaitForEndOfFrame();
			startTouch = Input.mousePosition;
		}
	}

	public Vector2 SwipeDelta { get { return swipeDelta; } }
	public bool SwipeLeft { get { return swipeLeft; } }
	public bool SwipeRight { get { return swipeRight; } }
	public bool SwipeUp { get { return swipeUp; } }
	public bool SwipeDown { get { return swipeDown; } }
	public bool Tap { get { return tap; } }

}
