using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taeyeop_rotate : MonoBehaviour
{
    public GameObject taeyeop_main;
    public GameObject taeyeop_body;
    public GameObject Handle;
    public GameObject my;
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

        if (my.transform.localRotation.eulerAngles.y >= 180)
        {
            my.transform.localRotation = GFX_local_original;
            taeyeop_body.SetActive(true);

            gameObject.transform.localEulerAngles = Vector3.zero;
            SnapGraphics.localEulerAngles = Vector3.zero;
            Handle.SetActive(false);
            taeyeop_main.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
