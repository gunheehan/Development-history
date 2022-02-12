using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_coillder_control : MonoBehaviour
{
    public GameObject main_body;
    void wind_collider()
    {
        main_body.transform.position = new Vector3(main_body.transform.position.x-0.3f, main_body.transform.position.y, main_body.transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wind")
            wind_collider();
    }
}
