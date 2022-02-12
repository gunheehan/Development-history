using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select_wind : MonoBehaviour
{
    [Header("Wind Object(Add Collider)")]
    public GameObject[] winds; // �ٶ� ������ ����� ����
    public GameObject[] winds_warnning; // ���� ���� ǥ���� ����� ����
    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(selecte());
    }
    void OnDisable()
    {
        foreach (GameObject o in winds) o.SetActive(false); // ��� �ٶ� ��Ȱ��ȭ
    }
    // �ٶ� ����
    IEnumerator selecte()
    {
        int active_wind = Random.Range(0, winds_warnning.Length-5); // 0 ~ winds-5 ������ ���� ���� ����
        for (int i = 0; i <= active_wind; i++) // Ȱ��ȭ�� ������ŭ ����
        {
            int play_wind = Random.Range(0, winds_warnning.Length); // Ȱ��ȭ�� �ٶ� ���� ����

            if (winds_warnning[play_wind].activeSelf == false) // �� ���°� false�� ���
                winds_warnning[play_wind].SetActive(true); // true�� ��ȯ
            else
                i--; // �� ���°� true�� ��� �ݺ��� 1ȸ �����
        }
        yield return new WaitForSeconds(5.0f);
        for (int i = 0; i < winds.Length; i++) // Ȱ��ȭ�� ������ŭ ����
        {
            if (winds_warnning[i].activeSelf == true) // �� ���°� true�� ���
                winds[i].SetActive(true); // true�� ��ȯ
        }
        yield return new WaitForSeconds(7.0f); // 5�ʰ� ���
        foreach (GameObject o in winds) o.SetActive(false); // ��� �ٶ� ��Ȱ��ȭ
        foreach (GameObject o in winds_warnning) o.SetActive(false); // ��� ����ǥ�� ��Ȱ��ȭ
        StartCoroutine(selecte()); // �ڽ��� �ٽ� ȣ��
    }
}
