using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLives : MonoBehaviour
{
    [SerializeField]
    private Data myData;
    
    [SerializeField]
    private Sprite livesSprite;

    private SpriteRenderer[] livesRenderers;

    private int offset = 1;

    void Start()
    {
        livesRenderers = new SpriteRenderer[myData.getLives()];

        for (int i = 0; i < myData.getLives(); i++)
        {
            GameObject lifeObject = new GameObject("Life" + i);
            SpriteRenderer spriteRenderer = lifeObject.AddComponent<SpriteRenderer>();

            spriteRenderer.sprite = livesSprite;

            lifeObject.transform.position = new Vector3(i + offset, -0, 0);

            livesRenderers[i] = spriteRenderer;

            offset += offset;
        }
    }
 
}
