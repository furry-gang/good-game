using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shot : MonoBehaviour
{
    public GameObject shotObject;
    private float counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(counter <= 0) {
            if(Input.GetButton("Fire1")) {
                createNew();
                counter = 0.5f;
            }
        } else {
            counter -= Time.deltaTime;
        }
    }
    void createNew() {
        Debug.Log(transform.position);
        GameObject newObject = Instantiate(shotObject, transform.position, transform.rotation);
        newObject.transform.Rotate(90, 0, 0);
        newObject.SetActive(true);
        
    }
}
