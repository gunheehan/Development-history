using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class Rain_warnning : MonoBehaviour
{
    public SmoothLocomotion player;
    MeshRenderer rain_render;
    bool isIncrease;
    float speed = 1;
    float debuff_speed;
    float origin_speed;

    private void Awake()
    {
        rain_render = GetComponent<MeshRenderer>();
        origin_speed = player.MovementSpeed;
        debuff_speed = player.MovementSpeed / 2;
    }
    void OnEnable()
    {
        Warnning_Enable(); //Blink �ѱ�
        isIncrease = true;
        Material m = rain_render.material; // Blink ����� �� ���͸��� �� ����
        m.color = new Color(m.color.r, m.color.g, m.color.b, 0f); // Color �ʱⰪ ����
    }

    private void OnDisable()
    {
        player.MovementSpeed = debuff_speed;
        Warning_Disable();
    }

    public void Warnning_Enable()
    {
        rain_render.enabled = true; // ������ �Ѽ� Blink ����
    }

    public void Warning_Disable()
    {
        rain_render.enabled = false; // ������ �Ѽ� Blink ����
    }
   
    void Update()
    {
        Material m = rain_render.material;

        if (isIncrease) // alpha ���� ������
        {
            // alpha ���� 0.04���� speed ����ŭ�� �ӵ��� Ŀ��
            m.color = Color.Lerp(m.color, new Color(m.color.r, m.color.g, m.color.b, 0.1f), Time.deltaTime * speed);
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine(Rain_Debuff());
        }
    }

    IEnumerator Rain_Debuff()
    {
        player.MovementSpeed = debuff_speed;
        yield return new WaitForSeconds(3.0f);
        player.MovementSpeed = origin_speed;
    }
}
