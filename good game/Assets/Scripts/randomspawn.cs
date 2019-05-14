using UnityEngine;
 using System.Collections;
 
 public class randomspawn : MonoBehaviour {
 
     public GameObject coinDrop;
     public float timer = 0f;
     public float freq = 0.1f;
     public Vector3 position;


     void Update() 
     {
         if(timer <= 0)
         {
             position = transform.position + new Vector3(Random.Range(-50.0F, 50.0F), 0, Random.Range(-50.0F, 50.0F));
             Instantiate(coinDrop, position, Quaternion.identity);
             timer = freq;
         } else {
             timer -= Time.deltaTime;
         }
     }

 }
