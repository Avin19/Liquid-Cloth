using System.Collections;
using Unity.Mathematics;
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
                    rotationSpeed = -20f;
                    check = true;
                }

                if (hitInfo.transform == contaierTwo)
                {
                    selectedContaier = contaierTwo;
                    rotationSpeed = 20f;
                    check = true;
                }
            }
        }

        if (Input.GetMouseButtonDown(1) && selectedContaier != null)
        {
            
            check = false;
            selectedContaier = null;
        }

        if (check)
        {
            Vector3 moveDire= mCamera.ScreenToWorldPoint(Input.mousePosition);
            moveDire.z = 0f;
            selectedContaier.position = Vector3.Lerp(selectedContaier.position , moveDire , moveSpeed * Time.deltaTime);

        }

        if (Input.GetKey(KeyCode.R))
        {
            selectedContaier.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }

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


