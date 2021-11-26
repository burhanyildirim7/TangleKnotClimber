using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class FinishScript : MonoBehaviour
{
    [SerializeField] Animator GirlAnim;
    [SerializeField] GameObject SadFX;
    [SerializeField] GameObject HappyFX;
    [SerializeField] GameObject KalpFX;
    // Start is called before the first frame update
    void Start()
    {
        GirlAnim.SetBool("Happy", false);
        SadFX.SetActive(true);
        HappyFX.SetActive(false);
        KalpFX.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void oyunSonuFonk()
    {
        GirlAnim.SetBool("Happy",true); 
        SadFX.SetActive(false);
        HappyFX.SetActive(true);
        KalpFX.SetActive(true);
        StartCoroutine("finishDelay");
    }
    IEnumerator finishDelay()
    {

        yield return new WaitForSeconds(2f);
        GameObject.Find("UIController").GetComponent<UIControllerScript>().winGame();

    }
}
