using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YonlendirmeScript : MonoBehaviour
{

    [SerializeField] private bool _level1;
    [SerializeField] private bool _level2;

    [SerializeField] private bool _level1Platform1;
    [SerializeField] private bool _level1Platform2;

    [SerializeField] private bool _level2Platform1;
    [SerializeField] private bool _level2Platform2;
    [SerializeField] private bool _level2Platform3;
    [SerializeField] private bool _level2Platform4;

    [SerializeField] private GameObject _okYukariLevel1;
    [SerializeField] private GameObject _okAsagiLevel1;

    [SerializeField] private GameObject _ok1YukariLevel2;
    [SerializeField] private GameObject _ok1AsagiLevel2;
    [SerializeField] private GameObject _ok2YukariLevel2;
    [SerializeField] private GameObject _ok2AsagiLevel2;

    [SerializeField] private List<GameObject> _tikler = new List<GameObject>();


    void Start()
    {
        _okYukariLevel1.SetActive(false);
        _okAsagiLevel1.SetActive(false);
        _ok1YukariLevel2.SetActive(false);
        _ok1AsagiLevel2.SetActive(false);
        _ok2YukariLevel2.SetActive(false);
        _ok2AsagiLevel2.SetActive(false);

        _tikler[0].SetActive(false);
        _tikler[1].SetActive(false);
        _tikler[2].SetActive(false);
        _tikler[3].SetActive(false);
        _tikler[4].SetActive(false);
        _tikler[5].SetActive(false);

        if (_level1)
        {
            _okYukariLevel1.SetActive(true);
        }
        else if (_level2)
        {
            _ok1YukariLevel2.SetActive(true);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "platform" && _level1 && _level1Platform1)
        {
            _okYukariLevel1.SetActive(false);
            _tikler[0].SetActive(true);
            _okAsagiLevel1.SetActive(true);
        }
        else if (other.gameObject.tag == "platform" && _level1 && _level1Platform2)
        {
            _okAsagiLevel1.SetActive(false);
            _tikler[1].SetActive(true);
        }
        else if (other.gameObject.tag == "platform" && _level2 && _level2Platform1)
        {
            _ok1YukariLevel2.SetActive(false);
            _tikler[2].SetActive(true);
            _ok1AsagiLevel2.SetActive(true);
        }
        else if (other.gameObject.tag == "platform" && _level2 && _level2Platform2)
        {
            _ok1AsagiLevel2.SetActive(false);
            _tikler[3].SetActive(true);
            _ok2YukariLevel2.SetActive(true);
        }
        else if (other.gameObject.tag == "platform" && _level2 && _level2Platform3)
        {
            _ok2YukariLevel2.SetActive(false);
            _tikler[4].SetActive(true);
            _ok2AsagiLevel2.SetActive(true);
        }
        else if (other.gameObject.tag == "platform" && _level2 && _level2Platform4)
        {
            _ok2AsagiLevel2.SetActive(false);
            _tikler[5].SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "platform")
        {
            _tikler[0].SetActive(false);
            _tikler[1].SetActive(false);
            _tikler[2].SetActive(false);
            _tikler[3].SetActive(false);
            _tikler[4].SetActive(false);
            _tikler[5].SetActive(false);
        }
    }

}
