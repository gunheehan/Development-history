using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    Transform[] roads;
    void Awake()
    {
        // 모든 자식 오브젝트의 Transform을 가져온다.
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
