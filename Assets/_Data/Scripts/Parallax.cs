using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] Transform subject;

    Vector2 startPosition;
    Vector2 travel => (Vector2)cam.transform.position - startPosition;
    Vector2 paralaxFactor;

    private void Start()
    {
        startPosition = transform.position;
    }
    private void Update()
    {
        transform.position = startPosition + travel;
    }
}
