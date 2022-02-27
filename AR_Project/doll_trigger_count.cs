using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doll_trigger_count : MonoBehaviour
{
    public GameObject Robot;
    public GameObject Rosie;
    private int count = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "ROBOT_03" || other.gameObject.name == "Rosie_fixfix")
        {
            Robot.SetActive(true);
            Rosie.SetActive(true);
            StartCoroutine(off_setting());
        }
    }

    IEnumerator off_setting()
    {
        yield return new WaitForSeconds(5.0f);
        Robot.SetActive(false);
        Rosie.SetActive(false);
    }
}
