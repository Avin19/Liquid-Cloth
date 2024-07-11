using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;


public class Manager : MonoBehaviour
{  
   
   [SerializeField] private Button liquidBtn;
   [SerializeField] private Button clothBtn;
   [SerializeField] private Transform loadingPanel;

   private bool bLoadDone;
   private int index = 0;

   private void Awake()
   {
      
      liquidBtn.onClick.AddListener( () => Liquid());
      clothBtn.onClick.AddListener( () => Cloth());
   }

   private void Start()
   {
      loadingPanel.gameObject.SetActive(false);
   }

   private void Liquid()
   {
      bLoadDone = false;
      index = 1;
      StartCoroutine(LoadAsyncScene());
   }

   private void Cloth()
   {
      bLoadDone = false;
      index = 2;
      StartCoroutine(LoadAsyncScene());
   }

   private IEnumerator LoadAsyncScene()
   {
      AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(index, LoadSceneMode.Single);
      asyncLoad.allowSceneActivation = false;
      loadingPanel.gameObject.SetActive(true);
     
      while (!asyncLoad.isDone)
      {
         if (asyncLoad.progress >= 0.9f)
         {
            loadingPanel.gameObject.SetActive(false);
            asyncLoad.allowSceneActivation = true;
         }
         yield return null;
      }
      bLoadDone = asyncLoad.isDone;
   }

}


