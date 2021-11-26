using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DedectSolControl : MonoBehaviour
{
    public static DedectSolControl instance;
    public bool dedectsolaktif;
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
        if (other.CompareTag("dedectSag"))
        {
            if (dedectsolaktif==true)
            {
                PlayerController.instance.isAvaliable = true;
                PlayerController.instance.isOnRight = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("dedectSag"))
        {
            if (dedectsolaktif==true)
            {
                PlayerController.instance.isAvaliable = false;
            }
        }
    }
}
