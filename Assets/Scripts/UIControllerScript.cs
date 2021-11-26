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

    public void TapToStartFonk()//oyuna ba�lamak i�in
    {
        TapToStartScreenPanel.SetActive(false);
        GameScreenPanel.SetActive(true);
        WinScreenPanel.SetActive(false);
        LoseScreenPanel.SetActive(false);
    }

    public void winGame() //win screeni a�mak i�in-oyunu kazand�n
    {
        TapToStartScreenPanel.SetActive(false);
        GameScreenPanel.SetActive(false);
        WinScreenPanel.SetActive(true);
        LoseScreenPanel.SetActive(false);
    }
    public void loseGame()//lose screeni a�mak i�in-oyunu kaybettin
    {
        TapToStartScreenPanel.SetActive(false);
        GameScreenPanel.SetActive(false);
        WinScreenPanel.SetActive(false);
        LoseScreenPanel.SetActive(true);
    }
    public void nextLevelButton()//win screeni ge�mek i�in-yeni leveli ba�latacak.
    {

        TapToStartScreenPanel.SetActive(true);
        GameScreenPanel.SetActive(false);
        WinScreenPanel.SetActive(false);
        LoseScreenPanel.SetActive(false);
    }
    public void resetLevelButton()//lose screeni ge�mek i�in-ayn� leveli ba�latacak.
    {

        TapToStartScreenPanel.SetActive(true);
        GameScreenPanel.SetActive(false);
        WinScreenPanel.SetActive(false);
        LoseScreenPanel.SetActive(false);
    }





}
