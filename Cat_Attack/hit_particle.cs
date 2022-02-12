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
        if (other.tag == "Cat")
            StartCoroutine(Start_particle());
    }
    
    IEnumerator Start_particle()
    {
        partSystem.enableEmission = true;
        yield return new WaitForSeconds(1.0f);
        partSystem.enableEmission = false;
        Destroy(gameObject);
    }
}
