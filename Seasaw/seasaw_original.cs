using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seasaw_original : MonoBehaviour
{
    [Header("Sub Mission clear Object")]
    public GameObject original; // 완전히 조립될 오브젝트
    MeshRenderer _render; // 깜빡거릴 렌더
    [Header("Cpilder Tag Name")]
    public string seasaw_item; // 충돌할 tag name

    bool isIncrease;
    [Header("Blink Speed")]
    public float speed = 1f;

    void Awake()
    {
        original.SetActive(false); // 마지막 조립 조각은 꺼두기(현재 Sub Event의 최종 조각)
        _render = GetComponent<MeshRenderer>();
    }

    void OnEnable()
    {
        Offseasaw(); //Blink 끄기
        isIncrease = true;
        Material m = _render.material; // Blink 기능을 할 메터리얼 값 연결
        m.color = new Color(m.color.r, m.color.g, m.color.b, 255f); // Color 초기값 설정
    }

    public void Onseasaw()
    {
        _render.enabled = true; // 렌더를 켜서 Blink 실행
    }
    
    public void Offseasaw()
    {
        _render.enabled = false; // 렌더를 켜서 Blink 끄기
    }

    void Update()
    {
        Material m = _render.material;

        if (isIncrease) // alpha 값이 증가중
        {
            // alpha 값이 0.04까지 speed 값만큼의 속도로 커짐
            m.color = Color.Lerp(m.color, new Color(m.color.r, m.color.g, m.color.b, 0.3f), Time.deltaTime * speed);
            //print(m.color.a);
            // 만약 aplha값이 0.039보다 크다면 감소 시킴
            if (m.color.a > 0.29f) isIncrease = false;
        }
        else          // alpha 값이 감소중
        {
            // alpha 값이 0까지 speed 값만큼의 속도로 작아짐
            m.color = Color.Lerp(m.color, new Color(m.color.r, m.color.g, m.color.b, 0f), Time.deltaTime * speed);
            //print(m.color.a);
            // 만약 aplha값이 0.004보다 작다면 증가 시킴
            if (m.color.a < 0.004f) isIncrease = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag==seasaw_item) // Seasaw item과 충돌하였을 경우 실행
        {
            gameObject.SetActive(false); // 자기자신을 끄기
            original.SetActive(true); // 조립될 부품 키기
        }
    }
}
