using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nyangnyang_Punch : MonoBehaviour
{
    public GameObject warnning_point; // ���� ��ġ�� ������ ����
    public MeshRenderer warning; // ���� ��ġ�� ��¦�Ÿ��� ǥ���� Render ����
    public Transform attack_point; // ������ ��ġ(���� �÷��̾� ��ġ)

    public Animation animation_normal_attack; // �Ϲ� ������ �� ���� �ִϸ��̼�
    public Animation animation_super_attack; // ������ ������ �� ���� �ִϸ��̼�

    public GameObject[] items_prefab;
    public List<Transform> items_transform; // �������� ������ ��ġ��(���� Random �Լ��� ������ ������ ������) * �ּ� 5�� �̻����� �� ��
    List<Transform> duplication_transform; // �������� ���� ��ġ�� �ߺ��Ǵ� ��ġ
    List<GameObject> items; // �������� ������ŭ ����

    private int drop_Item_count; // ����߸� ������ ������ ������ ����
    private int drop_position_count; // ����߸� ����Ʈ ������ ������ ����

    int nyang_punch_count; // �Ϲ� ���� ī��Ʈ
    void Enable()
    {
        StartCoroutine(Attack()); // ��ũ��Ʈ ���۽� �ݺ�����
    }

    IEnumerator Attack()
    {
        warnning_point.transform.position = attack_point.position; // Player�� �����ִ� ��ġ�� ���� ��ġ�� ����
        GameManager.instance.Object_Active(warnning_point, false); // ���� ����Ʈ ��ġ�� ���� ǥ�� ����
        EnviromentManager.instance.live_ColorChange(warning); // �ֺ� ������ alpha ���� ��ȭ
        yield return new WaitForSeconds(2.0f); // 2�� �ڿ� ���� �ൿ ����
        GameManager.instance.Object_Active(warnning_point, true); // ���� ����Ʈ ��ġ�� ���� ǥ�� ����
        StartAttack(); // ���� ����
    }

    void StartAttack()
    {
        if(nyang_punch_count<=3) // �Ϲ� ���ݽ�
        {
            animation_normal_attack.Play(); // �ִϸ��̼��� ����Ǹ� ����� �տ� �ִ� �κ��� ĳ���Ϳ� �浹�� ����Ű�� ������ ȿ��
            DropItem(5, 3); // �ִ� ������ 5���� �ִ� 3���� ����Ʈ���� ������ Drop
        }
        else
        {
            animation_super_attack.Play(); // ������ ���ݽ�
            DropItem(10, 5); // �ִ� ������ 10���� �ִ� 5�� ����Ʈ���� ������ Drop
            nyang_punch_count = 0; // �ɳ���ġ Ƚ�� �ʱ�ȭ
            // �� ���� ������ �̵� ���� �ʿ�
        }
    }
    // �������� ������ �޼ҵ�
    void DropItem(int item_num, int position_num)
    {
        bool duplication = true; // �������� �������� ���� �ߺ�üũ(�� ��ġ�� �ݺ����� ����)
        drop_Item_count = Random.Range(0, item_num); // ó�� �޾ƿ� ������ ���� �� ����߸� ���� �ʱ�ȭ
        drop_position_count = Random.Range(0, position_num); // ó�� �޾ƿ� ��ġ �� ����߸� ��ġ �� �ʱ�ȭ
        for(int i =0;i<=drop_position_count;i++)
        {
            int drop_position = Random.Range(0, items_transform.Count); // ������ �ִ� ��ġ�� �߿� ���� ���� ��ġ�� ����
            duplication_transform.Add(items_transform[i]); // ���� ����߸� ��ġ�� �ߺ� �˻縦 �� List�� �߰�
            for(int j = 0; j<=duplication_transform.Count;j++) // �ߺ� �˻縦 �� List�� ���� ��ŭ ����
            {
                if (items_transform[i] == duplication_transform[j]) // ���� ��ġ�� �ߺ� �˻翡 �ɸ����� Ȯ��
                {
                    duplication = false; // �ߺ��� �� false ��ȯ
                    break; // �ݺ��� ����
                }
                else
                    duplication = true; // �ߺ��� ���� ���� �� true ��ȯ
            }
            if (duplication) // �ߺ��� ���� �ʴ� ���� �ÿ� ����
            {
                DropItem_Active(drop_position); // ���� ����߸��� �޼ҵ� ����
            }
            else // �ߺ��� ��� ���� �ݺ� ����
            {
                i--;
                continue;
            }
        }
        duplication_transform.Clear(); // �ߺ� �˻縦 �� List �ʱ�ȭ
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
    // �浹 �ν�
    /*private void OnTriggerEnter(Collider other)
    {
        // �÷��̾ �浹�� ��� ���ӿ��� ����
        if (other.tag == "Player")
            GameManager.instance.GameOver();
    }*/
}
