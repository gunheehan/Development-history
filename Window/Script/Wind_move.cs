using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind_move : MonoBehaviour
{
    public GameObject player;
    private Rigidbody wind_rigidbody;
    public Vector3 destination;
    private float wind_speed = 0.03f;

    bool triggerStart = false;

    // Start is called before the first frame update
    void OnEnable() // ������Ʈ Ȱ��ȭ��
    {
        wind_rigidbody = GetComponent<Rigidbody>(); // ���� ������Ʈ�� Rigidbody
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        destination = wind_rigidbody.transform.position; // ������ ��ġ���� destination�� ����
    }

    void OnDisable() // ������Ʈ ��Ȱ��ȭ��
    {
        wind_rigidbody.transform.position = destination; // ���� ������Ʈ�� ��ġ���� �ʱ� Ȱ��ȭ ���� ��ġ ������ ����
    }
    // Update is called once per frame
    void Update()
    {
        wind_rigidbody.transform.position = wind_rigidbody.transform.position + new Vector3(-wind_speed,0,0); // X ������ �̵�

        //if(triggerStart)
          //  player.transform.position = new Vector3(-wind_speed * Time.deltaTime, player.transform.position.y, player.transform.position.z);
    }

    private void OnCollisionStay(Collision collision) // �浹�� �߻��Ͽ��� ��
    {
        if (collision.other.tag == "Player") // Player�� �ƴ� ��� �ٶ� ��Ȱ��ȭ
        {
            //OnDisable();
            //gameObject.SetActive(false); // ������Ʈ ��Ȱ��ȭ
            print("�÷��̾� �浹!");
            triggerStart = true;
        }
    }
}
