using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public string gameBGM;
    private AudioManager theAudio;


    [Header("Object Pool Variables")]
    public GameObject HighMonster;
    public GameObject LowMonster;
    public GameObject HighAttack;
    public GameObject LowAttack;
    public GameObject HitEffect;

    void Awake()
    {
        instance = this; // 싱글톤 사용
        InitObjectPool(); // ObjectPoolContainer 초기화
    }

    private void Start()
    {
        theAudio = FindObjectOfType<AudioManager>();
        theAudio.Play(gameBGM);
    }

    void InitObjectPool()
    {
        ObjectPoolContainer.Instance.CreateObjectPool("HighMonster", HighMonster, 20);
        ObjectPoolContainer.Instance.CreateObjectPool("LowMonster", LowMonster, 20);
        ObjectPoolContainer.Instance.CreateObjectPool("HighAttack", HighAttack, 20);
        ObjectPoolContainer.Instance.CreateObjectPool("LowAttack", LowAttack, 20);
        ObjectPoolContainer.Instance.CreateObjectPool("HitEffect", HitEffect, 20);
    }
}
