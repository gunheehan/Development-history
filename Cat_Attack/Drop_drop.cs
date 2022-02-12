using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop_drop : MonoBehaviour
{
    [Header("Drop Itam Prefab")]
    public GameObject[] prefabs; // 생성할 오브젝트 리스트
    [Header("Max Instantiate Lengh")]
    public int max_intantiate;
    private BoxCollider area;    // 생성될 위치범위
    private int count;      // 생성할 오브젝트 개수

    private List<GameObject> gameObject = new List<GameObject>();

    void OnEnable()
    {
        area = GetComponent<BoxCollider>(); // 아이템 생성 범위를 박스 콜라이더로 지정

        count = Random.Range(5, max_intantiate); // 5 ~ 받아온 개수안의 아이템 생성
        for (int i = 0; i < count; ++i) // 생성할 개수만큼 반복
        {
            Spawn(); //생성 + 스폰위치를 포함하는 함수
        }

        area.enabled = false;
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 basePosition = transform.position;
        Vector3 size = area.size;

        float posX = basePosition.x + Random.Range(-size.x / 2f, size.x / 2f);
        float posY = basePosition.y + Random.Range(-size.y / 2f, size.y / 2f);
        float posZ = basePosition.z + Random.Range(-size.z / 2f, size.z / 2f);

        Vector3 spawnPos = new Vector3(posX, posY, posZ);

        return spawnPos;
    }

    private void Spawn()
    {
        int selection = Random.Range(0, prefabs.Length); // 생성할 Prefab 선택

        GameObject selectedPrefab = prefabs[selection];

        Vector3 spawnPos = GetRandomPosition(); // 아이템이 생성될 랜덤 위치 지정

        GameObject instance = Instantiate(selectedPrefab, spawnPos, Quaternion.identity); // 오브젝트를 생성(동적할당)
        gameObject.Add(instance);
    }
}