using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind_warnning : MonoBehaviour
{
    MeshRenderer wind_render;
    bool isIncrease;
    float speed = 1;

    void OnEnable()
    {
        wind_render = GetComponent<MeshRenderer>();
        Warnning_Enable(); //Blink �ѱ�
        isIncrease = true;
        Material m = wind_render.material; // Blink ����� �� ���͸��� �� ����
        m.color = new Color(0, m.color.g, m.color.b, m.color.a); // Color �ʱⰪ ����
        //StartCoroutine(Disable_time());
    }

    public void Warnning_Enable()
    {
        wind_render.enabled = true; // ������ �Ѽ� Blink ����
    }

    public void Warning_Disable()
    {
        wind_render.enabled = false; // ������ �Ѽ� Blink ����
        StartCoroutine(Dis_GameObject());
    }
    IEnumerator Dis_GameObject()
    {
        yield return new WaitForSeconds(1.0f);
        gameObject.SetActive(false);
    }
    IEnumerator Disable_time()
    {
        yield return new WaitForSeconds(5.0f);
        Warning_Disable();
    }
    void Update()
    {
        Material m = wind_render.material;

        if (isIncrease) // alpha ���� ������
        {
            // alpha ���� 0.04���� speed ����ŭ�� �ӵ��� Ŀ��
            m.color = Color.Lerp(m.color, new Color(0.7f , m.color.g, m.color.b, m.color.a), Time.deltaTime * speed);
            // ���� aplha���� 0.039���� ũ�ٸ� ���� ��Ŵ
            if (m.color.a > 0.69f) isIncrease = false;
        }
        else          // alpha ���� ������
        {
            // alpha ���� 0���� speed ����ŭ�� �ӵ��� �۾���
            m.color = Color.Lerp(m.color, new Color(0f, m.color.g, m.color.b, m.color.a), Time.deltaTime * speed);
            // ���� aplha���� 0.004���� �۴ٸ� ���� ��Ŵ
            if (m.color.a < 0.004f) isIncrease = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            print("��ٶ� ����ġ�� �㿡~");
    }
}
