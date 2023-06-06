using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
    [SerializeField]
    private int damage;

    private void Start()
    {
        damage = 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var playerTakeDamage = collision.gameObject.GetComponent<TakeDamage>();

        playerTakeDamage.SubstractLifes(damage);
    }
}
