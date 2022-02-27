using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_doll : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Doll_Destory(other));
    }

    IEnumerator Doll_Destory(Collider other)
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(other);
    }
}
