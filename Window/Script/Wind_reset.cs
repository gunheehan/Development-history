using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind_reset : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wind")
            other.gameObject.SetActive(false);
    }
}
