using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class Web_rope : MonoBehaviour
{
    Vector3 relativerPosition;
    Quaternion playerRotation;

    [Header("Player")]
    [Tooltip("Player")]
    public Rigidbody Player;
    public InputBridge Player_Input;

    [Header("Spider Setting")]
    [Tooltip("거미 최상위 오브젝트")]
    public GameObject Spyder_body; // Object main body

    [Header("Player Controller")]
    [Tooltip("거미가 따라갈 타켓 위치")]
    public Transform target;


    [Header("Rotation Speed")]
    [Tooltip("거미가 타켓을 바라보기 위해 도는 속도")]
    public float r_speed = 0.1f;
    [Header("Move Speed")]
    [Tooltip("거미가 타켓으로 이동하는 속도")]
    public float m_speed;

    bool rotating = false;
    bool walking = false;

    float rotationTime;


    private void OnEnable()
    {
        rotationTime = 0;
        m_speed = 7f;
        rotating = true;
    }

    void FixedUpdate()
    {
        relativerPosition = target.position - Spyder_body.transform.position;
        playerRotation = Quaternion.LookRotation(relativerPosition);
        if (rotating)
        {
            rotationTime += Time.deltaTime * r_speed;
            Spyder_body.transform.rotation = Quaternion.Lerp(Spyder_body.transform.rotation, playerRotation, rotationTime);
        }

        if (walking)
        {
            Spyder_body.transform.position += Spyder_body.transform.forward * Time.deltaTime * m_speed;
            Player.transform.position = new Vector3(Spyder_body.transform.position.x, Spyder_body.transform.position.y-1.5f,Spyder_body.transform.position.z);
        }
        if (Input.GetKeyDown("space"))
            walking = true;

        //if (Player_Input.RightGrip != 0)
            //walking = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.tag);
        if (other.tag == "Web" || Player_Input.RightGrip < 1f && walking)
        {
            walking = false;
            gameObject.SetActive(false);
        }
        else if (Player_Input.RightGrip == 1 && other.tag == "Player")
        {
            print("가즈아");
            walking = true;
        }
    }

    /*private void OnTriggerExit(Collider other)
    {
        if(other.tag=="Player")
        {
            print("에이설마");
            walking = false;
        }
    }*/
}
