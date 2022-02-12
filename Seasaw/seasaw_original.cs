using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seasaw_original : MonoBehaviour
{
    [Header("Sub Mission clear Object")]
    public GameObject original; // ������ ������ ������Ʈ
    MeshRenderer _render; // �����Ÿ� ����
    [Header("Cpilder Tag Name")]
    public string seasaw_item; // �浹�� tag name

    bool isIncrease;
    [Header("Blink Speed")]
    public float speed = 1f;

    void Awake()
    {
        original.SetActive(false); // ������ ���� ������ ���α�(���� Sub Event�� ���� ����)
        _render = GetComponent<MeshRenderer>();
    }

    void OnEnable()
    {
        Offseasaw(); //Blink ����
        isIncrease = true;
        Material m = _render.material; // Blink ����� �� ���͸��� �� ����
        m.color = new Color(m.color.r, m.color.g, m.color.b, 255f); // Color �ʱⰪ ����
    }

    public void Onseasaw()
    {
        _render.enabled = true; // ������ �Ѽ� Blink ����
    }
    
    public void Offseasaw()
    {
        _render.enabled = false; // ������ �Ѽ� Blink ����
    }

    void Update()
    {
        Material m = _render.material;

        if (isIncrease) // alpha ���� ������
        {
            // alpha ���� 0.04���� speed ����ŭ�� �ӵ��� Ŀ��
            m.color = Color.Lerp(m.color, new Color(m.color.r, m.color.g, m.color.b, 0.3f), Time.deltaTime * speed);
            //print(m.color.a);
            // ���� aplha���� 0.039���� ũ�ٸ� ���� ��Ŵ
            if (m.color.a > 0.29f) isIncrease = false;
        }
        else          // alpha ���� ������
        {
            // alpha ���� 0���� speed ����ŭ�� �ӵ��� �۾���
            m.color = Color.Lerp(m.color, new Color(m.color.r, m.color.g, m.color.b, 0f), Time.deltaTime * speed);
            //print(m.color.a);
            // ���� aplha���� 0.004���� �۴ٸ� ���� ��Ŵ
            if (m.color.a < 0.004f) isIncrease = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag==seasaw_item) // Seasaw item�� �浹�Ͽ��� ��� ����
        {
            gameObject.SetActive(false); // �ڱ��ڽ��� ����
            original.SetActive(true); // ������ ��ǰ Ű��
        }
    }
}
