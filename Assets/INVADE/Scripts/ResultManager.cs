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

    int maxCombo = Results.maxCombo;
    int[] judgeNum = Results.judgeNum;
    int score = Results.score;

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
    }

    public void GoToGame()
    {
        theAudio.Play(button);
        SceneManager.LoadScene("GameScene");
    }
}
