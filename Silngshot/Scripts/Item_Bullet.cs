using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class Item_Bullet : MonoBehaviour
{
    //public Slingshot_bullet playerbullet;
    //public Bow_slingshot printbullet;
    private void OnTriggerEnter(Collider other)
    {
        print("�浹�ν�");
        if (other.tag == "Silngshot") // Player�� �浹�Ͽ��� ���
        {
            print("�÷��̾� �浹");
            // ź�� -���� ��� 10���� �߰�
            if (Slingshot_bullet.instance.bullet <= 0)
            {
                Slingshot_bullet.instance.bullet = 10;
            }
            // ź�� 0�� �̻��� ��� ��ź +10
            else if (Slingshot_bullet.instance.bullet > 0)
            {
                print("ź ����");
                Slingshot_bullet.instance.bullet += 10;
            }
            Destroy(gameObject);

        }

    }
}
