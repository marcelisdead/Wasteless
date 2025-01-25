using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WasteHandler : MonoBehaviour
{
    void Start()
    {
        // Check if the object is at position (0, 0, 0)
        if (transform.position == Vector3.zero)
        {
            // Destroy the object
            Destroy(gameObject);
            // Optionally, wait for the next frame and respawn it at (1, 1, 1)
            Invoke("Respawn", 0.1f); // Small delay to ensure the object is destroyed first
        }
        else
        {
            // Respawn the object at position (1, 1, 1) immediately
            transform.position = new Vector3(1, 1, 1);
        }
    }

    void Respawn()
    {
        // Respawn the object at position (1, 1, 1)
        transform.position = new Vector3(1, 1, 1);
    }
}
