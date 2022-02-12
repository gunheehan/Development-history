using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select_wind : MonoBehaviour
{
    [Header("Wind Object(Add Collider)")]
    public GameObject[] winds; // 바람 영역이 저장된 변수
    public GameObject[] winds_warnning; // 위험 지역 표식이 저장된 변수
    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(selecte());
    }
    void OnDisable()
    {
        foreach (GameObject o in winds) o.SetActive(false); // 모든 바람 비활성화
    }
    // 바람 선택
    IEnumerator selecte()
    {
        int active_wind = Random.Range(0, winds_warnning.Length-5); // 0 ~ winds-5 사이의 랜덤 변수 지정
        for (int i = 0; i <= active_wind; i++) // 활성화할 개수만큼 실행
        {
            int play_wind = Random.Range(0, winds_warnning.Length); // 활성화할 바람 영역 선택

            if (winds_warnning[play_wind].activeSelf == false) // 현 상태가 false일 경우
                winds_warnning[play_wind].SetActive(true); // true로 변환
            else
                i--; // 현 상태가 true일 경우 반복문 1회 재실행
        }
        yield return new WaitForSeconds(5.0f);
        for (int i = 0; i < winds.Length; i++) // 활성화할 개수만큼 실행
        {
            if (winds_warnning[i].activeSelf == true) // 현 상태가 true일 경우
                winds[i].SetActive(true); // true로 변환
        }
        yield return new WaitForSeconds(7.0f); // 5초간 대기
        foreach (GameObject o in winds) o.SetActive(false); // 모든 바람 비활성화
        foreach (GameObject o in winds_warnning) o.SetActive(false); // 모든 위험표시 비활성화
        StartCoroutine(selecte()); // 자신을 다시 호출
    }
}
