using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit_particle : MonoBehaviour
{
    private ParticleSystem partSystem;

    void Start()
    {
        partSystem = gameObject.GetComponent<ParticleSystem>();
        partSystem.enableEmission = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        print("충돌감지");
        if (other.tag == "Respawn")
            StartCoroutine(Start_particle());
    }

    IEnumerator Start_particle()
    {
        print("리스폰 충돌");
        partSystem.enableEmission = true;
        yield return new WaitForSeconds(2.0f);
        partSystem.enableEmission = false;
    }
}
