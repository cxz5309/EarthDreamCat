using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    public GameObject gameWinUI;
    public GameObject gameLoseUI;
    public Text maxComboText;
    public Text scoreText;
    public Text perfectText;
    public Text goodText;
    public Text missText;

    int maxCombo = Results.maxCombo;
    int[] judgeNum = Results.judgeNum;
    int score = Results.score;
    bool gameWin = Results.gameWin;

    public string button;
    private AudioManager theAudio;


    private void Start()
    {
        if (gameWin)    // 스테이지 성공
        {
            gameWinUI.SetActive(true);
            gameLoseUI.SetActive(false);
            theAudio = FindObjectOfType<AudioManager>();
            maxComboText.text = "MaxCombo : " + maxCombo.ToString();
            scoreText.text = "Score : " + score.ToString();
            perfectText.text = "Perfect : " + judgeNum[0].ToString();
            goodText.text = "Good : " + judgeNum[1].ToString();
            missText.text = "Miss : " + judgeNum[2].ToString();

            if (PlayerPrefs.GetInt(StageManager.instance.stageNumber + "Score") < score)
            {   // 최고 스코어보다 현재 점수가 더 높으면 현재 스테이지 점수 저장
                PlayerPrefs.SetInt(StageManager.instance.stageNumber + "Score", score); // 스코어 저장
                PlayerPrefs.SetInt(StageManager.instance.stageNumber + "Combo", maxCombo); // 콤보 저장
                Debug.Log("최고 스코어 저장 : " + PlayerPrefs.GetInt(StageManager.instance.stageNumber + "Score").ToString() + "최고 콤보 저장 : " + PlayerPrefs.GetInt(StageManager.instance.stageNumber + "Combo").ToString());
            }

            DBManager.instance.StageIncrease();     // 다음 스테이지를 저장하는 함수
        }
        else  // 스테이지 실패
        {
            theAudio = FindObjectOfType<AudioManager>();
            gameWinUI.SetActive(false);
            gameLoseUI.SetActive(true);
        }
    }

    public void GoToMain()
    {
        theAudio.Play(button);
        SceneManager.LoadScene("MainScene");
    }

    public void GoToGame()
    {
        theAudio.Play(button);
        SceneManager.LoadScene("GameScene");
    }
}
