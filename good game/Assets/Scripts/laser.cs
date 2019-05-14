using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer <= 0) {
            Destroy(gameObject);
        } else {
            timer -= Time.deltaTime;
        }
        transform.Translate(new Vector3(0, 50 * Time.deltaTime, 0));
    }
}
