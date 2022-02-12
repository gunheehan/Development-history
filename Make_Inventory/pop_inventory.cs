using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class pop_inventory : MonoBehaviour
{
    public GameObject inventory;

    public Collider input_zone;
    public MeshRenderer mesh;
    public InputBridge Button;

    // Start is called before the first frame update
    void Start()
    {
        inventory.SetActive(false);
        input_zone.enabled = false;
        mesh.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        check_input();
    }
    void check_input()
    {
        if(Button.AButton)
        {
            if (inventory.activeSelf == false)
                inventory.SetActive(true);
            else
                inventory.SetActive(false);
        }

        else if(Button.BButton)
        {
            // ������ ��Ʈ�ѷ� B��ư ��� ����
            print("B��ư ���");
        }

        else if(Button.XButton)
        {
            // ���� ��Ʈ�ѷ� X��ư ��� ����
            print("X��ư ���");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // �尩�� ���� �� �ִ� �������� �浹���� ���� ����
        if(other.tag == "Item")
        {
            StartCoroutine(Off_input_zone());
        }
    }

    IEnumerator Off_input_zone()
    {
        // �尩 �Թ����� �ִϸ��̼� ����
        yield return new WaitForSeconds(3.0f);
        input_zone.enabled = true;
        mesh.enabled = true;
        yield return new WaitForSeconds(3.0f);
        // �尩 �Դٹ��� �ִϸ��̼� ����
        input_zone.enabled = false;
        mesh.enabled = false;
    }
}
