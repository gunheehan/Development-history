using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace spider
{
    public class Spyder_LookRotation : MonoBehaviour
    {
        Vector3 relativerPosition;
        Quaternion playerRotation;

        public GameObject Spyder_body;
        public Transform target;
        public Animator Spyder;
        public GameObject[] eyes;
        public Random_position reset_position;
        public GameObject Player;

        private int eyes_attack = 0;
        public float r_speed = 0.1f;
        public float m_speed;

        bool rotating = false;
        bool walking = false;

        float wait;
        float rotationTime;

        void Start()
        {
            foreach (GameObject black_eyes in eyes)
                black_eyes.SetActive(false);
        }

        private void OnEnable()
        {
            wait = Random.Range(0, 5);
            rotationTime = 0;
            rotating = true;
            Spyder.Play("Spyder.IdleLookAroundNormal", 0, 1f);
            StartCoroutine(Wait_time());
        }

        IEnumerator Wait_time()
        {
            yield return new WaitForSeconds(0);
            Spyder.speed = 0.5f;
            StartCoroutine(rotate_delay());
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            relativerPosition = target.position - Spyder_body.transform.position;
            playerRotation = Quaternion.LookRotation(relativerPosition);
            if (rotating)
            {
                rotationTime += Time.deltaTime * r_speed;
                Spyder_body.transform.rotation = Quaternion.Lerp(Spyder_body.transform.rotation, playerRotation, rotationTime);
            }

            /*if (rotationTime > 1)
            {
                rotating = false;
            }*/

            if (walking)
            {
                Spyder_body.transform.position += Spyder_body.transform.forward * Time.deltaTime * m_speed;
                //print(Spyder_body.transform.position + "  " + Time.deltaTime * m_speed + "  " + m_speed + "  " + walking);
            }
            //print(walking);
                //Walk();
        }

        void Walk()
        {
            Spyder_body.transform.position += Spyder_body.transform.forward * Time.deltaTime * m_speed;
            //print(Spyder_body.transform.position + "  " + Time.deltaTime*m_speed + "  " + m_speed + "  " + walking);
        }

        void Check_Input()
        {
            StartCoroutine(Move_timer());
        }

        IEnumerator rotate_delay()
        {
            yield return new WaitForSeconds(1f);
            Check_Input();
        }

        IEnumerator Move_timer()
        {
            Spyder.StopPlayback();
            walking = true;
            Spyder.Play("Spyder.CrawlNormal", 0, 1f);
            yield return new WaitForSeconds(9.0f);
            Spyder.StopPlayback();
        }

        private void OnTriggerEnter(Collider other)
        {
            //print("애니메이션 충돌지점 : " + other.name);
            if (other.tag == "Player")
            {
                walking = false;
                Spyder.StopPlayback();
                Spyder.Play("Spyder.ThrowSpiderWebThreat", 0, 0.25f);
                StartCoroutine(Spider_Attack());
            }

            else if (other.tag == "Bullet")
            {
                if (eyes_attack <= eyes.Length)
                {
                    Spyder.Play("Spyder.DeathNormal", 0, 0.25f);
                    eyes[eyes_attack].SetActive(true);
                    eyes_attack++;
                    StartCoroutine(spider_hit());
                }
            }
        }

        IEnumerator Spider_Attack()
        {
            yield return new WaitForSeconds(2.0f);
            Spyder.StopPlayback();
            Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z + 3);
            reset_position.Spyder_position();
        }

        IEnumerator spider_hit()
        {
            yield return new WaitForSeconds(2.0f);
            walking = false;
            if (eyes_attack >= eyes.Length)
                Destroy(Spyder_body);
            reset_position.Spyder_position();
        }
    }
}