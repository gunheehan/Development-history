using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadController : MonoBehaviour
{
    public float speed;
    public float length;
    public float dis;
    bool isActive = false;
    MeshRenderer mesh;

    public Transform rider;
    float distance;
    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // 1) �������� road ��ġ�� �Ÿ��� ���
        distance = Vector3.Distance(rider.position, transform.position);

        // 2) road�� �̵�
        transform.Translate(new Vector3(0, 0, speed * Time.deltaTime), Space.World);

        // 3) �������� road ��ġ�� �Ÿ��� ���� road�� ��ġ �ʱ�ȭ �Ǻ�
        if(distance<dis) // �̵�����
        {
            mesh.enabled = true;
            isActive = true;
        }
        else // �Ÿ��� �ʱ�ȭ�Ͽ� length��ŭ ������ �̵�
        {
            mesh.enabled = false;
            if(isActive)
            {
                isActive = false;
                transform.position -= new Vector3(0, 0, length);
            }
        }
    }
}
