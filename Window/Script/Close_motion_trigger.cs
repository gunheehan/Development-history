using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close_motion_trigger : MonoBehaviour
{
    private Animator close_animation; // 애니메이션을 받아올 변수
    private int window_touch; // 충돌 횟수를 저장하기 위한 변수
    // Start is called before the first frame update
    void Start()
    {
        close_animation = GetComponent<Animator>();
        window_touch = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        print("충돌확인");
        if (other.tag == "Bullet")
        {
            print("총알 충돌확인");
            Destroy(other.gameObject);
            window_touch++;
            Select_Animator();
        }
    }
    void Select_Animator()
    {
        switch (window_touch)
        {
            case 1:
                close_animation.Play("Base Layer.Armature|Hit_01", 0, 0.25f);
                break;
            case 2:
                close_animation.Play("Base Layer.Armature|Hit_02", 0, 0.25f);
                break;
            case 3:
                close_animation.Play("Base Layer.Armature|Hit_03", 0, 0.25f);
                break;
            case 4:
                close_animation.Play("Base Layer.Armature|Hit_04", 0, 0.25f);
                break;
            case 5:
                close_animation.Play("Base Layer.Armature|Hit_05", 0, 0.25f);
                break;
            case 6:
                close_animation.Play("Base Layer.Armature|close_window", 0, 0.25f);
                break;
        }
    }
}
