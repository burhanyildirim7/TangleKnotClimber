using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControllerScript : MonoBehaviour
{
    [SerializeField] GameObject TapToStartScreenPanel;
    [SerializeField] GameObject GameScreenPanel;
    [SerializeField] GameObject WinScreenPanel;
    [SerializeField] GameObject LoseScreenPanel;

    // Start is called before the first frame update
    void Start()
    {
        TapToStartScreenPanel.SetActive(true);
        GameScreenPanel.SetActive(false);
        WinScreenPanel.SetActive(false);
        LoseScreenPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TapToStartFonk()//oyuna baþlamak için
    {
        TapToStartScreenPanel.SetActive(false);
        GameScreenPanel.SetActive(true);
        WinScreenPanel.SetActive(false);
        LoseScreenPanel.SetActive(false);
    }

    public void winGame() //win screeni açmak için-oyunu kazandýn
    {
        TapToStartScreenPanel.SetActive(false);
        GameScreenPanel.SetActive(false);
        WinScreenPanel.SetActive(true);
        LoseScreenPanel.SetActive(false);
    }
    public void loseGame()//lose screeni açmak için-oyunu kaybettin
    {
        TapToStartScreenPanel.SetActive(false);
        GameScreenPanel.SetActive(false);
        WinScreenPanel.SetActive(false);
        LoseScreenPanel.SetActive(true);
    }
    public void nextLevelButton()//win screeni geçmek için-yeni leveli baþlatacak.
    {

        TapToStartScreenPanel.SetActive(true);
        GameScreenPanel.SetActive(false);
        WinScreenPanel.SetActive(false);
        LoseScreenPanel.SetActive(false);
    }
    public void resetLevelButton()//lose screeni geçmek için-ayný leveli baþlatacak.
    {

        TapToStartScreenPanel.SetActive(true);
        GameScreenPanel.SetActive(false);
        WinScreenPanel.SetActive(false);
        LoseScreenPanel.SetActive(false);
    }





}
