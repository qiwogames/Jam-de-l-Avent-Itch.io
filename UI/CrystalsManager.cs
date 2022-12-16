using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrystalsManager : MonoBehaviour
{
    public int nbrCrystals = 0;
    private int maxNbrCrystal = 7;

    public Text crystalCounterText;

    void Start()
    {
        crystalCounterText.text = " CRISTAUX : " + nbrCrystals + " / 7 ";
    }
    //60fps

    void Update()
    {
        crystalCounterText.text = " CRISTAUX : " + nbrCrystals + " / 7 ";
        if (nbrCrystals >= maxNbrCrystal)
        {
            nbrCrystals = maxNbrCrystal;
        }

        if (nbrCrystals <= 0)
        {
            nbrCrystals = 0;
        }
    }

    public void addCrystal()
    {
        nbrCrystals += 1;
    }

}