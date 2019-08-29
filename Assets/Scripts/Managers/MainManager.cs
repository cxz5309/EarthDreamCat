using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainManager : MonoBehaviour
{
    public GameObject screenExit;       // 메뉴 전체 활성화/비활성화
    public GameObject screenChapter;        // 월드맵
    public GameObject screenStage;        // 스테이지 정보
    public GameObject screenReady;         // 준비창

    public UILabel chapterName;

    public GameObject playButton;

    private bool activated;     // 활성화 됐는지 비활성화 됐는지

    public string button;
    private AudioManager theAudio;

    
    private void Start()
    {
        theAudio = FindObjectOfType<AudioManager>();

        //playButton.GetComponent<Text>().text = StageManager.instance.stageInfoDic[PlayerPrefs.GetInt("playerCurStage")].stageName + " PLAY";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            theAudio.Play(button);

            if (screenStage.activeSelf)
            {   // 우선순위가 가장 높음
                screenStage.SetActive(false);
            }
            else if (screenChapter.activeSelf)
            {
                screenChapter.SetActive(false);
            }
            else
            {
                OnEndActive();
            }
        }
    }

    public void OnEndActive()
    {
        activated = !activated;

        if (activated)
        {
            screenExit.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            screenExit.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void OnReadyActive()
    {
        theAudio.Play(button);

        if (screenReady.activeSelf)
        {
            screenReady.SetActive(false);
        }
        else
        {
            screenReady.SetActive(true);

            StageManager.instance.stageName = UIButton.current.GetComponent<StageInfo>().stageName;
            StageManager.instance.stageBGM = UIButton.current.GetComponent<StageInfo>().stageBGM;
        }
    }

    public void OnStageActive()
    {
        theAudio.Play(button);

        if (screenStage.activeSelf)
        {
            screenStage.SetActive(false);
        }
        else
        {
            screenStage.SetActive(true);
            chapterName.text = UIButton.current.tag;
            StageManager.instance.CreateStage(UIButton.current.tag);
        }
    }

    public void OnChapterActive()
    {
        theAudio.Play(button);
        if(screenChapter.activeSelf)
            screenChapter.SetActive(false);
        else
            screenChapter.SetActive(true);
    }

    public void SceneChangeToGame()
    {
        theAudio.Play(button);
        SceneManager.LoadScene("GameScene");
    }

    public void InitStage()     // 플레이어 현재 스테이지 초기화
    {
        PlayerPrefs.SetInt("playerCurStage", 0);
        SceneManager.LoadScene("MainScene");
        //StageManager.instance.InitScore();
    }

    public void Exit()
    {
        Application.Quit();     // 겜 종료
    }
}
