using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymotor : MonoBehaviour
{

    public float Speed; //gör en flott som gör en speed 
    public float AngualarSpeeed; //snurra med hastighet
    public AudioClip ExplosionAudioClip; //gör ett ljud som man kan lägga till
    
    private Vector3 direction; //gör så att du kan röra dig i en direction 

    
    void Start()
    {
        direction = new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100)).normalized; //vilket håll den ska röra sig åt
    }

    
    void Update()
    {
       transform.Rotate(Vector3.up, AngualarSpeeed * Time.deltaTime); //gör så att object kan rotera och snurra
       transform.Translate(direction * Speed * Time.deltaTime, Space.World); //gör så att du kan röra dig i en directions plus speed i världen
    }


    void OnTriggerEnter(Collider other) // denna gör så när något går ihop med lasern så kommer något att hända
    {
        if(other.tag == "laser") // om laser träffa så kommer det som stå under att hända
        {
            Destroy(other.gameObject); // gör så att när lasern träffar så går objektet sönder
            //CreateAudioHelper.CreateAudioGameObject(ExplosionAudioClip, "EnemyDestroySound", transform.position);

            Destroy(this.gameObject); //förstör detta ojektet
        }
    }

}
