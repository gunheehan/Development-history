using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Release_Parent : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag != "Particle")
            other.transform.parent = null;
    }
}
