using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public bool isOnRight;  // player saðda mý solda mý??

	private void Awake()
	{
        if (instance == null) instance = this;
        else Destroy(this);
	}

	private void Start()
	{
        DOTween.Init();
        if (transform.position.x < 0) isOnRight = false;
        else if (transform.position.x > 0) isOnRight = true;
	}

	public void Jump()
	{
        if (isOnRight)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(-4.5f, 4.5f, 0), ForceMode.Impulse);
            isOnRight = false;
        }
        else
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(4.5f, 4.5f, 0), ForceMode.Impulse);
            isOnRight = true;
        }
    }

	private void OnCollisionEnter(Collision collision)
	{
        Debug.Log("çalýþtý");
        transform.SetParent(collision.gameObject.transform);
        SetPlayerPlatformPosition();
	}

    IEnumerator SetPlayerStandingPosition()
	{
		if (isOnRight)
		{
            while (Vector3.Distance(transform.position, new Vector3(2,transform.position.y,transform.position.z)) > 0)
            {
                transform.DOMoveX(2, 1);
                yield return new WaitForSeconds(.03f);
            }
		}
		else if(!isOnRight)
		{
            while (Vector3.Distance(transform.position, transform.parent.transform.position) > 0)
            {
                transform.DOMoveX(transform.parent.transform.position.x, 1, true);
                yield return new WaitForSeconds(.03f);
            }
        }
		
        
	}

    public void SetPlayerPlatformPosition()
	{
        if (isOnRight) transform.DOMoveX(2, .1f).SetEase(Ease.Linear);
        else transform.DOMoveX(-2,.1f).SetEase(Ease.Linear);
    }

    
}
