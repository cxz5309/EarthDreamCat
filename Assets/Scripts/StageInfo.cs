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
        stageName = StageManager.instance.stageInfoDic[stageNumber].stageName;
        stageBGM = StageManager.instance.stageInfoDic[stageNumber].stageBGM;

        GetStageInfo();
    }

    void GetStageInfo()     // 겜 시작 할 때 각각의 스테이지 정보를 가져옴.
    {
        highScore = PlayerPrefs.GetInt(stageNumber + "Score");
        highCombo = PlayerPrefs.GetInt(stageNumber + "Combo");

        if (PlayerPrefs.GetInt("playerCurStage") < stageNumber)
        {   // playerCurStage 보다 높은 단계이면 버튼 비활성화
            gameObject.GetComponent<UIButton>().isEnabled = false;
        }

        //if (PlayerPrefs.GetInt("playerCurStage") == stageNumber)
        //{   // playerCurStage 단계이면 
        //    StageManager.instance.GetPlayerCurStage();
        //}
    }
}
