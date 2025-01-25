using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollisionHandler : MonoBehaviour

{
    // Set the respawn position for the Product (you can change this to whatever position you want)
    public Transform respawnPosition;

    // When the collision happens
    void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object is tagged as "Product"
        if (collision.gameObject.CompareTag("Product"))
        {
            // Reset the position of the Product to the respawn position
            collision.transform.position = respawnPosition.position;
        }

    }
}
