using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroy : MonoBehaviour
{
   private void Awake() 
   {
     GameObject[] musicObjs = GameObject.FindGameObjectsWithTag("GameMusic"); 
     if (musicObjs.Length > 1)
     {
        Destroy(this.gameObject);
        return; 
     }
     DontDestroyOnLoad(this.gameObject);
   }
}