using UnityEngine;


public class PlayerController : MonoBehaviour
{
    Rigidbody rigidbody;
    public float speed = 20f;
    float airSpeed=20;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    [Range(1, 10)]
    public float jumpVelocity;

    private Vector3 turnRot;
    public float rotspeed;
    bool isInterracting=false;
    private void Start()    {
        rigidbody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {   //<z ekseninde hareket>
        float z = Input.GetAxis("Horizontal");
        Vector3 move = Vector3.forward * z;
        
        if (rigidbody.velocity.y == 0)
        {
            rigidbody.AddForce(move * speed * Time.deltaTime, ForceMode.VelocityChange);
        }
        else
        {
            rigidbody.AddForce(move * airSpeed * Time.deltaTime, ForceMode.VelocityChange);
        }
        //</z ekseninde hareket>

        //<zıplama>
        if (Input.GetButtonDown("Jump"))
        {
            rigidbody.velocity = Vector3.up * jumpVelocity;    
        }

        if (rigidbody.velocity.y < 0)
        {
            rigidbody.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rigidbody.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rigidbody.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
        //</zıplama>
        //<karakter yönü>
        if (z> 0) { turnRot = Vector3.forward; } else if(z < 0) { turnRot = Vector3.back; }
        if (isInterracting == false) { rigidbody.MoveRotation(Quaternion.LookRotation(turnRot)); }
        
        //</karakter yönü>

        if (Input.GetKey(KeyCode.E))
        {
            speed = 10;
            isInterracting = true;
        }
        else
        {
            speed = 20;
            isInterracting = false;
        }
    }
}
