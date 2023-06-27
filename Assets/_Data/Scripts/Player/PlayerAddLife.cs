using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAddLife : MonoBehaviour
{
    [SerializeField]
    private IntValue playerLives;
    [SerializeField]
    private GameEvent OnHealLife;

    public void AddLife(int heal)
    {

        playerLives.runtimeValue += heal;

        OnHealLife.Raise();
    }
}
