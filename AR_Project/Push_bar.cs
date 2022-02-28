using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push_bar : MonoBehaviour
{
    public Transform move_position;
    Vector3 origin_position;
    bool push;
    bool push_back;
    bool push_return;

    float speed = 4.0f;

    void Start()
    {
        origin_position = gameObject.transform.position;
        push = true;
        push_back = false;
        push_return = false;
    }

    IEnumerator Push_bool()
    {
        yield return new WaitForSeconds(2.5f);
        push_back = true;
        push = false;
    }

    IEnumerator Back_push_bool()
    {
        yield return new WaitForSeconds(2.5f);
        push = true;
        push_back = false;
    }
    void Update()
    {
        if (push)
        {
            gameObject.transform.position += move_position.transform.forward * Time.deltaTime * this.speed;
            StartCoroutine(Push_bool());
        }

        else if (push_back)
        {
            gameObject.transform.position -= move_position.transform.forward * Time.deltaTime * this.speed;
            StartCoroutine(Back_push_bool());
        }
    }
}
