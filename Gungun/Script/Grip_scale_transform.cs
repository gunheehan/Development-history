using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class Grip_scale_transform : MonoBehaviour
{
    public InputBridge Button;

    bool trigger;
    Vector3 Origin_scale;
    Vector3 Finish_scale;
    float speed = 5.0f;

    void Start()
    {
        Origin_scale = transform.localScale;
        Finish_scale = new Vector3(0.5f, 0.5f, 0.5f);
        trigger = false;        
    }

    void Update()
    {

        if (trigger)
        {
            Scale_down();
        }

        else if (!trigger)
        {
            Scale_up();
        }
    }

    void Scale_down()
    {
        transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f) * Time.deltaTime * speed;
        if (transform.localScale.x <= Finish_scale.x)
        {
            transform.localScale = Finish_scale;
        }
    }

    void Scale_up()
    {
        transform.localScale += new Vector3(0.1f, 0.1f, 0.1f) * Time.deltaTime * speed;
        if (transform.localScale.x >= Origin_scale.x)
        {
            transform.localScale = Origin_scale;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (Button.RightGrip == 0 && transform.localScale != Origin_scale)
        {
            trigger = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (Button.RightGrip != 0 && other.tag == "Player")
        {
            trigger = true;
        }
    }
}
