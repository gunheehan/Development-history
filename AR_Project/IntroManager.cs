using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class IntroManager : MonoBehaviour
{
    public Image logoImg;
    public VideoPlayer logoVideo;
    public AudioSource audioSource;

    public float introSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        //logoImg.color = new Color(1, 1, 1, 0);
        //StartCoroutine(ImgIntro());
        StartCoroutine(VideoIntro());
    }

    IEnumerator ImgIntro()
    {
        while(logoImg.color.a<1)
        {
            // alpha 변수에 현재 이미지의 알파값 저장
            float alpha = logoImg.color.a;

            // 실수값 형대의 Lerp 함수.
            // alpha부터 1까지 logoSpeed 속도로 부드럽게 알파를 올려줌.
            alpha = Mathf.Lerp(alpha, 1, Time.deltaTime * introSpeed);

            // 만약 alpha가 0.98보다 크면 1로 변경하여 while문 종료
            if (alpha > 0.98f) alpha = 1;

            logoImg.color = new Color(1, 1, 1, alpha);

            // 프레임이 끝날때까지 양보
            yield return new WaitForEndOfFrame();
        }

        audioSource.Play();

        yield return new WaitForSeconds(3.0f);

        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    IEnumerator VideoIntro()
    {
        logoVideo.Play();
        yield return new WaitForSeconds(5.0f);
        logoVideo.Pause();
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

}
