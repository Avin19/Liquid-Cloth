using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ClothManager : MonoBehaviour
{
    [SerializeField] private Transform moveObject;
    private Transform selectedobject;
    private Camera mCamera;
    private bool check;
    private Vector3 moveDir;

    private void Awake()
    {
        mCamera = Camera.main;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(2);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            moveDir = mCamera.ScreenToWorldPoint(Input.mousePosition);
            moveDir.z = 0f;
            moveObject.position = Vector3.Lerp(moveObject.position , moveDir, 5f * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadScene();
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            MainMenu();
        }

       
    }
}


