using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Release_Parent : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Particle")
            StartCoroutine(Wait_Time(other.gameObject));
    }

    IEnumerator Wait_Time(GameObject off)
    {
        yield return new WaitForSeconds(1.0f);
        off.transform.parent = null;
    }
}
