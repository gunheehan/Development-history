using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class play_animation : MonoBehaviour
{
    public Animator claw;
    bool duplicate;
    float speed = 4f;

    void Start()
    {
        claw.Play("Base Layer.Armature|Stay", 0, 0.25f);
        duplicate = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (duplicate)
                StartCoroutine(Duplicate_timer());
        }
    }

    IEnumerator Duplicate_timer()
    {
        duplicate = false;
        claw.Play("Base Layer.Armature|action", 0, 0.25f);
        yield return new WaitForSeconds(5.0f);
        duplicate = true;
    }
}
