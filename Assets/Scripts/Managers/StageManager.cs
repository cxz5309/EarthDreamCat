using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public static StageManager instance;

    public UIGrid m_grid;
    public GameObject m_stageButton;
    public UILabel m_stageLabel;

    public int stageNumber;
    public string stageName;
    public string stageBGM;

    public GameObject Stage01;
    public GameObject Stage02;

    public Dictionary<string, List<Stage>> chapterDic = new Dictionary<string, List<Stage>>();


    public void CreateStage(string chapter)
    {
        List<Stage> stageList = chapterDic[chapter];

        for (int i = 0; i < stageList.Count; i++)
        {
            m_stageLabel.text = stageList[i].stageName;
            GameObject btn = NGUITools.AddChild(m_grid.gameObject, m_stageButton.gameObject);
            btn.GetComponent<StageInfo>().stageName = stageList[i].stageName;
            btn.GetComponent<StageInfo>().stageBGM = stageList[i].stageBGM;
            btn.name = "Stage " + stageList[i].stageName;
            btn.SetActive(true);
        }

        m_grid.Reposition();     // 재정렬
    }

    public void InitStage()
    {
        List<Stage> stageList;

        stageList = new List<Stage>();
        stageList.Add(new Stage("1-1", "theme01"));
        stageList.Add(new Stage("1-2", "theme02"));
        stageList.Add(new Stage("1-3", "theme02"));
        stageList.Add(new Stage("1-4", "theme01"));
        chapterDic.Add("KOR", stageList);

        stageList = new List<Stage>();
        stageList.Add(new Stage("2-1", "theme01"));
        stageList.Add(new Stage("2-2", "theme02"));
        stageList.Add(new Stage("2-3", "theme01"));
        chapterDic.Add("JAP", stageList);

        stageList = new List<Stage>();
        stageList.Add(new Stage("3-1", "theme02"));
        stageList.Add(new Stage("3-2", "theme01"));
        stageList.Add(new Stage("3-3", "theme02"));
        stageList.Add(new Stage("3-4", "theme02"));
        stageList.Add(new Stage("3-5", "theme01"));
        stageList.Add(new Stage("3-6", "theme01"));
        stageList.Add(new Stage("3-7", "theme02"));
        chapterDic.Add("CHA", stageList);

        stageList = new List<Stage>();
        stageList.Add(new Stage("4-1", "theme02"));
        stageList.Add(new Stage("4-2", "theme01"));
        stageList.Add(new Stage("4-3", "theme02"));
        stageList.Add(new Stage("4-4", "theme02"));
        stageList.Add(new Stage("4-5", "theme01"));
        stageList.Add(new Stage("4-6", "theme01"));
        stageList.Add(new Stage("4-7", "theme02"));
        stageList.Add(new Stage("4-8", "theme02"));
        chapterDic.Add("USA", stageList);

        stageList = new List<Stage>();
        stageList.Add(new Stage("5-1", "theme02"));
        stageList.Add(new Stage("5-2", "theme01"));
        stageList.Add(new Stage("5-3", "theme02"));
        stageList.Add(new Stage("5-4", "theme02"));
        chapterDic.Add("ESP", stageList);
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

        //stageName = stageInfoDic["KOR"].stageName;
        //stageBGM = stageInfoDic["KOR"].stageBGM;
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

    //public void InitScore()
    //{
    //    for (int i = 0; i < stageInfoDic.Count; i++)
    //    {
    //        PlayerPrefs.SetInt(i + "Score", 0);
    //        PlayerPrefs.SetInt(i + "Combo", 0);
    //    }
    //}

    private void OnDestroy()
    {
        instance = null;
    }
}
