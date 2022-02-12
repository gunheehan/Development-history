using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seasaw_item : MonoBehaviour
{
    [Header("Next Misson Key")]
    public GameObject next_key; // 현재 Key event가 종료된 이후 실행될 오브젝트
    [Header("Coilder Tag Name")]
    public string keytag; // 현재 미션의 키 태크값

    void Start()
    {
        next_key.SetActive(false); // 다음 조각 오브젝트 비활성화
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag==keytag) // 충동한 오브젝트의 키값이 현재 미션의 키값과 일치할 시
        {
            gameObject.SetActive(false); // 현재 오브젝트 비활성화
            next_key.SetActive(true); // 다음 조각 오브젝트 활성화
        }
    }
}
