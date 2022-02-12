using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auto_drop : MonoBehaviour
{
    // Drop��ų �����հ� ��ũ��Ʈ�� �����ϰ� �ִ� ������Ʈ
    [Header("Drop Item Package Object")]
    public GameObject itemDrop;

    // ����� �ݺ� ������ ����
    [Header("Drop Routine Time")]
    public float routine;

    void Start()
    {
        InvokeRepeating("Drop", 3f, routine); // Play ���� 3�ʵ� 5�ʰ������� �ݺ�����
    }

    void Drop() // ȣ��ɶ����� �ѹ��� ����
    {
        itemDrop.SetActive(true);
        itemDrop.SetActive(false);
    }
}
