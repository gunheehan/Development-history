using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cat;

public class attact_count : MonoBehaviour
{
   private Cat_leg_position count;
    private void Start()
    {
        count = GameObject.Find("Cat_Mission").GetComponent<Cat_leg_position>();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cat_Attack_small")
        {
            Destroy(other.gameObject);
            count.damage_count++;
            print("body damage : " + count.damage_count);
        }
    }
}
