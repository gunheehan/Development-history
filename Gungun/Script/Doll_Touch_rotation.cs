using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doll_Touch_rotation : MonoBehaviour
{
    public GameObject doll_body;
    public Animator stand;
    private float chage_rotate;

    private void Start()
    {
        stand.Play("Base Layer.Armature|Armature|mixamo_com|Help_stand", 0, 0.25f);    }

    public void right_rotate()
    {
        chage_rotate = doll_body.transform.rotation.eulerAngles.y + 10;
        doll_body.transform.rotation = Quaternion.Euler(new Vector3(doll_body.transform.rotation.x, chage_rotate, doll_body.transform.rotation.z));
    }

    public void left_rotate()
    {
        chage_rotate = doll_body.transform.rotation.eulerAngles.y - 10;
        doll_body.transform.rotation = Quaternion.Euler(new Vector3(doll_body.transform.rotation.x, chage_rotate, doll_body.transform.rotation.z));
    }
}
