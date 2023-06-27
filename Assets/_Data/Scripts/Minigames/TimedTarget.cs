using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TimedTarget : MonoBehaviour
{
    [SerializeField] Transform  pivot;

    [SerializeField] private float duration = 1f;

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
        anim = pivot.DORotate(new Vector3(0f, 0f, -45f), duration).SetEase(Ease.InOutCubic).SetLoops(-1, LoopType.Yoyo);
    }
}
