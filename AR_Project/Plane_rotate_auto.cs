using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane_rotate_auto : MonoBehaviour
{
    float speed = 40f;

    private void Start()
    {
        gameObject.SetActive(true);
    }

    private void Update()
    {
        gameObject.transform.Rotate(0, -this.speed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Particle")
            other.transform.parent = gameObject.transform;
    }
}
