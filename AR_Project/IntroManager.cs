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
            // alpha ������ ���� �̹����� ���İ� ����
            float alpha = logoImg.color.a;

            // �Ǽ��� ������ Lerp �Լ�.
            // alpha���� 1���� logoSpeed �ӵ��� �ε巴�� ���ĸ� �÷���.
            alpha = Mathf.Lerp(alpha, 1, Time.deltaTime * introSpeed);

            // ���� alpha�� 0.98���� ũ�� 1�� �����Ͽ� while�� ����
            if (alpha > 0.98f) alpha = 1;

            logoImg.color = new Color(1, 1, 1, alpha);

            // �������� ���������� �纸
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
