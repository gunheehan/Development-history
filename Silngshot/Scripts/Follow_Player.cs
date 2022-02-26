using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Player : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerController");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x - gameObject.transform.position.x > 5 || gameObject.transform.position.x - player.transform.position.x > 5)
        {
            gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z);
        }

        else if(player.transform.position.y - gameObject.transform.position.y > 5 || gameObject.transform.position.y - player.transform.position.y > 5)
        {
            gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z);
        }

        else if(player.transform.position.z - gameObject.transform.position.z > 5 || gameObject.transform.position.z  - player.transform.position.z > 5)
        {
            gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z);
        }
    }
}
