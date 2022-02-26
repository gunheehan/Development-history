using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Newt_animation : MonoBehaviour
{
    public Animator newt;
    // Start is called before the first frame update

    private void OnEnable()
    {
        gameObject.SetActive(true);
        newt.Play("Base Layer.Newt_hug", 0, 0.25f);
    }
}
