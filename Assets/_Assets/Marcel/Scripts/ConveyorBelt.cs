using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//moves any rigidbodies tagged "Product" across the attached collider in the direction of forwardTransforms forward
public class ConveyorBelt : MonoBehaviour
{
    public float speed = 2.0f;
	public bool isMoving = true;
	public Transform forwardTransform;
    public AudioSource beltSound;


    private void OnCollisionEnter(Collision col)
    {
        if (!isMoving || col.gameObject.tag != "Product")
            return;

        beltSound.Play();
    }

    private void OnCollisionExit(Collision col)
    {
        if (!isMoving || col.gameObject.tag != "Product")
            return;

        beltSound.Stop();
    }

    void OnCollisionStay(Collision col)
    {
        if (!isMoving || col.gameObject.tag != "Product")
            return;

        Debug.Log(col.gameObject.name + "collides");

        float conveyorPower = speed * Time.deltaTime;
        col.rigidbody.velocity = conveyorPower * forwardTransform.forward;
    }
}