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
    [Tooltip("�Ź� �ֻ��� ������Ʈ")]
    public GameObject Spyder_body; // Object main body

    [Header("Player Controller")]
    [Tooltip("�Ź̰� ���� Ÿ�� ��ġ")]
    public Transform target;


    [Header("Rotation Speed")]
    [Tooltip("�Ź̰� Ÿ���� �ٶ󺸱� ���� ���� �ӵ�")]
    public float r_speed = 0.1f;
    [Header("Move Speed")]
    [Tooltip("�Ź̰� Ÿ������ �̵��ϴ� �ӵ�")]
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
            print("�����");
            walking = true;
        }
    }

    /*private void OnTriggerExit(Collider other)
    {
        if(other.tag=="Player")
        {
            print("���̼���");
            walking = false;
        }
    }*/
}
