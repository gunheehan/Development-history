using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seasaw_item : MonoBehaviour
{
    [Header("Next Misson Key")]
    public GameObject next_key; // ���� Key event�� ����� ���� ����� ������Ʈ
    [Header("Coilder Tag Name")]
    public string keytag; // ���� �̼��� Ű ��ũ��

    void Start()
    {
        next_key.SetActive(false); // ���� ���� ������Ʈ ��Ȱ��ȭ
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag==keytag) // �浿�� ������Ʈ�� Ű���� ���� �̼��� Ű���� ��ġ�� ��
        {
            gameObject.SetActive(false); // ���� ������Ʈ ��Ȱ��ȭ
            next_key.SetActive(true); // ���� ���� ������Ʈ Ȱ��ȭ
        }
    }
}
