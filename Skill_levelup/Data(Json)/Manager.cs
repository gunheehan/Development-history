using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance; 
    static Managers Instance { get { init(); return s_instance; } }

    DataManager _data = new DataManager();
    ResourceManager _resource = new ResourceManager();

    public static DataManager Data { get { return Instance._data; } }
    public static ResourceManager Resourse { get { return Instance._resource; } }
    private void Start()
    {
        init();
    }

    static void init()
    {
        if(s_instance==null)
        {
            GameObject go = GameObject.Find("@Manager");
            if(go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }

            DontDestroyOnLoad(go);
            s_instance = go.GetComponent<Managers>();

            s_instance._data.init();
        }
    }

    public static void Clear()
    {

    }
}
