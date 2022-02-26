using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_item_press : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Pencilcase" || other.gameObject.name == "FlowerPot_green" || other.gameObject.name == "clock")
        {
            other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, other.gameObject.transform.position.z - 5f);
        }
    }
}
