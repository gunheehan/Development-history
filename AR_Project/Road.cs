using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    Transform[] roads;
    void Awake()
    {
        // ��� �ڽ� ������Ʈ�� Transform�� �����´�.
         roads = GetComponentsInChildren<Transform>();
    }

    void Start()
    {
        Disable();
    }

    public void Enable()
    {
        foreach (Transform child in roads)
        {
            child.gameObject.SetActive(true);
        }
    }

    public void Disable()
    {
        foreach (Transform child in roads)
        {
            child.gameObject.SetActive(false);
        }
    }
}
