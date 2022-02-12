using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taeyeop_reset : MonoBehaviour
{
    public GameObject Taeyeop;
    public GameObject GFX;
    public GameObject Handle;

    private Quaternion GFX_local_original;
    private Quaternion Handle_local_original;
    private Quaternion GFX_world_original;
    private Quaternion Handle_world_original;
    private void Start()
    {
        GFX_local_original = GFX.transform.localRotation;
        Handle_local_original = Handle.transform.localRotation;

        //GFX_world_original = GFX.transform.rotation;
        //Handle_world_original = Handle.transform.rotation;
    }

    private void Update()
    {
        if(Taeyeop.activeSelf == false)
        {
            GFX.transform.localRotation = GFX_local_original;
            GFX.SetActive(true);
        }

        if(Handle.activeSelf == false)
        {
            Handle.transform.localRotation = Handle_local_original;
            Handle.SetActive(true);
        }

    }

    private void OnDisable()
    {

        //GFX.transform.rotation = Quaternion.Euler(0, 0, 0);
        //Handle.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
