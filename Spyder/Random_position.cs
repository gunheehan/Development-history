using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace spider
{
    public class Random_position : MonoBehaviour
    {
        public GameObject spyder;
        public GameObject spider;
        public GameObject Player;
        public Transform[] transform_list;
        // Start is called before the first frame update
        void Start()
        {
            InvokeRepeating("Spyder_position", 1f, 30f);
        }

        public void Spyder_position()
        {
            spyder.SetActive(false);
            int position_num = Random.Range(0, transform_list.Length);
            spider.transform.position = transform_list[position_num].transform.position;
            print("거미 사라지기!");
            spyder.SetActive(true);
        }

        private void OnTriggerEnter(Collider other)
        {
            //print("충돌인식 : " + other.name);
            if (other.tag == "Player")
            {
                //print("플레이어 충돌");
                //spider.transform.position = new Vector3(spider.transform.position.x, spider.transform.position.y, spider.transform.position.z - 3);
                //Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z + 3);
            }
        }
    }
}