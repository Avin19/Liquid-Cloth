using System;
using UnityEngine;



public class Ground : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name.Contains("Sphere"))
        {
            Destroy(other.gameObject);
        }
    }
}


