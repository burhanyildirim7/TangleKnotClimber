using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDedector : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("dedector"))
		{
			PlayerController.instance.isAvaliable = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("dedector"))
		{
			PlayerController.instance.isAvaliable = false;
		}
	}
}
