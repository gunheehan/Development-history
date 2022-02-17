using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push_bar : MonoBehaviour
{
    Vector3 origin_position;
    bool push;
    bool push_back;
    float speed = 4f;
    // Start is called before the first frame update
    void Start()
    {
        origin_position = gameObject.transform.position;
        push = false;
        push_back = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            push = true;

        if(push)
        {
            if(gameObject.transform.position.x < 11f)
                gameObject.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            else
            {
                push_back = true;
                push = false;
            }
        }
        if(push_back)
        {
            if (gameObject.transform.position.x > 0f)
                gameObject.transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
            else
            {
                gameObject.transform.position = origin_position;
                push_back = false;
            }
        }
            
    }
}
