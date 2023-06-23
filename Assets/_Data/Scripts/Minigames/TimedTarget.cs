using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TimedTarget : MonoBehaviour
{
    [SerializeField] Transform target, pivot;

    [SerializeField, Range(0f, 1f)] private float threshold = 0.97f;

    private Quaternion startRot;

    private Tween anim;

    private void OnEnable()
    {
        pivot.transform.rotation = Quaternion.Euler(0f, 0f, 45f);
        RotateAim();
    }

    private void OnDisable()
    {
        anim.Pause();
    }
    

    private void RotateAim()
    {
        anim = pivot.DORotate(new Vector3(0f, 0f, -45f), 1f).SetEase(Ease.InOutCubic).SetLoops(-1, LoopType.Yoyo);
    }
}
