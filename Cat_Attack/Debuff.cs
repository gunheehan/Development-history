using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class Debuff : MonoBehaviour
{
    SmoothLocomotion Player_move; // �÷��̾� �̵��ӵ��� ����� ��ũ��Ʈ

    private void Start()
    {
        Player_move = GameObject.Find("PlayerController").GetComponent<SmoothLocomotion>();
        Player_move.enabled = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player") // ���ݿ� �¾����� ������ ȿ�� �߻�
        {
            StartCoroutine(Slow_move());
        }
    }

    IEnumerator Slow_move() // 3�ʵ��� �ӵ��� 1�� ���ϵǴ� ȿ�� �߻�
    {
        Player_move.MovementSpeed = 1;
        yield return new WaitForSeconds(3.0f);
        Player_move.MovementSpeed = 5;
    }
}
