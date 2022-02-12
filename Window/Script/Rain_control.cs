using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain_control : MonoBehaviour
{
    public GameObject rain_Prefab; // 오브젝트들이 저장되어 있는 최상위 오브젝트
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(itsrain());
    }

    IEnumerator itsrain()
    {
        if(rain_Prefab.activeSelf == false) // 오브젝트의 상태가 꺼져있을 경우
        {
            rain_Prefab.SetActive(true);
        }    
        else
        {
            rain_Prefab.SetActive(false); // 오브젝트가 켜져있을 경우 끄기
            StartCoroutine(itsrain()); // 비 내리기 실행
        }

        yield return new WaitForSeconds(5.0f); // 5초 간 비내리기 실행
        rain_Prefab.SetActive(false); // 비내리기 중지
        yield return new WaitForSeconds(3.0f); // 3초 간 대기
        StartCoroutine(itsrain()); // 비내리기 다시 실행(반복)
    }
}
