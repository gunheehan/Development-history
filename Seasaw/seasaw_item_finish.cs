using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seasaw_item_finish : MonoBehaviour
{
    [Header("Coilder Tag Name")]
    public string keytag; // 현재 미션의 키 태크값

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag==keytag) // 충동한 오브젝트의 키값이 현재 미션의 키값과 일치할 시
        {
            gameObject.SetActive(false); // 현재 오브젝트 비활성화
        }
    }
}
