using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using spider;
using BNG;
public class Web_debuff : MonoBehaviour
{
    public Spyder_LookRotation spider_move;
    public SmoothLocomotion player_move;
    private void OnTriggerEnter(Collider other)
    {
        //spider_move.m_speed = 5f;
        //player_move.MovementSpeed = 2.5f;
        //if (other.tag == "player")
        if(other.tag != "Untagged" && other.tag != "UI Trigger")
        {
            if (other.tag == "Player")
            {
                print("충돌시작 : " + other.tag);
                spider_move.m_speed = 5f;
                player_move.MovementSpeed = 2.5f;
            }
        }
    }

    private void OnDisable()
    {
        spider_move.m_speed = 2f;
        player_move.MovementSpeed = 5f;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Untagged" && other.tag != "UI Trigger")
        {
            if (other.tag == "Player")
            {
                print("충돌종료 : " + other.tag);
                spider_move.m_speed = 2f;
                player_move.MovementSpeed = 5f;
            }
        }
    }
}
