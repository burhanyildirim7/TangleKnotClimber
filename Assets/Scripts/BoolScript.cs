using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolScript : MonoBehaviour
{

    public static bool _bireDegdi;
    public static bool _ikiyeDegdi;
    public static bool _üceDegdi;
    public static bool _dördeDegdi;

    public static bool _ortaNoktaKontrol;

    void Start()
    {
        _bireDegdi = false;
        _ikiyeDegdi = false;
        _üceDegdi = false;
        _dördeDegdi = false;
        _ortaNoktaKontrol = false;
    }


}
