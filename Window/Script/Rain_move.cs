using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain_move : MonoBehaviour
{
    private Rigidbody rain_rigidbody;
    public Vector3 destination;
    private float rain_speed = 0.1f;

    // Start is called before the first frame update
    void OnEnable() // ������Ʈ Ȱ��ȭ��
    {
        rain_rigidbody = GetComponent<Rigidbody>(); // ���� ������Ʈ�� Rigidbody
        destination = rain_rigidbody.transform.position; // ������ ��ġ���� destination�� ����
    }

    void OnDisable() // ������Ʈ ��Ȱ��ȭ��
    {
        rain_rigidbody.transform.position = destination; // ���� ������Ʈ�� ��ġ���� �ʱ� Ȱ��ȭ ���� ��ġ ������ ����
    }
    void Update()
    {
        rain_rigidbody.transform.position = rain_rigidbody.transform.position + new Vector3(0, -rain_speed, 0); // Y ������ �̵�
    }

    private void OnCollisionStay(Collision collision) // �浹�� �߻��Ͽ��� ��
    {
        if (collision.other.tag != "Player") // Player�� �ƴ� ��� �ٶ� ��Ȱ��ȭ
        {
            rain_rigidbody.transform.position = destination; // Player�� �ƴ� ��ü�� �浹�� ��� �ٽ� ������
        }

        else if(collision.other.gameObject.tag == "Map")
        {
            rain_rigidbody.transform.position = destination; // ���� ������Ʈ�� ��ġ���� �ʱ� Ȱ��ȭ ���� ��ġ ������ ����
        }
    }
}
