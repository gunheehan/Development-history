using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nyangnyang_Punch : MonoBehaviour
{
    public GameObject warnning_point; // 공격 위치를 저장할 변수
    public MeshRenderer warning; // 공격 위치에 반짝거림을 표현할 Render 변수
    public Transform attack_point; // 공격할 위치(현재 플레이어 위치)

    public Animation animation_normal_attack; // 일반 공격을 할 시의 애니메이션
    public Animation animation_super_attack; // 강력한 공격을 할 시의 애니메이션

    public GameObject[] items_prefab;
    public List<Transform> items_transform; // 아이템이 떨어질 위치들(추후 Random 함수로 무작위 아이템 떨구기) * 최소 5곳 이상으로 할 것
    List<Transform> duplication_transform; // 아이템을 떨굴 위치중 중복되는 위치
    List<GameObject> items; // 아이템의 개수만큼 실행

    private int drop_Item_count; // 떨어뜨릴 아이템 개수를 저장할 변수
    private int drop_position_count; // 떨어뜨릴 포인트 개수를 저장할 변수

    int nyang_punch_count; // 일반 공격 카운트
    void Enable()
    {
        StartCoroutine(Attack()); // 스크립트 시작시 반복실행
    }

    IEnumerator Attack()
    {
        warnning_point.transform.position = attack_point.position; // Player가 현재있는 위치를 공격 위치로 선정
        GameManager.instance.Object_Active(warnning_point, false); // 공격 포인트 위치에 위험 표식 실행
        EnviromentManager.instance.live_ColorChange(warning); // 주변 색상의 alpha 값이 변화
        yield return new WaitForSeconds(2.0f); // 2초 뒤에 다음 행동 실행
        GameManager.instance.Object_Active(warnning_point, true); // 공격 포인트 위치에 위험 표식 꺼짐
        StartAttack(); // 공격 실행
    }

    void StartAttack()
    {
        if(nyang_punch_count<=3) // 일반 공격시
        {
            animation_normal_attack.Play(); // 애니메이션이 실행되며 고양이 손에 있는 부분이 캐릭터와 충돌을 일으키면 데미지 효과
            DropItem(5, 3); // 최대 아이템 5개와 최대 3개의 포인트에서 아이템 Drop
        }
        else
        {
            animation_super_attack.Play(); // 강력한 공격시
            DropItem(10, 5); // 최대 아이템 10개와 최대 5개 포인트에서 아이템 Drop
            nyang_punch_count = 0; // 냥냥펀치 횟수 초기화
            // ☆ 히든 아이템 이동 구현 필요
        }
    }
    // 아이템을 떨구는 메소드
    void DropItem(int item_num, int position_num)
    {
        bool duplication = true; // 아이템이 떨어지는 구역 중복체크(한 위치에 반복실행 방지)
        drop_Item_count = Random.Range(0, item_num); // 처음 받아온 아이템 개수 중 떨어뜨릴 개수 초기화
        drop_position_count = Random.Range(0, position_num); // 처음 받아온 위치 중 떨어뜨릴 위치 수 초기화
        for(int i =0;i<=drop_position_count;i++)
        {
            int drop_position = Random.Range(0, items_transform.Count); // 가지고 있는 위치값 중에 현재 떨굴 위치를 선택
            duplication_transform.Add(items_transform[i]); // 현재 떨어뜨릴 위치를 중복 검사를 할 List에 추가
            for(int j = 0; j<=duplication_transform.Count;j++) // 중복 검사를 할 List의 길이 만큼 실행
            {
                if (items_transform[i] == duplication_transform[j]) // 현재 위치가 중복 검사에 걸리는지 확인
                {
                    duplication = false; // 중복될 시 false 반환
                    break; // 반복문 종료
                }
                else
                    duplication = true; // 중복이 되지 않을 시 true 반환
            }
            if (duplication) // 중복이 되지 않는 값일 시에 실행
            {
                DropItem_Active(drop_position); // 실제 떨어뜨리는 메소드 실행
            }
            else // 중복될 경우 다음 반복 실행
            {
                i--;
                continue;
            }
        }
        duplication_transform.Clear(); // 중복 검사를 할 List 초기화
    }
    // 해당 포지션 아이템 떨구기 실행
    void DropItem_Active(int drop_position)
    {
        int create_rutine_item = Random.Range(0, drop_Item_count); // 현재 반복에서 떨어뜨릴 아이템 개수 선택
        if (create_rutine_item != 0) // 떨어뜨릴 아이템이 0개가 아닐 경우에 실행
        {
            for (int i = 0; i <= create_rutine_item; i++) // 떨어뜨릴 횟수만큼 실행
            {
                GameObject selecteditem = items_prefab[Random.Range(0, items_prefab.Length)]; // 아이템이 저장되어 있는 배열중 Random으로 선택(여러개의 오브젝트중에 선텍)
                Instantiate(selecteditem, items_transform[drop_position].transform.position, Quaternion.identity); // 받아온 위치에 아이템을 생성
                // 한 포지션에 중복 생성됨으로 충돌이 이루어져서 떨어지는지 확인 필요. 하나로 뭉칠 가능성있음.
            }
            drop_Item_count -= create_rutine_item; // 떨어뜨린 아이템만큼 이후 루틴에서 떨어뜨릴 아이템 감소
        }
    }
    // 충돌 인식
    /*private void OnTriggerEnter(Collider other)
    {
        // 플레이어에 충돌할 경우 게임오버 실행
        if (other.tag == "Player")
            GameManager.instance.GameOver();
    }*/
}
