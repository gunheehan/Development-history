using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop_drop : MonoBehaviour
{
    [Header("Drop Itam Prefab")]
    public GameObject[] prefabs; // ������ ������Ʈ ����Ʈ
    [Header("Max Instantiate Lengh")]
    public int max_intantiate;
    private BoxCollider area;    // ������ ��ġ����
    private int count;      // ������ ������Ʈ ����

    private List<GameObject> gameObject = new List<GameObject>();

    void OnEnable()
    {
        area = GetComponent<BoxCollider>(); // ������ ���� ������ �ڽ� �ݶ��̴��� ����

        count = Random.Range(5, max_intantiate); // 5 ~ �޾ƿ� �������� ������ ����
        for (int i = 0; i < count; ++i) // ������ ������ŭ �ݺ�
        {
            Spawn(); //���� + ������ġ�� �����ϴ� �Լ�
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
        int selection = Random.Range(0, prefabs.Length); // ������ Prefab ����

        GameObject selectedPrefab = prefabs[selection];

        Vector3 spawnPos = GetRandomPosition(); // �������� ������ ���� ��ġ ����

        GameObject instance = Instantiate(selectedPrefab, spawnPos, Quaternion.identity); // ������Ʈ�� ����(�����Ҵ�)
        gameObject.Add(instance);
    }
}