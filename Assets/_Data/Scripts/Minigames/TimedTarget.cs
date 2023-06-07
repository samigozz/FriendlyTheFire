using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TimedTarget : MonoBehaviour
{
    [SerializeField] GameObject target, pivot;

    private void OnEnable()
    {
        RotateAim();
    }
    private void RotateAim()
    {
        pivot.transform.DORotate(new Vector3(0f, 0f, -45f), 1f).SetEase(Ease.InOutCubic).SetLoops(-1, LoopType.Yoyo);
    }
}
