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
        Warnning_Enable(); //Blink 켜기
        isIncrease = true;
        Material m = wind_render.material; // Blink 기능을 할 메터리얼 값 연결
        m.color = new Color(0, m.color.g, m.color.b, m.color.a); // Color 초기값 설정
        //StartCoroutine(Disable_time());
    }

    public void Warnning_Enable()
    {
        wind_render.enabled = true; // 렌더를 켜서 Blink 실행
    }

    public void Warning_Disable()
    {
        wind_render.enabled = false; // 렌더를 켜서 Blink 끄기
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

        if (isIncrease) // alpha 값이 증가중
        {
            // alpha 값이 0.04까지 speed 값만큼의 속도로 커짐
            m.color = Color.Lerp(m.color, new Color(0.7f , m.color.g, m.color.b, m.color.a), Time.deltaTime * speed);
            // 만약 aplha값이 0.039보다 크다면 감소 시킴
            if (m.color.a > 0.69f) isIncrease = false;
        }
        else          // alpha 값이 감소중
        {
            // alpha 값이 0까지 speed 값만큼의 속도로 작아짐
            m.color = Color.Lerp(m.color, new Color(0f, m.color.g, m.color.b, m.color.a), Time.deltaTime * speed);
            // 만약 aplha값이 0.004보다 작다면 증가 시킴
            if (m.color.a < 0.004f) isIncrease = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            print("비바람 몰아치는 밤에~");
    }
}
