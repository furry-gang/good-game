using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymotor : MonoBehaviour
{

    public float Speed;
    public float AngualarSpeeed;
    public AudioClip ExplosionAudioClip;
    
    private Vector3 direction; 

    
    void Start()
    {
        direction = new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100)).normalized;
    }

    
    void Update()
    {
       transform.Rotate(Vector3.up, AngualarSpeeed * Time.deltaTime); 
       transform.Translate(direction * Speed * Time.deltaTime, Space.World);
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "laser")
        {
            Destroy(other.gameObject);
            //CreateAudioHelper.CreateAudioGameObject(ExplosionAudioClip, "EnemyDestroySound", transform.position);

            Destroy(this.gameObject);
        }
    }

}
