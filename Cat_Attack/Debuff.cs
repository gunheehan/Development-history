using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class Debuff : MonoBehaviour
{
    SmoothLocomotion Player_move; // 플레이어 이동속도가 저장된 스크립트

    private void Start()
    {
        Player_move = GameObject.Find("PlayerController").GetComponent<SmoothLocomotion>();
        Player_move.enabled = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player") // 공격에 맞았을시 디퍼프 효과 발생
        {
            StartCoroutine(Slow_move());
        }
    }

    IEnumerator Slow_move() // 3초동안 속도가 1로 저하되는 효과 발생
    {
        Player_move.MovementSpeed = 1;
        yield return new WaitForSeconds(3.0f);
        Player_move.MovementSpeed = 5;
    }
}
