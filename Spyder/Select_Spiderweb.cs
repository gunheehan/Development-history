using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select_Spiderweb : MonoBehaviour
{
    [Header("Rain Object(Add Collider, Particle)")]
    public GameObject[] webs; // 비 영역이 저장된 변수
    public GameObject[] webs_warnning; // 위험 지역 표식이 저장된 변수
    // Start is called before the first frame update
    /*void OnEnable() // 켜지면 비내리기 시작
    {
        select_rain();
    }
    void OnDisable() // 꺼졌을 때 하위 오브젝트들 비활성화
    {
        foreach (GameObject o in rains) o.SetActive(false); // 모든 바람 비활성화
    }
    void select_rain() // 비 내리는 위치 선택
    {
        int active_rain = Random.Range(0, rains.Length - 1); // 0 ~ winds-1 사이의 랜덤 변수 지정
        for (int i = 0; i <= active_rain; i++) // 활성화할 개수만큼 실행
        {
            int play_rain = Random.Range(0, rains.Length); // 활성화할 바람 영역 선택
            if (rains[play_rain].activeSelf == false) // 현 상태가 false일 경우
                rains[play_rain].SetActive(true); // true로 변환
            else
                i--; // 현 상태가 true일 경우 반복문 1회 재실행
        }
    }*/

    void OnEnable()
    {
        StartCoroutine(selecte());
    }
    void OnDisable()
    {
        foreach (GameObject o in webs) o.SetActive(false); // 모든 바람 비활성화
    }
    // 바람 선택
    IEnumerator selecte()
    {
        int active_wind = Random.Range(0, webs.Length - 5); // 0 ~ winds-5 사이의 랜덤 변수 지정
        for (int i = 0; i <= active_wind; i++) // 활성화할 개수만큼 실행
        {
            int play_wind = Random.Range(0, webs.Length); // 활성화할 바람 영역 선택

            if (webs[play_wind].activeSelf == false) // 현 상태가 false일 경우
                webs[play_wind].SetActive(true); // true로 변환
            else
                i--; // 현 상태가 true일 경우 반복문 1회 재실행
        }
        yield return new WaitForSeconds(2.0f);
        for (int i = 0; i < webs_warnning.Length; i++) // 활성화할 개수만큼 실행
        {
            if (webs[i].activeSelf == true) // 현 상태가 true일 경우
                webs_warnning[i].SetActive(true); // true로 변환
        }
        foreach (GameObject o in webs) o.SetActive(false); // 모든 바람 비활성화
        yield return new WaitForSeconds(5.0f); // 5초간 대기
        foreach (GameObject o in webs_warnning) o.SetActive(false); // 모든 위험표시 비활성화
        StartCoroutine(selecte()); // 자신을 다시 호출
    }
}