using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyHeal : MonoBehaviour
{
    [SerializeField]
    private int heal;
    [SerializeField]
    private IntValue playerLives;

    [SerializeField] 
    private GameObject KeyPrompt;

    private bool inRange;

    private void Start()
    {
        heal = 1;
        inRange = false;
        KeyPrompt.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        inRange = true;
        KeyPrompt.SetActive(true);
        StartCoroutine(FriendlyHealPlayer(collision));
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        inRange = false; 
        KeyPrompt.SetActive(false);
    }

    private IEnumerator FriendlyHealPlayer(Collider2D collision)
    {
        while(inRange && playerLives.runtimeValue < 3)
        {
            yield return new WaitForSeconds(5.0f);

            var playerHeal = collision.gameObject.GetComponent<PlayerAddLife>();
            playerHeal.AddLife(heal);
        }
    }
}
