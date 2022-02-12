using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auto_drop : MonoBehaviour
{
    // Drop시킬 프리팹과 스크립트를 포함하고 있는 오브잭트
    [Header("Drop Item Package Object")]
    public GameObject itemDrop;

    // 드랍을 반복 실행할 간격
    [Header("Drop Routine Time")]
    public float routine;

    void Start()
    {
        InvokeRepeating("Drop", 3f, routine); // Play 이후 3초뒤 5초간격으로 반복실행
    }

    void Drop() // 호출될때마다 한번씩 실행
    {
        itemDrop.SetActive(true);
        itemDrop.SetActive(false);
    }
}
