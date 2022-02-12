using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taeyeop_rotate : MonoBehaviour
{
    public GameObject taeyeop_main;
    public GameObject taeyeop_body;
    public GameObject Handle;
    public GameObject my;

    public Quaternion origin_rotation;
    public Quaternion finish_rotation;
    private Quaternion GFX_local_original;

    private void Start()
    {
        GFX_local_original = my.transform.localRotation;
    }
    // Update is called once per frame
    void Update()
    {
        //Vector3 v = gameObject.transform.rotation.ToEulerAngles();
        //print(v);
        print("È¸Àü°ª : "  + my.transform.localRotation.eulerAngles.y);
        if (my.transform.localRotation.eulerAngles.y >= 180)
        {
            //Handle.SetActive(false);
            my.transform.localRotation = GFX_local_original;
            taeyeop_body.SetActive(true);
            taeyeop_main.SetActive(false);
        }
    }
}
