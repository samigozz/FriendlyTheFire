using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class CameraFollowTarget : MonoBehaviour
{
    public GameObject target;
    public float PixelsPerUnit;
 
    void Update()
    {
        transform.position = PixelPerfectClamp(target.transform.position, PixelsPerUnit);
    }
 
    private Vector3 PixelPerfectClamp(Vector3 locationVector, float pixelsPerUnit)
    {
        Vector3 vectorInPixels = new Vector3(locationVector.x * pixelsPerUnit, 
            locationVector.y * pixelsPerUnit, 
            locationVector.z * pixelsPerUnit);
        
        return vectorInPixels / pixelsPerUnit;
    }
}
