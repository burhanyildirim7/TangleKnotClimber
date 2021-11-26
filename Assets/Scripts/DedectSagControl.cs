using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DedectSagControl : MonoBehaviour
{
    public static DedectSagControl instance;
    public bool dedectsagaktif;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("dedectSol"))
        {
            if (dedectsagaktif==true)
            {
                PlayerController.instance.isAvaliable = true;
                PlayerController.instance.isOnRight = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("dedectSol"))
        {
            if (dedectsagaktif == true)
            {
                PlayerController.instance.isAvaliable = false;
            }
        }
    }
}
