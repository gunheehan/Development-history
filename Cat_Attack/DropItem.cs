using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    public GameObject[] items_prefab;
    public List<Transform> items_transform; // �������� ������ ��ġ��(���� Random �Լ��� ������ ������ ������) * �ּ� 5�� �̻����� �� ��
    List<Transform> duplication_transform; // �������� ���� ��ġ�� �ߺ��Ǵ� ��ġ
    List<GameObject> items; // �������� ������ŭ ����

    private int drop_Item_count; // ����߸� ������ ������ ������ ����
    private int drop_position_count; // ����߸� ����Ʈ ������ ������ ����

    int nyang_punch_count; // �Ϲ� ���� ī��Ʈ
    void Enable()
    {
        Dropitem(5, 3);
    }
    // �������� ������ �޼ҵ�
    void Dropitem(int item_num, int position_num)
    {
        bool duplication = true; // �������� �������� ���� �ߺ�üũ(�� ��ġ�� �ݺ����� ����)
        drop_Item_count = Random.Range(0, item_num); // ó�� �޾ƿ� ������ ���� �� ����߸� ���� �ʱ�ȭ
        drop_position_count = Random.Range(0, position_num); // ó�� �޾ƿ� ��ġ �� ����߸� ��ġ �� �ʱ�ȭ
        for (int i = 0; i <= drop_position_count; i++)
        {
            int drop_position = Random.Range(0, items_transform.Count); // ������ �ִ� ��ġ�� �߿� ���� ���� ��ġ�� ����
            duplication_transform.Add(items_transform[i]); // ���� ����߸� ��ġ�� �ߺ� �˻縦 �� List�� �߰�
            if (duplication_transform.Contains(items_transform[i])) // ���� ��ġ�� �ߺ� �˻翡 �ɸ����� Ȯ��
            {
                i--;
                continue;
            }
            else
                DropItem_Active(drop_position); // ���� ����߸��� �޼ҵ� ����
        }
    }
    // �ش� ������ ������ ������ ����
    void DropItem_Active(int drop_position)
    {
        int create_rutine_item = Random.Range(0, drop_Item_count); // ���� �ݺ����� ����߸� ������ ���� ����
        if (create_rutine_item != 0) // ����߸� �������� 0���� �ƴ� ��쿡 ����
        {
            for (int i = 0; i <= create_rutine_item; i++) // ����߸� Ƚ����ŭ ����
            {
                GameObject selecteditem = items_prefab[Random.Range(0, items_prefab.Length)]; // �������� ����Ǿ� �ִ� �迭�� Random���� ����(�������� ������Ʈ�߿� ����)
                Instantiate(selecteditem, items_transform[drop_position].transform.position, Quaternion.identity); // �޾ƿ� ��ġ�� �������� ����
                // �� �����ǿ� �ߺ� ���������� �浹�� �̷������ ���������� Ȯ�� �ʿ�. �ϳ��� ��ĥ ���ɼ�����.
            }
            drop_Item_count -= create_rutine_item; // ����߸� �����۸�ŭ ���� ��ƾ���� ����߸� ������ ����
        }
    }
}
