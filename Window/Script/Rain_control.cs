using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain_control : MonoBehaviour
{
    public GameObject rain_Prefab; // ������Ʈ���� ����Ǿ� �ִ� �ֻ��� ������Ʈ
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(itsrain());
    }

    IEnumerator itsrain()
    {
        if(rain_Prefab.activeSelf == false) // ������Ʈ�� ���°� �������� ���
        {
            rain_Prefab.SetActive(true);
        }    
        else
        {
            rain_Prefab.SetActive(false); // ������Ʈ�� �������� ��� ����
            StartCoroutine(itsrain()); // �� ������ ����
        }

        yield return new WaitForSeconds(5.0f); // 5�� �� �񳻸��� ����
        rain_Prefab.SetActive(false); // �񳻸��� ����
        yield return new WaitForSeconds(3.0f); // 3�� �� ���
        StartCoroutine(itsrain()); // �񳻸��� �ٽ� ����(�ݺ�)
    }
}
