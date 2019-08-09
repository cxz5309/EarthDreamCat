using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainManager : MonoBehaviour
{
    public GameObject menu;       // 메뉴 전체 활성화/비활성화
    public GameObject help;       // 메뉴 전체 활성화/비활성화
    public GameObject setting;       // 메뉴 전체 활성화/비활성화
    public GameObject worldMap;        // 월드맵
    public GameObject gameStart;

    public Text stageText;
    public Text highScore;
    public Text highCombo;

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
            theAudio.Play(button);

            if (gameStart.activeSelf)
            {   // 우선순위가 가장 높음
                gameStart.SetActive(false);
            }
            else if (setting.activeSelf || help.activeSelf || worldMap.activeSelf)
            {
                setting.SetActive(false);
                help.SetActive(false);
                worldMap.SetActive(false);
            }
            else
            {
                OnMenuActive();
            }
        }
    }

    public void OnMenuActive()
    {
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
    }

    public void onGameStartActive()
    {
        theAudio.Play(button);

        stageText.text = "STAGE " + EventSystem.current.currentSelectedGameObject.GetComponent<StageInfo>().stageName;
        highScore.text = "Score : " + EventSystem.current.currentSelectedGameObject.GetComponent<StageInfo>().highScore;
        highCombo.text = "Combo : " + EventSystem.current.currentSelectedGameObject.GetComponent<StageInfo>().highCombo;

        StageManager.instance.stageName = EventSystem.current.currentSelectedGameObject.GetComponent<StageInfo>().stageName;
        Debug.Log("스테이지 : " + EventSystem.current.currentSelectedGameObject.GetComponent<StageInfo>().stageName);

        StageManager.instance.stageBGM = EventSystem.current.currentSelectedGameObject.GetComponent<StageInfo>().stageBGM;
        Debug.Log("테마곡 : " + EventSystem.current.currentSelectedGameObject.GetComponent<StageInfo>().stageBGM);

        gameStart.SetActive(true);
    }

    public void onGameStartDisable()
    {
        theAudio.Play(button);
        gameStart.SetActive(false);
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

    public void onWorldMapActive()
    {
        theAudio.Play(button);
        worldMap.SetActive(true);
    }

    public void onWorldMapDisable()
    {
        theAudio.Play(button);
        worldMap.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();     // 겜 종료
    }
}
