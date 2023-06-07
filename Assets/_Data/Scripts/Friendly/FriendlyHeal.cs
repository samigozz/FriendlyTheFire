using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyHeal : MonoBehaviour
{
    [SerializeField]
    private int heal;
    [SerializeField]
    private IntValue playerLives;

    private bool inRange;

    private void Start()
    {
        heal = 1;
        inRange = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        inRange = true;
        Debug.Log("por favor");
        StartCoroutine(FriendlyHealPlayer(collision));
    }

    private IEnumerator FriendlyHealPlayer(Collider2D collision)
    {
        while(inRange && playerLives.runtimeLives < 3)
        {
            yield return new WaitForSeconds(5.0f);

            var playerHeal = collision.gameObject.GetComponent<PlayerAddLife>();
            playerHeal.AddLife(heal);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inRange = false; 
    }
}
