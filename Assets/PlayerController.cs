using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public bool isOnRight;  // player saðda mý solda mý??
    public bool isPosLeft;
    public bool isAvaliable = false;
    [SerializeField] Animator playerAnimator;
    [SerializeField] bool finishSagda;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);
    }

    private void Start()
    {
        transform.parent.GetChild(0).gameObject.GetComponent<DedectSagControl>().dedectsagaktif = true;
        transform.parent.GetChild(1).gameObject.GetComponent<DedectSolControl>().dedectsolaktif = true;
        DOTween.Init();
        if (transform.position.x < 0) isOnRight = false;
        else if (transform.position.x > 0) isOnRight = true;
    }

    public void Jump()
    {
        if (isAvaliable)
        {
            isPosLeft = (!isPosLeft);
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            playerAnimator.SetBool("Jump",true);
            if (isOnRight)
            {
                if (isPosLeft)
                {
                    GetComponent<Rigidbody>().AddForce(new Vector3(-2.5f, 4.5f, 0), ForceMode.Impulse);

                }
                else
                {
                    GetComponent<Rigidbody>().AddForce(new Vector3(-4.5f, 4.5f, 0), ForceMode.Impulse);

                }
                //isOnRight = false;
            }
            else
            {
                if (isPosLeft)
                {
                    GetComponent<Rigidbody>().AddForce(new Vector3(4.5f, 4.5f, 0), ForceMode.Impulse);

                }
                else
                {
                    GetComponent<Rigidbody>().AddForce(new Vector3(2.5f, 4.5f, 0), ForceMode.Impulse);

                }
                //isOnRight = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        playerAnimator.SetBool("Jump", false);
        Debug.Log("çalýþtý");
        if (collision.gameObject.tag == "platform")
        {
            transform.parent.GetChild(0).gameObject.GetComponent<DedectSagControl>().dedectsagaktif=false;
            transform.parent.GetChild(1).gameObject.GetComponent<DedectSolControl>().dedectsolaktif = false;

            transform.SetParent(collision.gameObject.transform);

            transform.parent.GetChild(0).gameObject.GetComponent<DedectSagControl>().dedectsagaktif = true;
            transform.parent.GetChild(1).gameObject.GetComponent<DedectSolControl>().dedectsolaktif = true;

            SetPlayerPlatformPosition();

        }
        else if(collision.gameObject.tag == "Finish")
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    IEnumerator SetPlayerStandingPosition()
    {
        if (isOnRight)
        {
            while (Vector3.Distance(transform.position, new Vector3(2, transform.position.y, transform.position.z)) > 0)
            {
                transform.DOMoveX(2, 1);
                yield return new WaitForSeconds(.03f);
            }
        }
        else if (!isOnRight)
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
        /*if (isOnRight) transform.DOMoveX(2, .1f).SetEase(Ease.Linear);
        else transform.DOMoveX(-2,.1f).SetEase(Ease.Linear);*/

        if (isOnRight)
        {

            transform.localPosition = new Vector3(-0.2f, 4.5f, 0);
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

        }
        else
        {

            transform.localPosition = new Vector3(0.2f, 4.5f, 0);
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

        }
    }


}
