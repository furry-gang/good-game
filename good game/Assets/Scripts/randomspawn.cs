using UnityEngine;
 using System.Collections;
 
 public class randomspawn : MonoBehaviour {
 
     public GameObject coinDrop; //gör ett objekt 
     public float timer = 0f; // gör en timer
     public float freq = 0.1f; //skapar en float
     public Vector3 position; // spawnar på en position


     void Update() 
     {
         if(timer <= 0) //om tiden är mindre än noll
         {
             position = transform.position + new Vector3(Random.Range(-50.0F, 50.0F), 0, Random.Range(-50.0F, 50.0F)); // positionen är lika med olika posistionen plus new vector och dem spawnars random mellan dessa kodinatorna
             Instantiate(coinDrop, position, Quaternion.identity); //gör en clone och spawnerna på den positionen
             timer = freq; //timer lika med 0,1
         } else {
             timer -= Time.deltaTime; //tiden är lika med 
         }
     }

 }
