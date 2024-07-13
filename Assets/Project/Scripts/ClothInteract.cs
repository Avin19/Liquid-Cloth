using System;
using UnityEngine;



public class ClothInteract : MonoBehaviour
{
    private bool delay;

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.name);
        if (!delay)
        {
            AudioManageCloth.Instance.PlaySound();
            delay = true;
            Invoke(nameof(Resetdelay),2f);
        }
    }

    private void Resetdelay()
    {
        delay = false;
    }
}


