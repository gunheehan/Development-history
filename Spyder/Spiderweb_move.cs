using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spiderweb_move : MonoBehaviour
{
    
    private Rigidbody web_rigidbody;
    public Vector3 destination;
    private float web_speed = 15f;
    bool drop;

    // Start is called before the first frame update
    void OnEnable() // ������Ʈ Ȱ��ȭ��
    {
        //web_rigidbody = GetComponent<Rigidbody>(); // ���� ������Ʈ�� Rigidbody
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        destination = gameObject.transform.position; // ������ ��ġ���� destination�� ����
        drop = true;
    }

    void OnDisable() // ������Ʈ ��Ȱ��ȭ��
    {
        gameObject.transform.position = destination; // ���� ������Ʈ�� ��ġ���� �ʱ� Ȱ��ȭ ���� ��ġ ������ ����
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }
    void Update()
    {
        if(drop)
            gameObject.transform.position = gameObject.transform.position + new Vector3(0, Time.deltaTime*-web_speed, 0); // Y ������ �̵�
    }

    private void OnCollisionEnter(Collision collision) // �浹�� �߻��Ͽ��� ��
    {
        if (collision.other.tag == "Plane") // Player�� �ƴ� ��� �ٶ� ��Ȱ��ȭ
        {
            //web_rigidbody.transform.position = destination; // Player�� �ƴ� ��ü�� �浹�� ��� �ٽ� ������
            drop = false;
            gameObject.SetActive(false);
        }

        /*else if(collision.other.gameObject.tag == "Map")
        {
            web_rigidbody.transform.position = destination; // ���� ������Ʈ�� ��ġ���� �ʱ� Ȱ��ȭ ���� ��ġ ������ ����
        }*/
    }
}
