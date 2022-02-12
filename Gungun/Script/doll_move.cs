using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doll_move : MonoBehaviour
{
    private float m_speed = 0.5f;
    private bool walking;
    public GameObject doll_body;
    public GameObject Hand_key;
    public GameObject Doll_key;
    public GameObject Taeyeop;
    public GameObject rotate_UI;
    public Animator move;

    // Start is called before the first frame update
    void OnEnable()
    {
        Quaternion me = doll_body.transform.rotation;
        StartCoroutine(Move_timer());
    }
    void Walk()
    {
        doll_body.transform.position += doll_body.transform.forward * Time.deltaTime * m_speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (walking)
            Walk();
    }

    IEnumerator Move_timer()
    {
        print("Timer Start");
        walking = true;
        rotate_UI.SetActive(false);
        move.Play("Base Layer.Armature|walking", 0, 0.25f);
        yield return new WaitForSeconds(4.0f);
        walking = false;
        rotate_UI.SetActive(true);
        Doll_key.SetActive(false);
        Hand_key.transform.position = new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,gameObject.transform.position.z-0.5f);
        Hand_key.SetActive(true);
        gameObject.SetActive(false);
        Taeyeop.SetActive(false);
        print("Timer End");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Plane")
        {
            walking = false;
        }
    }
}
