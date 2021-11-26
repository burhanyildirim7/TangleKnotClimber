using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScripti : MonoBehaviour
{
    private bool kontrol;
    // Start is called before the first frame update
    void Start()
    {
        kontrol = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player"&& kontrol==false)
        {
            kontrol = true;
            FindObjectOfType<UIControllerScript>().starCollect();
            Destroy(gameObject);
        }
    }
}
