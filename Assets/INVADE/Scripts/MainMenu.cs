using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject menu;       // 메뉴 전체 활성화/비활성화
    public GameObject help;       // 메뉴 전체 활성화/비활성화
    public GameObject setting;       // 메뉴 전체 활성화/비활성화

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
            if (setting.activeSelf || help.activeSelf)
            {
                theAudio.Play(button);
                setting.SetActive(false);
                help.SetActive(false);
            }
            else if (!setting.activeSelf)
            {
                OnMenuActive();
            }
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

    public void Exit()
    {
        Application.Quit();     // 겜 종료
    }

    public void OnSettingActive()
    {
        theAudio.Play(button);
        setting.SetActive(true);
    }

    public void OnSettingDisable()
    {
        theAudio.Play(button);
        setting.SetActive(false);
    }

    public void onHelpActive()
    {
        theAudio.Play(button);
        help.SetActive(true);
    }

    public void onHelpDisable()
    {
        theAudio.Play(button);
        help.SetActive(false);
    }
}
