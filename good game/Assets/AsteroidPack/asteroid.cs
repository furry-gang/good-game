
using UnityEngine;

public class asteroid : MonoBehaviour
{
    public float RotatioSpeed;
    public float DriftingSpeed; 
    public AudioSource ExplosionAudioSource; 

    private Vector3 rotationAxis;
    private Vector3 driftingDirection; 

    void Start()
        {     
        rotationAxis = new Vector3(Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100)).normalized;
        driftingDirection =  new Vector3(Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100)).normalized;
        }

    // Update is called once per frame
    void Update()
     {
        transform.Translate(driftingDirection * DriftingSpeed * Time.deltaTime);
        transform.Rotate(rotationAxis, RotatioSpeed * Time.deltaTime);

        transform.position = new Vector3(transform.position.x, 0,transform.position.z);
     }
     void OnTriggerEnter(Collider other)
     {
         if(other.tag == "Player Laser")
         {
             ExplosionAudioSource.Play();
             Destroy(gameObject);
             Destroy(other.gameObject);
         }
     }
}
