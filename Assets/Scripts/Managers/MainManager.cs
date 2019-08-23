using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainManager : MonoBehaviour
{
    public GameObject endScreen;       // 메뉴 전체 활성화/비활성화
    public GameObject help;       // 도움말
    public GameObject setting;       // 환경설정
    public GameObject chapter;        // 월드맵
    public GameObject stageInfo;        // 스테이지 정보

    public GameObject playButton;

    public Text stageText;
    public Text highScore;
    public Text highCombo;

    private bool activated;     // 활성화 됐는지 비활성화 됐는지

    public string button;
    private AudioManager theAudio;

    
    private void Start()
    {
        theAudio = FindObjectOfType<AudioManager>();

        playButton.GetComponent<Text>().text = StageManager.instance.stageInfoDic[PlayerPrefs.GetInt("playerCurStage")].stageName + " PLAY";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            theAudio.Play(button);

            if (stageInfo.activeSelf)
            {   // 우선순위가 가장 높음
                stageInfo.SetActive(false);
            }
            else if (setting.activeSelf || help.activeSelf || chapter.activeSelf)
            {
                setting.SetActive(false);
                help.SetActive(false);
                chapter.SetActive(false);
            }
            else
            {
                OnEndScreenActive();
            }
        }
    }

    public void OnEndScreenActive()
    {
        activated = !activated;

        if (activated)
        {
            endScreen.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            endScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void OnStageInfoActive()
    {
        theAudio.Play(button);
        if (stageInfo.activeSelf)
        {
            stageInfo.SetActive(false);
        }
        else
        {
            stageText.text = "STAGE " + EventSystem.current.currentSelectedGameObject.GetComponent<StageInfo>().stageName;
            highScore.text = "Score : " + EventSystem.current.currentSelectedGameObject.GetComponent<StageInfo>().highScore;
            highCombo.text = "Combo : " + EventSystem.current.currentSelectedGameObject.GetComponent<StageInfo>().highCombo;

            // 스테이지매니저에 클릭한 스테이지 정보 넘겨주기
            StageManager.instance.stageNumber = EventSystem.current.currentSelectedGameObject.GetComponent<StageInfo>().stageNumber;
            StageManager.instance.stageName = EventSystem.current.currentSelectedGameObject.GetComponent<StageInfo>().stageName;
            StageManager.instance.stageBGM = EventSystem.current.currentSelectedGameObject.GetComponent<StageInfo>().stageBGM;

            Debug.Log("번호 : " + EventSystem.current.currentSelectedGameObject.GetComponent<StageInfo>().stageNumber + " / 스테이지 : " + EventSystem.current.currentSelectedGameObject.GetComponent<StageInfo>().stageName + " / 테마곡 : " + EventSystem.current.currentSelectedGameObject.GetComponent<StageInfo>().stageBGM);

            stageInfo.SetActive(true);
        }
    }

    public void OnPlayButton()
    {
        theAudio.Play(button);

        // 플레이어 현재 스테이지에 해당하는 스테이지정보를 가져와야함.
        StageManager.instance.GetPlayerCurStage();
        stageText.text = "STAGE " + StageManager.instance.stageInfoDic[PlayerPrefs.GetInt("playerCurStage")].stageName;
        highScore.text = "Score : " + PlayerPrefs.GetInt(PlayerPrefs.GetInt("playerCurStage").ToString() + "Score");
        highCombo.text = "Combo : " + PlayerPrefs.GetInt(PlayerPrefs.GetInt("playerCurStage").ToString() + "Combo");

        stageInfo.SetActive(true);
    }

    public void OnSettingActive()
    {
        theAudio.Play(button);
        if (setting.activeSelf)
            setting.SetActive(false);
        else
            setting.SetActive(true);
    }

    public void OnHelpActive()
    {
        theAudio.Play(button);
        if (help.activeSelf)
            help.SetActive(false);
        else
            help.SetActive(true);
    }

    public void OnChapterActive()
    {
        theAudio.Play(button);
        if(chapter.activeSelf)
            chapter.SetActive(false);
        else
            chapter.SetActive(true);
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
        StageManager.instance.InitScore();
    }

    public void Exit()
    {
        Application.Quit();     // 겜 종료
    }
}
