using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Release_Parent : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        print("�浹");
        other.transform.parent = null;
    }
}
