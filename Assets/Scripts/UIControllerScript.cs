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
    [SerializeField] Text _levelText;

    [SerializeField] List<GameObject> StarObjs = new List<GameObject>();
    [SerializeField] LevelController LevelKontroller;

    private int _levelNumber;

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
        _levelNumber = PlayerPrefs.GetInt("LevelNumber");
        _levelText.text = "Level " + _levelNumber.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TapToStartFonk()//oyuna ba?lamak i?in
    {
        TapToStartScreenPanel.SetActive(false);
        GameScreenPanel.SetActive(true);
        WinScreenPanel.SetActive(false);
        LoseScreenPanel.SetActive(false);
        _levelNumber = PlayerPrefs.GetInt("LevelNumber");
        _levelText.text = "Level " + _levelNumber.ToString();
        isTapToStart = true;
    }

    public void winGame() //win screeni a?mak i?in-oyunu kazand?n
    {
        TapToStartScreenPanel.SetActive(false);
        GameScreenPanel.SetActive(false);
        WinScreenPanel.SetActive(true);
        LoseScreenPanel.SetActive(false);
        WSPCorrencyText.text = startSayac.ToString();
    }
    public void loseGame()//lose screeni a?mak i?in-oyunu kaybettin
    {
        TapToStartScreenPanel.SetActive(false);
        GameScreenPanel.SetActive(false);
        WinScreenPanel.SetActive(false);
        LoseScreenPanel.SetActive(true);
    }
    public void nextLevelButton()//win screeni ge?mek i?in-yeni leveli ba?latacak.
    {
        TapToStartScreenPanel.SetActive(true);
        GameScreenPanel.SetActive(false);
        WinScreenPanel.SetActive(false);
        LoseScreenPanel.SetActive(false);
        LevelKontroller.LevelDegistir();
        puanHesapla();
        for (int i = 0; i < StarObjs.Count; i++)
        {
            StarObjs[i].SetActive(false);
        }
        startSayac = 0;

    }
    public void resetLevelButton()//lose screeni ge?mek i?in-ayn? leveli ba?latacak.
    {
        TapToStartScreenPanel.SetActive(true);
        GameScreenPanel.SetActive(false);
        WinScreenPanel.SetActive(false);
        LoseScreenPanel.SetActive(false);
        LevelKontroller.LevelRestart();
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
        PlayerPrefs.SetInt("ToplamStarMiktari", tempToplamStar);
        TTSSPCorrencyText.text = toplamStarAdeti.ToString();
        GSPCorrencyText.text = toplamStarAdeti.ToString();
    }

}
