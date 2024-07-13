using System;
using System.Collections;
using Unity.Mathematics;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    private Camera mCamera;
    [SerializeField] private Transform contaierOne;
    [SerializeField] private Transform contaierTwo;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;
    private Transform selectedContaier;
    private bool check=false;
    private bool rotateCheck;
    [SerializeField] private GameObject water;
    [SerializeField] private Transform fillPoint;

    private void Awake()
    {
        mCamera = Camera.main;
    }

  

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !check)
        {
            Ray ray = mCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (hitInfo.transform == contaierOne)
                {
                    selectedContaier = contaierOne;
                   
                    check = true;
                }

                if (hitInfo.transform == contaierTwo)
                {
                    selectedContaier = contaierTwo;
                 
                    check = true;
                }
            }
        }

        if (!Input.GetMouseButton(0))
        {
            check = false;
        }

        if (check && Input.GetMouseButton(0))
        {
            Vector3 moveDire= mCamera.ScreenToWorldPoint(Input.mousePosition);
            moveDire.z = 0f;
            selectedContaier.position = Vector3.Lerp(selectedContaier.position , moveDire , moveSpeed * Time.deltaTime);

        }

        if (rotateCheck)
        {
            selectedContaier.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }

    }

    public void Rotate()
    {
        rotateCheck = !rotateCheck;
    }

    public void RatateLeft()
    {
        rotationSpeed = 20f;
    }
    public void RatateRight()
    {
        rotationSpeed = -20f;
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

   

  
   
}


