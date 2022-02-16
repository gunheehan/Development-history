using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

namespace cat
{
    public class Cat_leg_position : MonoBehaviour
    {
        [Header("Cat Modern Attack")]
        [Tooltip("cat main object")]
        public GameObject mordern_cat_face;
        [Tooltip("cat arm main object")]
        public GameObject mordern_cat_arm;
        [Tooltip("arm -> smoke")]
        public GameObject mordern_hit_event;
        [Tooltip("cat main object animator")]
        public Animator attack_modern_face;
        [Tooltip("cat arm object animator")]
        public Animator attack_modern_arm;
        [Tooltip("cat arm attack collider zone")]
        public Collider attack_modern_zone;


        [Header("Cat Angry Attack")]
        [Tooltip("cat main object")]
        public GameObject angry_cat_face;
        [Tooltip("cat arm main object")]
        public GameObject angry_cat_arm;
        [Tooltip("arm -> smoke")]
        public GameObject angry_hit_event;
        [Tooltip("cat main object animator")]
        public Animator attack_angry_face;
        [Tooltip("cat arm object animator")]
        public Animator attack_angry_arm;
        [Tooltip("cat arm attack collider zone")]
        public Collider attack_angry_zone;

        [HideInInspector]
        public int item_attack_count;

        [Header("Cat Attack Item")] // 큰 타격을 줄 오브젝트
        [Tooltip("cat main attack object. move auto")]
        public GameObject[] drop_attack_item;

        [Header("Drop Item Prefab")] // 잡아서 던질 수 있는 오브젝트
        [Tooltip("Grabble item object")]
        public GameObject[] Drop_Prefab; // 생성할 오브젝트 리스트

        [Header("Max Instantiate Legth")]
        [Tooltip("Grab Item Instantiate Setting")]
        public int max_intantiate = 25;
        [Tooltip("Grab Item Instantiate Area. ex) Box Collider")]
        public BoxCollider area; // 생성될 위치 범위
        private int count; // 생성할 오브젝트 개수

        [HideInInspector]
        public int damage_count;

        [Header("Misson Clear After Off List")]
        [Tooltip("Misson clear after Disable Object List")]
        public GameObject[] Off_List;

        private List<GameObject> create_item = new List<GameObject>();

        PlayerTeleport Teleport; // 텔러포트 기능을 정지할 스크립트
        SmoothLocomotion Player_move; // 플레이어 움직임 디버프 효과를 줄 스크립트

        // Start is called before the first frame update
        void Start()
        {
            item_attack_count = 0; // 큰 타격을 줄 오브젝트의 타격 횟수 저장
            damage_count = 0; // 고양이가 공격당한 횟수 카운트

            mordern_cat_face.SetActive(true);
            mordern_cat_arm.SetActive(true);
            mordern_hit_event.SetActive(false);
            attack_modern_face.enabled = false;
            attack_modern_arm.enabled = false;
            attack_modern_zone.enabled = false;


            angry_cat_face.SetActive(false);
            angry_cat_arm.SetActive(false);
            angry_hit_event.SetActive(false);
            attack_angry_face.enabled = false;
            attack_angry_arm.enabled = false;
            attack_angry_zone.enabled = false;


            Teleport = GameObject.Find("PlayerController").GetComponent<PlayerTeleport>();
            Player_move = GameObject.Find("PlayerController").GetComponent<SmoothLocomotion>();
            Player_move.enabled = true;
            Teleport.enabled = false;
            Drop();
            StartCoroutine(attack_ready());
        }

        IEnumerator attack_ready()
        {
            if (damage_count < 3) // 일반 공격
            {
                angry_cat_face.SetActive(false);
                angry_cat_arm.SetActive(false);
                mordern_cat_face.SetActive(true);
                mordern_cat_arm.SetActive(true);
                Attack_Point(mordern_cat_face, mordern_cat_arm);
                yield return new WaitForSeconds(1f);
                Attack_Modern_face();
                yield return new WaitForSeconds(3f);
                Attack_Modern_arm();
                yield return new WaitForSeconds(0.5f);
                attack_modern_zone.enabled = true;
                yield return new WaitForSeconds(0.3f);
                mordern_hit_event.SetActive(true);
                attack_item_move(10f);
                yield return new WaitForSeconds(2f);
                mordern_hit_event.SetActive(false);
                attack_modern_face.enabled = false;
                attack_modern_arm.enabled = false;
                attack_modern_zone.enabled = false;
            }
            else if (damage_count >= 3) // 강력한 공격
            {
                mordern_cat_face.SetActive(false);
                mordern_cat_arm.SetActive(false);
                angry_cat_face.SetActive(true);
                angry_cat_arm.SetActive(true);
                Attack_Point(angry_cat_face, angry_cat_arm);
                yield return new WaitForSeconds(1f);
                Attack_Angry_face();
                yield return new WaitForSeconds(2f);
                Attack_Angry_arm();
                yield return new WaitForSeconds(0.5f);
                attack_modern_zone.enabled = true;
                yield return new WaitForSeconds(0.8f);
                angry_hit_event.SetActive(true);
                attack_item_move(30f);
                yield return new WaitForSeconds(3f);
                angry_hit_event.SetActive(false);
                attack_angry_face.enabled = false;
                attack_angry_arm.enabled = false;
                attack_angry_zone.enabled = false;
                damage_count = 0;
                Drop();
            }

            if (item_attack_count >= 3)
            {
                mordern_cat_face.SetActive(false);
                angry_cat_face.SetActive(true);
                Attack_Angry_face();
                yield return new WaitForSeconds(2f);
                Misson_Clear();
            }

            print(item_attack_count);


            StartCoroutine(attack_ready());
        }

        void Attack_Point(GameObject body, GameObject arm)
        {
            int random_point = Random.Range(2, 8) * 10;
            Vector3 cat_body_point = body.transform.position;
            Vector3 cat_arm_point = arm.transform.position;
            body.transform.position = new Vector3(random_point-20, cat_body_point.y, cat_body_point.z);
            arm.transform.position = new Vector3(random_point, cat_arm_point.y, cat_arm_point.z);
        }

        void Attack_Modern_face()
        {
            attack_modern_face.enabled = true;
            attack_modern_face.Play("Base Layer.Armature_001|faceattackbefore", 0, 0.25f);
        }
        void Attack_Modern_arm()
        {
            attack_modern_arm.enabled = true;
            attack_modern_arm.Play("Base Layer.Armature|ArmatureAction_001", 0, 0.25f);
        }

        void Attack_Angry_face()
        {
            attack_angry_face.enabled = true;
            attack_angry_face.Play("Base Layer.Catattack_before|faceattackafter01", 0, 0.25f);
        }
        void Attack_Angry_arm()
        {
            attack_angry_arm.enabled = true;
            attack_angry_arm.Play("Base Layer.Armature|ArmatureAction_002", 0, 0.25f);
        }

        void attack_item_move(float move)
        {
            foreach (GameObject o in drop_attack_item)
            {
                o.transform.position = new Vector3(o.transform.position.x, o.transform.position.y, (Mathf.Lerp(o.transform.position.z, transform.position.z - move, Time.deltaTime * 10f)));
            }
        }

        void Drop()
        {
            area.enabled = true;

            count = Random.Range(15, max_intantiate);
            for(int i = 0; i < count; ++i)
            {
                Spawn();
            }
            area.enabled = false;
        }

        void Spawn()
        {
            int selection = Random.Range(0, Drop_Prefab.Length);

            GameObject selectedPrefab = Drop_Prefab[selection];

            Vector3 spawnPos = GetRandomPosition();

            GameObject instance = Instantiate(selectedPrefab, spawnPos, Quaternion.identity); // 오브젝트를 생성(동적할당)
            create_item.Add(instance);
        }

        private Vector3 GetRandomPosition()
        {
            Vector3 basePosition = area.transform.position;
            Vector3 size = area.size;

            float posX = basePosition.x + Random.Range(-size.x / 2f, size.x / 2f);
            float posY = basePosition.y + Random.Range(-size.y / 2f, size.y / 2f);
            float posZ = basePosition.z + Random.Range(-size.z / 2f, size.z / 2f);

            Vector3 spawnPos = new Vector3(posX, posY, posZ);

            return spawnPos;
        }

        void Misson_Clear()
        {
            foreach (GameObject list in Off_List)
                Destroy(list.gameObject);
        }     
    }
}
