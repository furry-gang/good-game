using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class asteriodplayer : MonoBehaviour
{
    public float ThrottlePower;
    public float TorguePower;
    private Rigidbody rb;

    private float torgueInput;
    private float throttleInput;
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
    }
     void FixedUpdate() {
        rb.AddRelativeForce(Vector3.forward * throttleInput * ThrottlePower, ForceMode.Force);
        rb.AddTorque(Vector3.up * torgueInput * TorguePower, ForceMode.Force);
        
     }
}
