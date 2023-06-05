using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Parallax : MonoBehaviour
{
    //Variables
    [SerializeField] private float parallaxFactor;
    [SerializeField] private Camera cam;
    private float ppu;

    private Vector2 startPosition;

    private float length;
    
    private void Start()
    {
        startPosition = transform.position;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        ppu = GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
    }
    private void Update()
    {
        float temp     = cam.transform.position.x * (1 - parallaxFactor);       
        float distance = cam.transform.position.x * parallaxFactor;
        
        Vector3 newPosition = new Vector3(startPosition.x + distance, transform.position.y, transform.position.z);

        transform.position = PixelPerfectClamp(newPosition, ppu);

        if (temp > startPosition.x + (length / 2))
            startPosition.x += length;
        else if (temp < startPosition.x - (length / 2))
            startPosition.x -= length;
    }
    private Vector3 PixelPerfectClamp(Vector3 locationVector, float pixelsPerUnit)
    {
        Vector3 vectorInPixels = new Vector3(locationVector.x * pixelsPerUnit, 
            locationVector.y * pixelsPerUnit, 
            locationVector.z * pixelsPerUnit);
        
        return vectorInPixels / pixelsPerUnit;
    }
}
