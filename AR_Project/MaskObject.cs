using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (Material m in GetComponent<MeshRenderer>().materials)
            m.renderQueue = 3002;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
