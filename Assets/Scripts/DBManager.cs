using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DBManager : MonoBehaviour
{
    public Text highScoreText;


    void Start()
    {
        Debug.Log("1-1 현재 최고 스코어 :" + PlayerPrefs.GetInt("1-1Score").ToString());
        Load();
    }

    //public void Save()
    //{

    //}

    public void Load()
    {
        if (PlayerPrefs.HasKey("1-1Score"))    // Score 키값에 있는 int 값을 불러옴
        {
            highScoreText.text = "1-1 Best : " + PlayerPrefs.GetInt("1-1Score").ToString();
        }
    }
}
