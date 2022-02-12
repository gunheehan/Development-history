using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonEvent : MonoBehaviour
{
    public IEnumerator inputModuleOnClickEvent()
    {
        GetComponent<Button>().interactable = false;

        yield return new WaitForSeconds(1.0f);

        GetComponent<Button>().interactable = true;
    }
}
