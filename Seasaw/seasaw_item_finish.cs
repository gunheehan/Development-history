using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seasaw_item_finish : MonoBehaviour
{
    [Header("Coilder Tag Name")]
    public string keytag; // ���� �̼��� Ű ��ũ��

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag==keytag) // �浿�� ������Ʈ�� Ű���� ���� �̼��� Ű���� ��ġ�� ��
        {
            gameObject.SetActive(false); // ���� ������Ʈ ��Ȱ��ȭ
        }
    }
}
