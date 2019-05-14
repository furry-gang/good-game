using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerhealth : MonoBehaviour
{
    public float Health = 3f;
    private float timer = 0f;
    // Start is called before the first frame update

    public Transform SpawnPoint;
    void Start()
    {

    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D other)
    {

        if(other.transform.tag == "enemy")
        {
            if(timer <= 0) {
                Debug.Log(other.transform.tag);
                Health -= 1;
                timer = 1f;
                if (Health <= 0)
                {
                    Death(); 
                } 
            }
        } 
    }
    public void Death() 
    {
        transform.position = SpawnPoint.transform.position;
        Health = 3f;
    }
    void Update()
    {
        if(timer > 0) 
        {
            timer -= Time.deltaTime;
        }
    }
}
