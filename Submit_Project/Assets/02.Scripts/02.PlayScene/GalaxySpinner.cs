using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalaxySpinner : MonoBehaviour
{
    void Update()
    {
        GalaxyRotation(); /***** Abstraction *****/
    }

    void GalaxyRotation()
    {
        transform.RotateAround(Vector3.zero, Vector3.forward, -1.0f * Time.deltaTime);
    }
}