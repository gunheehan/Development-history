using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taeyeop_reset : MonoBehaviour
{
    public GameObject GFX;
    public GameObject Handle;

    private Quaternion GFX_local_original;
    private Quaternion Handle_local_original;
    private Quaternion GFX_world_original;
    private Quaternion Handle_world_original;

    private void OnEnable()
    {
        GFX.SetActive(true);
        Handle.SetActive(true);

        if (GFX.transform.localEulerAngles != Vector3.zero)
            GFX.transform.localEulerAngles = Vector3.zero;
        if (Handle.transform.localEulerAngles != Vector3.zero)
            Handle.transform.localEulerAngles = Vector3.zero;
    }
}
