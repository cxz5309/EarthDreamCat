using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DBManager : MonoBehaviour
{
    public static DBManager instance;

    public Text highScoreText;

    public int playerCurStage;      // 플레이어 현재 스테이지


    void Awake()
    {
        instance = this; // 싱글톤 사용
    }

    void Start()
    {
        Load();
    }

    public void Save()
    {

    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("playerCurStage"))
        {   // playerCurStage 키가 존재할때
            playerCurStage = PlayerPrefs.GetInt("playerCurStage");
        }
        else if (!PlayerPrefs.HasKey("playerCurStage"))
        {   // playerCurStage 키가 존재하지 않을때
            playerCurStage = 0;
        }

        Debug.Log("플레이어 현재 스테이지 : " + playerCurStage);
    }

    public void StageIncrease()     
    {
        playerCurStage++;       // 플레이어의 현재 스테이지 증가
        PlayerPrefs.SetInt("playerCurStage", playerCurStage);   // db에 저장
    }
}
