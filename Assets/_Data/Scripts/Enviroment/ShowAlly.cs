using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Slider = UnityEngine.UI.Slider;

public class ShowAlly : MonoBehaviour
{
    [SerializeField]
    private GameObject Ally1;
    [SerializeField]
    private GameObject Ally2;
    [SerializeField]
    private GameObject Ally3;
    [SerializeField]
    private GameObject Ally4;
    [SerializeField]
    private Slider FLife;
    
    void Update()
    {
        if (FLife.value > 0.65f)
        {
            Ally4.SetActive(true);
        }
        
        if (FLife.value > 0.75f)
        {
            Ally3.SetActive(true);
        }
        
        if (FLife.value > 0.85f)
        {
            Ally2.SetActive(true);
        }
        
        if (FLife.value > 0.95f)
        {
            Ally1.SetActive(true);
        }
    }
}
