using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StageInfo : MonoBehaviour
{
    public int stageNumber;
    public string stageName;
    public string stageBGM;
    public int highScore;
    public int highCombo;


    void Start()
    {
        GetStageInfo();
    }

    void GetStageInfo()     // 겜 시작 할 때 각각의 스테이지 정보를 가져옴.
    {
        highScore = PlayerPrefs.GetInt(stageName + "Score");
        highCombo = PlayerPrefs.GetInt(stageName + "Combo");

        if (PlayerPrefs.GetInt("playerCurStage") < stageNumber)
        {   // playerCurStage 보다 높은 단계이면 버튼 비활성화
            gameObject.GetComponent<Button>().interactable = false;
        }
    }
}
