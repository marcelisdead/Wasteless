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
            var scanned = collision.gameObject.GetComponent<Scannable>();
            if (scanned == null)
                return;

            if (scanned.isScanned)
            {
                collision.transform.position = ScanningMachine.Instance.respawnPos.position;
            }
            else
            {
                collision.transform.position = ScanningMachine.Instance.startPos.position;
            }
            collision.collider.attachedRigidbody.velocity = Vector3.zero;
            collision.collider.attachedRigidbody.angularVelocity = Vector3.zero;

            // Reset the position of the Product to the respawn position
            //collision.transform.position = respawnPosition.position;
        }

    }
}
