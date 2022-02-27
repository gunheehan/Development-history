using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class biker : MonoBehaviour
{
    Animator bikeAnimator;
    int index;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        bikeAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // PC에서 마우스 왼쪽 클릭(모바일에서 터치)
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click");
            RunAnimation(index);
            index++;
            if (index > 3)
                index = 0;
        }
    }

    public void Enable()
    {
        
    }

    public void Disable()
    {
        
    }

    // index 번째 애니메이션을 호출(0 : Round, 1 : Up, 2 : Small_Drift, 3 : Large_Drift)
    public void RunAnimation(int index)
    {
        switch(index)
        {
            case 0:
                bikeAnimator.SetTrigger("Round");
                break;
            case 1:
                bikeAnimator.SetTrigger("Up");
                break;
            case 2:
                bikeAnimator.SetTrigger("Small_Drift");
                break;
            case 3:
                bikeAnimator.SetTrigger("Large_Drift");
                break;
        }
    }
}
