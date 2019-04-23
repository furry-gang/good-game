
using System.Collections;
using UnityEngine;

public class asteroid : MonoBehaviour
{
    public float RotatioSpeed;
    public float DriftingSpeed; 
    public AudioSource ExplosionAudioSource; 

    private Vector3 rotationAxis;
    private Vector3 driftingDirection; 
    private MeshRenderer meshRanderer;
    private SphereCollider SphereCollider;

    void Start()
        {     
        rotationAxis = new Vector3(Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100)).normalized;
        driftingDirection =  new Vector3(Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100)).normalized;

            meshRanderer = GetComponentInChildren<MeshRenderer>();
            SphereCollider = GetComponentInChildren<SphereCollider>();
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
         //Debug.Log(other.tag);
         if(other.tag == "Player Laser")
         {
             StartCoroutine(PlayAudioAndDestory(other));

             
         }
     }
     private IEnumerator PlayAudioAndDestory(Collider other)
     {
         meshRanderer.enabled = false;
         SphereCollider.enabled = false;
            ExplosionAudioSource.Play();
            yield return new WaitForSeconds(ExplosionAudioSource.clip.length);
             Destroy(gameObject);
             if (other != null)
             {
                  Destroy(other.gameObject);
             }

            
     }
     
}
