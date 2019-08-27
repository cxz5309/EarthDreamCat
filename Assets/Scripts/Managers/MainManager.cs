using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainManager : MonoBehaviour
{
    public GameObject exitScreen;       // 메뉴 전체 활성화/비활성화
    public GameObject chapterScreen;        // 월드맵
    public GameObject stageScreen;        // 스테이지 정보

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

            if (stageScreen.activeSelf)
            {   // 우선순위가 가장 높음
                stageScreen.SetActive(false);
            }
            else if (chapterScreen.activeSelf)
            {
                chapterScreen.SetActive(false);
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
            exitScreen.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            exitScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void OnStageActive()
    {
        theAudio.Play(button);

        if (stageScreen.activeSelf)
        {
            stageScreen.SetActive(false);
        }
        else
        {
            stageScreen.SetActive(true);
            chapterName.text = UIButton.current.tag;
            StageManager.instance.CreateStage(UIButton.current.tag);
        }
    }

    public void OnChapterActive()
    {
        theAudio.Play(button);
        if(chapterScreen.activeSelf)
            chapterScreen.SetActive(false);
        else
            chapterScreen.SetActive(true);
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
