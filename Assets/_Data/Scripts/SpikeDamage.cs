using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
    [SerializeField]
    private GameObject playerCanvas;

    SetLives setLives;

    [SerializeField]
    private int damage;

    private void Start()
    {
        setLives = new SetLives();

        damage = 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var playerLives = collision.gameObject.GetComponent<SetLives>();

        if(playerLives != null)
        {
            playerLives.SubstractLifes(damage);
        }
    }
}
