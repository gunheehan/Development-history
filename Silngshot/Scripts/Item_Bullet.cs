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
        print("충돌인식");
        if (other.tag == "Silngshot") // Player과 충돌하였을 경우
        {
            print("플레이어 충돌");
            // 탄이 -개인 경우 10개만 추가
            if (Slingshot_bullet.instance.bullet <= 0)
            {
                Slingshot_bullet.instance.bullet = 10;
            }
            // 탄이 0개 이상인 경우 잔탄 +10
            else if (Slingshot_bullet.instance.bullet > 0)
            {
                print("탄 참조");
                Slingshot_bullet.instance.bullet += 10;
            }
            Destroy(gameObject);

        }

    }
}
