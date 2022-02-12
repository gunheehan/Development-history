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
            // 오른쪽 컨트롤러 B버튼 기능 기재
            print("B버튼 기능");
        }

        else if(Button.XButton)
        {
            // 왼쪽 컨트롤러 X버튼 기능 기재
            print("X버튼 기능");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // 장갑에 넣을 수 있는 아이템이 충돌했을 때만 실행
        if(other.tag == "Item")
        {
            StartCoroutine(Off_input_zone());
        }
    }

    IEnumerator Off_input_zone()
    {
        // 장갑 입벌리는 애니메이션 실행
        yield return new WaitForSeconds(3.0f);
        input_zone.enabled = true;
        mesh.enabled = true;
        yield return new WaitForSeconds(3.0f);
        // 장갑 입다무는 애니메이션 실행
        input_zone.enabled = false;
        mesh.enabled = false;
    }
}
