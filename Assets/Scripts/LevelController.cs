using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] List<GameObject> Leveller = new List<GameObject>();
    List<GameObject> LevelStok = new List<GameObject>();
    int tempLevel;
    int mevcutLevel;

    // Start is called before the first frame update
    void Start()
    {
        tempLevel = 0;
        mevcutLevel = 0;

        //mevcutLevel = PlayerPrefs.GetInt("MevcutLevel");
        LevelStok.Clear();
        LevelStok.Add(Instantiate(Leveller[mevcutLevel], new Vector3(0, 0, 0), Quaternion.identity));

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void nextLevelFonk()
    {
        for (int i = 0; i < LevelStok.Count; i++)
        {
            Destroy(LevelStok[i]);
        }
        mevcutLevel++;
        LevelStok.Clear();
        LevelStok.Add(Instantiate(Leveller[mevcutLevel], new Vector3(0, 0, 0), Quaternion.identity)) ;
        PlayerPrefs.SetInt("MevcutLevel",mevcutLevel);
    }
    public void resetLevelFonk()
    {
        for (int i = 0; i < LevelStok.Count; i++)
        {
            Destroy(LevelStok[i]);
        }
        LevelStok.Clear();
        LevelStok.Add(Instantiate(Leveller[mevcutLevel], new Vector3(0, 0, 0), Quaternion.identity));
    }





}
