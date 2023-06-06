using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    [SerializeField]
    private IntValue playerLives;
    [SerializeField]
    private GameEvent OnTakeDamage;

    public void SubstractLifes(int damage)
    {
        playerLives.runtimeLives -= damage;

        OnTakeDamage.Raise();
    }
}
