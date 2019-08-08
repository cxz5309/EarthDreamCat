using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public static StageManager instance;
    
    public string stageName;
    public string stageBGM;
    public GameObject Stage01;
    public GameObject Stage02;


    void Awake()
    {
        instance = this; // 싱글톤 사용
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void stageStart()
    {
        switch (stageName)
        {
            case "1-1":
                Instantiate(Stage01);
                break;
            case "2-1":
                Instantiate(Stage02);
                break;
        }
    }

    private void OnDestroy()
    {
        instance = null;
    }
}
