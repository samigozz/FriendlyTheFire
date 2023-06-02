using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName =("TuMadreEstaGorda"))]
public class Data : ScriptableObject
{
    [SerializeField]
    private int lives = 3;

    public int getLives()
    {
        return lives;
    }
}
