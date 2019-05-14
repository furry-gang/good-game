using UnityEngine;
 using System.Collections;
 
 public class randomufo : MonoBehaviour {
 
     public GameObject coinDrop;
     public float timer = 0f;
     public float freq = 0.1f;
     public Vector3 position;


     void Update() 
     {
         if(timer <= 0)
         {
             position = new Vector3(Random.Range(0.0F, 10.0F), 0, Random.Range(0.0F, 10.0F));
             Instantiate(coinDrop, position, Quaternion.identity);
             timer = freq;
         } else {
             timer -= Time.deltaTime;
         }
     }

 }

