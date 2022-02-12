using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_Destory : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "silngshot_target")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
