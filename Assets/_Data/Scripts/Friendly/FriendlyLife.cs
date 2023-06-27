using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class FriendlyLife : MonoBehaviour
{
    [SerializeField]
    private GameObject FLife;
    
    void Start()
    {
        StartCoroutine(FriendlyLifeDown());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator FriendlyLifeDown()
    {
        while (true)
        {
            FLife.gameObject.GetComponent<Slider>().value -= (0.0001f);
            yield return new WaitForSeconds(0.01f);
        }
        
    }
}
