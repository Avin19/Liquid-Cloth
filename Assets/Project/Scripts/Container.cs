using System;
using UnityEngine;



public class Container : MonoBehaviour
{
   
    private bool checkPour;
    [SerializeField] private GameObject currentContainer;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name.Contains("Sphere") && !checkPour)
        {
            currentContainer = other.gameObject;
            AudioManagerLiquid.Instance.PlayPourSound();
            checkPour = true;
            
        }
    
    }

    private void ResetTrigger()
    {
       
        checkPour = false;
    }
}


