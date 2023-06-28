using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WoodUIController : MonoBehaviour
{
    [SerializeField] private IntValue woodValue;
    [SerializeField] private TextMeshProUGUI counterText;
    
    public void UpdateWoodCount()
    {
        counterText.text = woodValue.runtimeValue.ToString("000");
    }
}
