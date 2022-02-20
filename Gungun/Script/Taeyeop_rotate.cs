using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taeyeop_rotate : MonoBehaviour
{
    public GameObject taeyeop_main;
    public GameObject taeyeop_body;
    public GameObject Handle;
    public GameObject my;
    //public GameObject reset;
    public Transform SnapGraphics;

    public Quaternion origin_rotation;
    public Quaternion finish_rotation;
    private Quaternion GFX_local_original;

    private void Start()
    {
        GFX_local_original = my.transform.localRotation;
    }
    private void OnEnable()
    {
        gameObject.transform.localEulerAngles = Vector3.zero;
    }
    // Update is called once per frame
    void Update()
    {
        //Vector3 v = gameObject.transform.rotation.ToEulerAngles();
        //print(v);
        if (my.transform.localRotation.eulerAngles.y >= 180)
        {
            //Handle.SetActive(false);
            my.transform.localRotation = GFX_local_original;
            taeyeop_body.SetActive(true);
            //reset.SetActive(true);
            //my.transform.localEulerAngles = new Vector3(my.transform.localEulerAngles.x, 0, my.transform.localEulerAngles.z);
            //SnapGraphics.localEulerAngles = new Vector3(SnapGraphics.localEulerAngles.x, 0, SnapGraphics.localEulerAngles.z);
            gameObject.transform.localEulerAngles = Vector3.zero;
            SnapGraphics.localEulerAngles = Vector3.zero;
            Handle.SetActive(false);
            taeyeop_main.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
