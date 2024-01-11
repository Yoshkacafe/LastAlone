using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{

    public ProgressBar Pb;
    public int Valeur = 50;

    // Update is called once per frame
    void Update()
    {
        Pb.BarValue = Valeur;
    }
}
