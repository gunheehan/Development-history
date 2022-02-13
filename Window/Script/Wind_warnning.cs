using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind_warnning : MonoBehaviour
{
    MeshRenderer wind_render;
    bool isIncrease;
    float speed = 1;

    private void Awake()
    {
        wind_render = GetComponent<MeshRenderer>();
    }
    void OnEnable()
    {
        Warnning_Enable(); //Blink �ѱ�
        isIncrease = true;
        Material m = wind_render.material; // Blink ����� �� ���͸��� �� ����
        m.color = new Color(m.color.r, m.color.g, m.color.b, 0f); // Color �ʱⰪ ����
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
            m.color = Color.Lerp(m.color, new Color(m.color.r , m.color.g, m.color.b, 0.1f), Time.deltaTime * speed);
            // ���� aplha���� 0.039���� ũ�ٸ� ���� ��Ŵ
            if (m.color.a > 0.099f) isIncrease = false;
        }
        else          // alpha ���� ������
        {
            // alpha ���� 0���� speed ����ŭ�� �ӵ��� �۾���
            m.color = Color.Lerp(m.color, new Color(m.color.r, m.color.g, m.color.b, 0f), Time.deltaTime * speed);
            // ���� aplha���� 0.004���� �۴ٸ� ���� ��Ŵ
            if (m.color.a < 0.004f) isIncrease = true;
        }
    }
}
