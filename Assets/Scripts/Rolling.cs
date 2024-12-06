using UnityEngine;

public class Rolling : MonoBehaviour
{
    

    public Rigidbody rb;

    void Start()
    {
        
        rb = gameObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(0f, 0f, 500f);
        }

    }

    void Update()
    {
        // Calculate the rotation amount based on the rollSpeed and time
        //float rotationAmount = rollSpeed * Time.deltaTime;

        // Apply rotation around the central axis
       // rb.MoveRotation(rb.rotation * Quaternion.Euler(0f, rotationAmount, 0f));
       if(rb != null)
        {
            rb.AddForce(0f, 0f, 1000f);
        }
        
    }



}