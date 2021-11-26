using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YönlendirmeScript : MonoBehaviour
{
    [SerializeField] private bool _level1Platform1;
    [SerializeField] private bool _level1Platform2;

    [SerializeField] private bool _level2Platform1;
    [SerializeField] private bool _level2Platform2;
    [SerializeField] private bool _level2Platform3;
    [SerializeField] private bool _level2Platform4;

    [SerializeField] private GameObject _okYukariLevel1;
    [SerializeField] private GameObject _okAsagiLevel1;

    [SerializeField] private GameObject _okYukariLevel2;
    [SerializeField] private GameObject _okAsagiLevel2;

    [SerializeField] private List<GameObject> _tikler = new List<GameObject>();


    void Start()
    {
        _okYukariLevel1.SetActive(false);
        _okAsagiLevel1.SetActive(false);
        _okYukariLevel2.SetActive(false);
        _okAsagiLevel2.SetActive(false);

        _tikler[0].SetActive(false);
        _tikler[1].SetActive(false);
        _tikler[2].SetActive(false);
        _tikler[3].SetActive(false);
        _tikler[4].SetActive(false);
        _tikler[5].SetActive(false);
    }


}
