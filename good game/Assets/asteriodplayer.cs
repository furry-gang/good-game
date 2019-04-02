using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class asteriodplayer : MonoBehaviour
{
    public float ThrottlePower;
    public float TorguePower;
    private Rigidbody rb;

    private float torgueInput;
    private float throttleInput;
    public GameObject shotObject;
    public Transform spawn1;
    public Transform spawn2;
    private float counter = 0;
    void Start()
    {
      rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        torgueInput = Input.GetAxisRaw("Horizontal");
        throttleInput = Input.GetAxisRaw("Vertical");
        throttleInput = Mathf.Clamp(throttleInput, 0, 1);

        var onScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
        var newPosition = onScreenPosition;
        
        if(onScreenPosition.x < 0){
            newPosition.x = Screen.width;
        }
        if(onScreenPosition.x > Screen.width) {
            newPosition.x = 0;
        }
        if(onScreenPosition.y < 0) {
            newPosition.y = Screen.height;
        }
        if(onScreenPosition.y > Screen.height) {
            newPosition.y = 0;
        }
        var worldCoordinates = Camera.main.ScreenToWorldPoint(newPosition);
        this.transform.position = new Vector3(worldCoordinates.x, 0, worldCoordinates.z);
        
        if(counter <= 0) {
            if(Input.GetButton("Fire1")) {
                GameObject newObject = Instantiate(shotObject, spawn1.transform.position, spawn1.transform.rotation);
                newObject.transform.Rotate(90, 0, 0);
                newObject.SetActive(true);
                GameObject newObject2 = Instantiate(shotObject, spawn2.transform.position, spawn2.transform.rotation);
                newObject2.transform.Rotate(90, 0, 0);
                newObject2.SetActive(true);
                counter = 0.5f;
            }
        } else {
            counter -= Time.deltaTime;
        }
    }
     void FixedUpdate() {
        //rb.AddRelativeForce(Vector3.forward * 1, ForceMode.Force);
        transform.Translate(Vector3.forward * 0.2f);
        //rb.AddTorque(Vector3.up * torgueInput * TorguePower, ForceMode.Force);
        transform.Rotate(Input.GetAxisRaw("Vertical"), 0, -Input.GetAxisRaw("Horizontal"));
     }
}
