using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push_bar : MonoBehaviour
{
    Vector3 origin_position;
    bool push;
    bool push_back;
    bool push_return;
    bool duplicate;
    float speed = 4f;
    // Start is called before the first frame update
    void Start()
    {
        origin_position = gameObject.transform.position;
        push = true;
        push_back = false;
        push_return = false;
        duplicate = true;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            if(duplicate)
                push = true;
        }*/

        if(push)
        {
            //duplicate = false;
            if(gameObject.transform.position.x < 13f)
                gameObject.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            else
            {
                push_back = true;
                push = false;
            }
        }

        else if(push_back)
        {
            if (gameObject.transform.position.x > -0.5f)
                gameObject.transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
            else
            {
                push_return = true;
                push_back = false;
            }
        }

        else if(push_return)
        {
            if (gameObject.transform.position.x < origin_position.x)
                gameObject.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            else
            {
                gameObject.transform.position = origin_position;
                push_return = false;
                push = true;
                //duplicate = true;
            }
        }
            
    }
}
