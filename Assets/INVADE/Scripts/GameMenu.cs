using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    public GameObject menu;       // 메뉴 전체 활성화/비활성화

    private bool activated;     // 활성화 됐는지 비활성화 됐는지

    public string button;
    private AudioManager theAudio;


    private void Start()
    {
        theAudio = FindObjectOfType<AudioManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnMenuActive();
        }
    }

    public void OnMenuActive()
    {
        theAudio.Play(button);
        activated = !activated;

        if (activated)
        {
            menu.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            menu.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void Continue()
    {
        theAudio.Play(button);
        activated = false;
        menu.SetActive(false);
        Time.timeScale = 1;
    }

    public void SceneChangeToGame()
    {
        theAudio.Play(button);
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1;
    }

    public void SceneChangeToMain()
    {
        theAudio.Play(button);
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1;

        // 게임매니저가 사라지면 오디오매니저를 파괴하면서 메인화면으로 갔을 때 중복을 방지
        if (AudioManager.instance != null)
        {
            AudioManager.instance.SetDestroy();
        }
    }

    public void Exit()
    {
        Application.Quit();     // 겜 종료
    }


    public void BackGroundMute(Toggle toggle)
    {
        theAudio.SetBackGroundMute(toggle.isOn);
    }

    public void EffectMute(Toggle toggle)
    {
        theAudio.SetEffectMute(toggle.isOn);
    }
}
