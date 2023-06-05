using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetLives : MonoBehaviour
{
    [SerializeField]
    private Data myData;

    [SerializeField]
    private Transform LifeContainer;

    [SerializeField]
    private GameObject livesSprite;

    private List<GameObject> livesRenderers = new();

    private int playerLifes;

    void Start()
    {
        livesRenderers.Capacity = myData.getLives();

        playerLifes = myData.getLives();

        UpdateLives();
    }

    public void UpdateLives()
    {   
        for (int i = 0; i < playerLifes; i++)
        {
            var lifeObject = Instantiate(livesSprite);
            livesRenderers.Add(lifeObject);

            if(LifeContainer)
                lifeObject.transform.SetParent(LifeContainer);
        }
    }

    public void SubstractLifes(int damage)
    {
        livesRenderers[playerLifes - 1].gameObject.SetActive(false);

        playerLifes -= damage;

    }
}
