using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force : MonoBehaviour
{
    public AudioSource pushSound;
    public float pushForce = 2.0f;
    public float speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        pushForce = this.gameObject.GetComponentInChildren<Movement>().speed;
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log(gameObject.name + " has collided with " + hit.gameObject.name);
        Rigidbody rb = hit.collider.attachedRigidbody;
        
        Debug.Log("Player Speed: " + pushForce);

        if (rb == null || rb.isKinematic)
        {
            return;
        }

        if (rb != null)
        {
            Vector3 pushDirection = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
            rb.velocity = pushDirection * pushForce * 0.5f;
            
            //Vector3 pushDirection = hit.transform.position - transform.position;
            //pushDirection.y = 0;

            //rb.AddForce(pushDirection.normalized * pushForce, ForceMode.Impulse);
            
        }
    }
}
