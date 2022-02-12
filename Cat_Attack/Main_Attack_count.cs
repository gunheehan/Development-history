using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cat;

public class Main_Attack_count : MonoBehaviour
{
    Cat_leg_position main_attack;
    // Start is called before the first frame update
    void Start()
    {
        main_attack = GameObject.Find("Cat_Mission").GetComponent<Cat_leg_position>();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Attack_item")
        {
            main_attack.item_attack_count++;
        }
    }
}
