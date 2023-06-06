using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetLives : MonoBehaviour
{
    [SerializeField]
    private IntValue playerLives;

    [SerializeField]
    private Transform LifeContainer;

    [SerializeField]
    private GameObject livesSprite;

    private List<GameObject> livesRenderers = new();

    void Start()
    {
        livesRenderers.Capacity = playerLives.runtimeLives;

        SetInitialLives();
    }

    public void SetInitialLives()
    {
        for (int i = 0; i < playerLives.runtimeLives; i++)
        {
            var lifeObject = Instantiate(livesSprite);
            livesRenderers.Add(lifeObject);

            if(LifeContainer)
                lifeObject.transform.SetParent(LifeContainer);
        }
    }

    public void UpdateLives()
    {
        if (LifeContainer.childCount > 0)
        {
            LifeContainer.GetChild(playerLives.runtimeLives).gameObject.SetActive(false);
        }
    }
}
