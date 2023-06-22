using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TimedTarget : MonoBehaviour
{
    [SerializeField] Transform target, pivot;

    [SerializeField, Range(0f, 1f)] private float threshold = 0.97f;

    private void OnEnable()
    {
        RotateAim();
    }
    private void RotateAim()
    {
        pivot.DORotate(new Vector3(0f, 0f, -45f), 1f).SetEase(Ease.InOutCubic).SetLoops(-1, LoopType.Yoyo);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float result = Mathf.Clamp(Vector3.Dot(target.transform.up, pivot.transform.up), 0f, 1f);
            Debug.Log(result);
            if (result >= 0.95f || result <= -0.95f)
            {
                Debug.Log("Hit!");
            }
            else
            {
                Debug.Log("Miss!");
            }
        }
        
    }
}
