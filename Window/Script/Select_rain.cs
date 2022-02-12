using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select_rain : MonoBehaviour
{
    [Header("Rain Object(Add Collider, Particle)")]
    public GameObject[] rains; // �� ������ ����� ����
    public GameObject[] rains_warnning; // ���� ���� ǥ���� ����� ����
    // Start is called before the first frame update
    /*void OnEnable() // ������ �񳻸��� ����
    {
        select_rain();
    }
    void OnDisable() // ������ �� ���� ������Ʈ�� ��Ȱ��ȭ
    {
        foreach (GameObject o in rains) o.SetActive(false); // ��� �ٶ� ��Ȱ��ȭ
    }
    void select_rain() // �� ������ ��ġ ����
    {
        int active_rain = Random.Range(0, rains.Length - 1); // 0 ~ winds-1 ������ ���� ���� ����
        for (int i = 0; i <= active_rain; i++) // Ȱ��ȭ�� ������ŭ ����
        {
            int play_rain = Random.Range(0, rains.Length); // Ȱ��ȭ�� �ٶ� ���� ����
            if (rains[play_rain].activeSelf == false) // �� ���°� false�� ���
                rains[play_rain].SetActive(true); // true�� ��ȯ
            else
                i--; // �� ���°� true�� ��� �ݺ��� 1ȸ �����
        }
    }*/

    void OnEnable()
    {
        StartCoroutine(selecte());
    }
    void OnDisable()
    {
        foreach (GameObject o in rains) o.SetActive(false); // ��� �ٶ� ��Ȱ��ȭ
    }
    // �ٶ� ����
    IEnumerator selecte()
    {
        int active_wind = Random.Range(0, rains_warnning.Length - 5); // 0 ~ winds-5 ������ ���� ���� ����
        for (int i = 0; i <= active_wind; i++) // Ȱ��ȭ�� ������ŭ ����
        {
            int play_wind = Random.Range(0, rains_warnning.Length); // Ȱ��ȭ�� �ٶ� ���� ����

            if (rains_warnning[play_wind].activeSelf == false) // �� ���°� false�� ���
                rains_warnning[play_wind].SetActive(true); // true�� ��ȯ
            else
                i--; // �� ���°� true�� ��� �ݺ��� 1ȸ �����
        }
        yield return new WaitForSeconds(2.0f);
        for (int i = 0; i < rains.Length; i++) // Ȱ��ȭ�� ������ŭ ����
        {
            if (rains_warnning[i].activeSelf == true) // �� ���°� true�� ���
                rains[i].SetActive(true); // true�� ��ȯ
        }
        yield return new WaitForSeconds(5.0f); // 5�ʰ� ���
        foreach (GameObject o in rains) o.SetActive(false); // ��� �ٶ� ��Ȱ��ȭ
        foreach (GameObject o in rains_warnning) o.SetActive(false); // ��� ����ǥ�� ��Ȱ��ȭ
        StartCoroutine(selecte()); // �ڽ��� �ٽ� ȣ��
    }
}