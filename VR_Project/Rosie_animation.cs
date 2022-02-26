using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rosie_animation : MonoBehaviour
{
    public Animator rosie;
    // Start is called before the first frame update

    private void OnEnable()
    {
        gameObject.SetActive(true);
        rosie.Play("Base Layer.Armature|Hug", 0, 0.10f);
    }
}
