using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    public Text maxComboText;
    public Text scoreText;
    public Text perfectText;
    public Text goodText;
    public Text missText;

    int maxCombo = ControlManager.instance.maxCombo;
    int[] judgeNum = ControlManager.instance.judgeNum;
    int score = ControlManager.instance.score;

    public string button;
    private AudioManager theAudio;


    private void Start()
    {
        theAudio = FindObjectOfType<AudioManager>();
        maxComboText.text = "MaxCombo : " + maxCombo.ToString();
        scoreText.text = "Score : "+score.ToString();
        perfectText.text = "Perfect : "+judgeNum[0].ToString();
        goodText.text = "Good : "+judgeNum[1].ToString();
        missText.text = "Miss : "+judgeNum[2].ToString();
    }

    public void GoToMain()
    {
        theAudio.Play(button);
        SceneManager.LoadScene("MainScene");

        // 게임매니저가 사라지면 오디오매니저를 파괴하면서 메인화면으로 갔을 때 중복을 방지
        if (AudioManager.instance != null)
        {
            AudioManager.instance.SetDestroy();
        }
    }

    public void GoToGame()
    {
        theAudio.Play(button);
        SceneManager.LoadScene("GameScene");
    }
}
