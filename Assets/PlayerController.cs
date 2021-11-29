using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public bool isOnRight;  // player sa?da m? solda m???
    public bool isPosLeft;
    public bool isAvaliable = false;
    [SerializeField] GameObject PlayerObje;
    [SerializeField] Animator playerAnimator;
    [SerializeField] bool finishSagda;

    private void Awake()
    {
        if (instance == null) instance = this;
        else instance = this;
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
            playerAnimator.SetBool("Jump", true);
            playerAnimator.SetBool("Idle", false);
            if (isOnRight)
            {
                if (isPosLeft)
                {
                    GetComponent<Rigidbody>().AddForce(new Vector3(-2.5f, 4.5f, 0), ForceMode.Impulse);
                    PlayerObje.transform.eulerAngles = new Vector3(0, -90, 0);
                }
                else
                {
                    GetComponent<Rigidbody>().AddForce(new Vector3(-4.5f, 4.5f, 0), ForceMode.Impulse);
                    PlayerObje.transform.eulerAngles = new Vector3(0, -90, 0);
                }
                //isOnRight = false;
            }
            else
            {
                if (isPosLeft)
                {
                    GetComponent<Rigidbody>().AddForce(new Vector3(4.5f, 4.5f, 0), ForceMode.Impulse);
                    PlayerObje.transform.eulerAngles = new Vector3(0, 90, 0);
                }
                else
                {
                    GetComponent<Rigidbody>().AddForce(new Vector3(2.5f, 4.5f, 0), ForceMode.Impulse);
                    PlayerObje.transform.eulerAngles = new Vector3(0, 90, 0);
                }
                //isOnRight = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        playerAnimator.SetBool("Jump", false);
        Debug.Log("?al??t?");
        if (collision.gameObject.tag == "platform")
        {
            isAvaliable = false;
            transform.parent.GetChild(0).gameObject.GetComponent<DedectSagControl>().dedectsagaktif = false;
            transform.parent.GetChild(1).gameObject.GetComponent<DedectSolControl>().dedectsolaktif = false;
            if (transform.parent.tag == "StartPlt")
            {
                transform.parent.GetChild(0).gameObject.GetComponent<BoxCollider>().enabled = false;
                transform.parent.GetChild(1).gameObject.GetComponent<BoxCollider>().enabled = false;
            }

            transform.SetParent(collision.gameObject.transform);

            transform.parent.GetChild(0).gameObject.GetComponent<DedectSagControl>().dedectsagaktif = true;
            transform.parent.GetChild(1).gameObject.GetComponent<DedectSolControl>().dedectsolaktif = true;

            SetPlayerPlatformPosition(collision.gameObject);

        }
        else if (collision.gameObject.tag == "Finish")
        {
            playerAnimator.SetBool("Victory", true);
            collision.gameObject.GetComponent<FinishScript>().oyunSonuFonk();
            transform.SetParent(collision.gameObject.transform);
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

        }
        else if (collision.gameObject.tag == "Obstacle")
        {
            isAvaliable = false;
            transform.parent.GetChild(0).gameObject.GetComponent<DedectSagControl>().dedectsagaktif = false;
            transform.parent.GetChild(1).gameObject.GetComponent<DedectSolControl>().dedectsolaktif = false;
            if (transform.parent.tag == "StartPlt")
            {
                transform.parent.GetChild(0).gameObject.GetComponent<BoxCollider>().enabled = false;
                transform.parent.GetChild(1).gameObject.GetComponent<BoxCollider>().enabled = false;
            }

            transform.SetParent(collision.gameObject.transform);

            transform.parent.GetChild(0).gameObject.GetComponent<DedectSagControl>().dedectsagaktif = true;
            transform.parent.GetChild(1).gameObject.GetComponent<DedectSolControl>().dedectsolaktif = true;

            SetPlayerPlatformPosition(collision.gameObject);
            playerAnimator.SetBool("Idle", true);

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

    public void SetPlayerPlatformPosition(GameObject tempTagObj)
    {
        /*if (isOnRight) transform.DOMoveX(2, .1f).SetEase(Ease.Linear);
        else transform.DOMoveX(-2,.1f).SetEase(Ease.Linear);*/

        if (isOnRight)
        {
            if (tempTagObj.tag == "Obstacle")
            {
                transform.localPosition = new Vector3(-0.1f, 2.8f, 0);
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

            }
            else
            {
                transform.localPosition = new Vector3(-0.1f, 4.5f, 0);
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

            }

        }
        else
        {
            if (tempTagObj.tag == "Obstacle")
            {
                transform.localPosition = new Vector3(0.1f, 2.8f, 0);
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

            }
            else
            {
                transform.localPosition = new Vector3(0.1f, 4.5f, 0);
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "OrtaNokta")
        {
            BoolScript._ortaNoktaKontrol = true;
        }
    }
}
