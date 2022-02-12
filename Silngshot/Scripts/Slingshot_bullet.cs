using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BNG;

// ���� źȯ ��� ���� Ŭ����
public class Slingshot_bullet : MonoBehaviour
{
    private static Slingshot_bullet _instance;

    public static Slingshot_bullet instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Slingshot_bullet>();
            }

            return _instance;
        }
    }
    [HideInInspector]
    public int bullet;

    // Start is called before the first frame update
    void Start()
    {
        bullet = 100;
    }
}
