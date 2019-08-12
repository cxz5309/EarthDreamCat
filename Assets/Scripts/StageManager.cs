using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public static StageManager instance;

    public int stageNumber;
    public string stageName;
    public string stageBGM;
    public GameObject Stage01;
    public GameObject Stage02;

    public Dictionary<int, Stage> stageInfoDic = new Dictionary<int, Stage>();


    public void InitStage()
    {
        stageInfoDic.Add(0, new Stage("1-1", "Theme01"));
        stageInfoDic.Add(1, new Stage("2-1", "Theme02"));
        stageInfoDic.Add(2, new Stage("3-1", "Theme01"));
    }

    void Awake()
    {
        instance = this; // 싱글톤 사용
        InitStage();
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void GetPlayerCurStage()
    {
        stageNumber = PlayerPrefs.GetInt("playerCurStage");

        stageName = stageInfoDic[stageNumber].stageName;
        stageBGM = stageInfoDic[stageNumber].stageBGM;
    }

    public void CreateMap()
    {
        switch (stageName)
        {
            case "1-1":
                Instantiate(Stage01);
                break;
            case "2-1":
                Instantiate(Stage02);
                break;
            case "3-1":
                Instantiate(Stage01);
                break;
        }
    }

    public void InitScore()
    {
        for (int i = 0; i < stageInfoDic.Count; i++)
        {
            PlayerPrefs.SetInt(i + "Score", 0);
            PlayerPrefs.SetInt(i + "Combo", 0);
        }
    }

    private void OnDestroy()
    {
        instance = null;
    }
}
