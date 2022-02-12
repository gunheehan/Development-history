using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class Silngshot : MonoBehaviour
{
    Rigidbody rb;
    Grabbable grab;
    public Collider ShaftCollider;
    public bool Flying = false;
    public float Zvel = 0;

    float flightTime = 0f;
    float destroyTime = 10f; // Time in seconds to destroy arrow
    Coroutine queueDestroy;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        grab = GetComponent<Grabbable>();
    }

    private void FixedUpdate()
    {
        bool beingHeld = grab != null && grab.BeingHeld;

        if (!beingHeld && rb != null && rb.velocity != Vector3.zero && Flying && Zvel > 0.02)
            rb.rotation = Quaternion.LookRotation(rb.velocity);
    }

    public void ShootArrow(Vector3 shotForce)
    {

        flightTime = 0f;
        Flying = true;

        transform.parent = null;

        rb.isKinematic = false;
        rb.useGravity = true;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        rb.constraints = RigidbodyConstraints.None;
        rb.AddForce(shotForce, ForceMode.VelocityChange);
        StartCoroutine(ReEnableCollider());
        queueDestroy = StartCoroutine(QueueDestroy());
    }

    IEnumerator QueueDestroy()
    {
        yield return new WaitForSeconds(destroyTime);

        if (grab != null && !grab.BeingHeld && transform.parent == null)
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator ReEnableCollider()
    {

        // Wait a few frames before re-enabling collider on bow shaft
        // This prevents the arrow from shooting ourselves, the bow, etc.
        // If you want the arrow to still have physics while attached,
        // parent a collider to the arrow near the tip
        int waitFrames = 3;
        for (int x = 0; x < waitFrames; x++)
        {
            yield return new WaitForFixedUpdate();
        }

        ShaftCollider.enabled = true;
    }
}
