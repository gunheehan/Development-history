using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class play_animation : MonoBehaviour
{
    public Animator claw;
    bool push;
    bool duplicate;
    float speed = 4f;
    // Start is called before the first frame update
    void Start()
    {
        claw.Play("Base Layer.Armature|Stay", 0, 0.25f);
        push = true;
        duplicate = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (duplicate)
                push = true;
        }

        if (push)
        {
            duplicate = false;
            claw.Play("Base Layer.Armature|action", 0, 0.25f);
            push = false;
            duplicate = true;
        }
    }
}
