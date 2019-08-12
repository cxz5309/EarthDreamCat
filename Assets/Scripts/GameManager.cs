using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject gameSceneMenu;       // 메뉴 전체 활성화/비활성화
    private bool activated;     // 활성화 됐는지 비활성화 됐는지

    private string themeSound;
    public string buttonSound;
    private AudioManager theAudio;

    [Header("Object Pool Variables")]
    public GameObject HighMonster;
    public GameObject LowMonster;
    public GameObject HighAttack;
    public GameObject LowAttack;
    public GameObject HitEffect;
    //이거를 스테이지마다 다르게 리소스에서 받아와야 할 듯

    void Awake()
    {
        instance = this; // 싱글톤 사용
        InitEnemyObjectPool();
        InitObjectPool(); // ObjectPoolContainer 초기화
    }

    private void Start()
    {
        theAudio = FindObjectOfType<AudioManager>();
        StageManager.instance.CreateMap();         // StageManager에 있는 StageName이 가지고 있는 맵을 생성
        themeSound = StageManager.instance.stageBGM;    // StageManager에 있는 stageBGM 재생
        theAudio.Play(themeSound);
        NoteManager.instance.NoteStart();
    }

    public void InitEnemyObjectPool()
    {
        HighMonster = Resources.Load("Prefabs/EnemyPrefabs/Stage" + StageManager.instance.stageName.Split('-')[0] + "/Monster_High") as GameObject;
        LowMonster = Resources.Load("Prefabs/EnemyPrefabs/Stage" + StageManager.instance.stageName.Split('-')[0] + "/Monster_Low") as GameObject;
        HighAttack = Resources.Load("Prefabs/EnemyPrefabs/Stage" + StageManager.instance.stageName.Split('-')[0] + "/Saw_High") as GameObject;
        LowAttack = Resources.Load("Prefabs/EnemyPrefabs/Stage" + StageManager.instance.stageName.Split('-')[0] + "/Saw_Low") as GameObject;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnMenuActive();
        }
    }

    void InitObjectPool()
    {
        ObjectPoolContainer.Instance.CreateObjectPool("HighMonster", HighMonster, 20);
        ObjectPoolContainer.Instance.CreateObjectPool("LowMonster", LowMonster, 20);
        ObjectPoolContainer.Instance.CreateObjectPool("HighAttack", HighAttack, 20);
        ObjectPoolContainer.Instance.CreateObjectPool("LowAttack", LowAttack, 20);
        ObjectPoolContainer.Instance.CreateObjectPool("HitEffect", HitEffect, 20);
    }

    public void GameOver()
    {
        Results.gameWin = false;
        GoToGameResult();
    }

    public void GoToGameResult()
    {
        SceneManager.LoadScene("ResultScene");
    }

    public void OnMenuActive()
    {
        theAudio.Play(buttonSound);
        activated = !activated;

        if (activated)
        {
            gameSceneMenu.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            gameSceneMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void Continue()
    {
        theAudio.Play(buttonSound);
        activated = false;
        gameSceneMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void SceneChangeToGame()
    {
        theAudio.Play(buttonSound);
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1;
    }

    public void SceneChangeToMain()
    {
        theAudio.Play(buttonSound);
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1;
        theAudio.Stop(themeSound);
    }

    public void Exit()
    {
        Application.Quit();     // 겜 종료
    }


    public void BackGroundMute(Toggle toggle)
    {
        theAudio.SetBackGroundMute(toggle.isOn);
    }

    public void EffectMute(Toggle toggle)
    {
        theAudio.SetEffectMute(toggle.isOn);
    }

    private void OnDestroy()
    {
        instance = null;
    }
}
