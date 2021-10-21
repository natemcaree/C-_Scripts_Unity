using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
 

    public float forwardForce = 2000f;
    public float sidewaysForce = 1000f;
    // Start is called before the first frame update
    // void Start()
    // {
    //     rb.AddForce(0, 200, 500);
    // }

    // We use FixedUpdate instead of Update because we are touching physics properties.
    void FixedUpdate()
    {
        //Add a forward force
        rb.AddForce(0, 0, forwardForce *Time.deltaTime); 

        if (Input.GetKey("d")){
            rb.AddForce(sidewaysForce*Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a")){
            rb.AddForce(-sidewaysForce*Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        
        if(rb.position.y <-1)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
