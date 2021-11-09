using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragHandle : MonoBehaviour
{
	public Swipe swipe;
	public GameObject Rope;
	public float dragSpeed = 5f;


	private void Start()
	{
		Rope = transform.parent.gameObject;
	}

	private void OnMouseDrag()
	{
		if (swipe.SwipeDown)
		{
			Rope.transform.position = new Vector3(Rope.transform.position.x , Rope.transform.position.y - (dragSpeed * Time.deltaTime * 0.2f), Rope.transform.position.z);
			Debug.Log("down");
		}
		else if (swipe.SwipeUp)
		{
			Rope.transform.position = new Vector3(Rope.transform.position.x , Rope.transform.position.y + (dragSpeed * Time.deltaTime * 0.2f), Rope.transform.position.z);
			Debug.Log("up");
		}
	}

}
