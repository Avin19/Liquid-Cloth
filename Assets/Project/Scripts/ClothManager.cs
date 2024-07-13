using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ClothManager : MonoBehaviour
{
    [SerializeField] private Transform moveObject;
    private Transform selectedobject;
    private Camera mCamera;
    private bool delay;

    private Vector3 moveDir;

    private void Awake()
    {
        mCamera = Camera.main;
    }

  
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) )
        {
            moveDir = mCamera.ScreenToWorldPoint(Input.mousePosition);
            moveDir.z = 0f;
            moveObject.position = Vector3.Lerp(moveObject.position , moveDir, 5f * Time.deltaTime);
            if(!delay)
            {
                AudioManageCloth.Instance.PlaySound();
                delay = true;
                Invoke(nameof(ResetDelay),2f);
            }
        }
        else
        {
            AudioManageCloth.Instance.Stop();
        }

       

       
    }

    private void ResetDelay()
    {
        delay = false;
    }
}


