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
        Warnning_Enable(); //Blink 켜기
        isIncrease = true;
        Material m = rain_render.material; // Blink 기능을 할 메터리얼 값 연결
        m.color = new Color(m.color.r, m.color.g, m.color.b, 0f); // Color 초기값 설정
    }

    private void OnDisable()
    {
        player.MovementSpeed = debuff_speed;
        Warning_Disable();
    }

    public void Warnning_Enable()
    {
        rain_render.enabled = true; // 렌더를 켜서 Blink 실행
    }

    public void Warning_Disable()
    {
        rain_render.enabled = false; // 렌더를 켜서 Blink 끄기
    }
   
    void Update()
    {
        Material m = rain_render.material;

        if (isIncrease) // alpha 값이 증가중
        {
            // alpha 값이 0.04까지 speed 값만큼의 속도로 커짐
            m.color = Color.Lerp(m.color, new Color(m.color.r, m.color.g, m.color.b, 0.1f), Time.deltaTime * speed);
            // 만약 aplha값이 0.039보다 크다면 감소 시킴
            if (m.color.a > 0.099f) isIncrease = false;
        }
        else          // alpha 값이 감소중
        {
            // alpha 값이 0까지 speed 값만큼의 속도로 작아짐
            m.color = Color.Lerp(m.color, new Color(m.color.r, m.color.g, m.color.b, 0f), Time.deltaTime * speed);
            // 만약 aplha값이 0.004보다 작다면 증가 시킴
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
