using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControllerScript : MonoBehaviour
{
    [SerializeField] GameObject TapToStartScreenPanel;
    [SerializeField] GameObject GameScreenPanel;
    [SerializeField] GameObject WinScreenPanel;
    [SerializeField] GameObject LoseScreenPanel;
    [SerializeField] Text TTSSPCorrencyText;
    [SerializeField] Text GSPCorrencyText;
    [SerializeField] Text WSPCorrencyText;

    [SerializeField] List<GameObject> StarObjs = new List<GameObject>();
    [SerializeField] LevelController LevelKontroller;


    public bool isTapToStart;
    private int toplamStarAdeti;
    private int tempToplamStar;
    private int startSayac;
    // Start is called before the first frame update
    void Start()
    {
        toplamStarAdeti = 0;
        startSayac = 0;
        isTapToStart = false;
        TapToStartScreenPanel.SetActive(true);
        GameScreenPanel.SetActive(false);
        WinScreenPanel.SetActive(false);
        LoseScreenPanel.SetActive(false);
        for (int i = 0; i < StarObjs.Count; i++)
        {
            StarObjs[i].SetActive(false);
        }
        toplamStarAdeti = PlayerPrefs.GetInt("ToplamStarMiktari");
        TTSSPCorrencyText.text = toplamStarAdeti.ToString();
        GSPCorrencyText.text = toplamStarAdeti.ToString();
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
        isTapToStart = true;
    }

    public void winGame() //win screeni açmak için-oyunu kazandýn
    {
        TapToStartScreenPanel.SetActive(false);
        GameScreenPanel.SetActive(false);
        WinScreenPanel.SetActive(true);
        LoseScreenPanel.SetActive(false);
        WSPCorrencyText.text = startSayac.ToString();
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
        LevelKontroller.nextLevelFonk();
        puanHesapla();
        for (int i = 0; i < StarObjs.Count; i++)
        {
            StarObjs[i].SetActive(false);
        }
        startSayac = 0;

    }
    public void resetLevelButton()//lose screeni geçmek için-ayný leveli baþlatacak.
    {
        TapToStartScreenPanel.SetActive(true);
        GameScreenPanel.SetActive(false);
        WinScreenPanel.SetActive(false);
        LoseScreenPanel.SetActive(false);
        LevelKontroller.resetLevelFonk();
        for (int i = 0; i < StarObjs.Count; i++)
        {
            StarObjs[i].SetActive(false);
        }
        startSayac = 0;
    }

    public void starCollect() 
    {
        StarObjs[startSayac].SetActive(true);
        startSayac++;
    }

    public void puanHesapla() 
    {
        tempToplamStar = toplamStarAdeti + startSayac;
        PlayerPrefs.SetInt("ToplamStarMiktari",tempToplamStar);
        TTSSPCorrencyText.text = toplamStarAdeti.ToString();
        GSPCorrencyText.text = toplamStarAdeti.ToString();
    }

}
