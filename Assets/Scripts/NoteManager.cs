﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NoteManager : MonoBehaviour
{
    public static NoteManager instance;

    private List<Enemy> enemies= new List<Enemy>();
    string musicTitle;
    private float beatInterval;
    public Transform[] spawnPoint;
    public float reachTime;
    public float endTime;
    float startingPoint;

    void Awake()
    {
        instance = this; // 싱글톤 사용
    }

    // 적
    //순서, 적정보=위치(각 스테이지에서 자리에 맞는 이미지 받아옴), 데미지==각 스테이지에서 받아옴
    public void NoteStart()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            StartCoroutine(coAwaitMakeNote(enemies[i]));
        }
        //그 리스트를 이용해서 타이머를 사용
        StartCoroutine(coEndGame(endTime));
        //종료 후 초기화(에네미리스트)
    }

    public void InitNoteWithBPM(string stage)
    {
        int bpm;
        int divider;
        float beatCount;

        TextAsset textAsset = Resources.Load<TextAsset>("Beats/" + stage);

        StringReader reader = new StringReader(textAsset.text);
        musicTitle = reader.ReadLine();
        string beatInformation = reader.ReadLine();
        bpm = Convert.ToInt32(beatInformation.Split(' ')[0]);
        divider = Convert.ToInt32(beatInformation.Split(' ')[1]);
        startingPoint = (float)Convert.ToDouble(beatInformation.Split(' ')[2]);
        beatCount = (float)bpm / divider;
        beatInterval = 1 / beatCount;
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            Enemy enemy = new Enemy(
                Convert.ToInt32(line.Split(' ')[0]),//순서
                Convert.ToInt32(line.Split(' ')[1]));//위치
            enemies.Add(enemy);
        }
        //에네미 리스트를 먼저 만든 후에
        reachTime = beatInterval * 3;//노트의 스피드(짧을수록 빠름)

        endTime = enemies[enemies.Count - 1].order * beatInterval;

        Debug.Log("비트 간격 시간" + beatInterval);
        Debug.Log("종료 시간" + endTime);
    }

    //IEnumerator coNoteTimer(float endTime)
    //{
    //    float playTime = 0;
    //    float noteTime = 0;
    //    int i = 0;

    //    while (playTime < endTime)
    //    {
    //        yield return new WaitForFixedUpdate();
    //        noteTime += Time.fixedDeltaTime;
    //        playTime += Time.fixedDeltaTime;

    //        if (noteTime >= beatInterval)
    //        {
    //            noteTime -= beatInterval;
    //            MakeNote(enemies[i]);
    //            i++;
    //        }
    //    }
    //}
    IEnumerator coAwaitMakeNote(Enemy enemy)
    {
        yield return new WaitForSeconds(enemy.order * beatInterval);
        MakeNote(enemy);
    }

    IEnumerator coEndGame(float endTime)
    {
        yield return new WaitForSeconds(endTime + 4f);
        enemies.Clear();
        Results.gameWin = true;
        GameManager.instance.GoToGameResult();
    }


    private void MakeNote(Enemy enemy)
    {
        GameObject obj = ObjectPoolContainer.Instance.Pop(IntToTypename(enemy.typeNum));//타입에 맞는 몬스터 오브젝트풀에서 생성
        obj.transform.position = spawnPoint[enemy.typeNum].position;//위치 정해주기
        obj.GetComponent<EnemyInfo>().type = enemy.typeNum;//타입 정해주기
        obj.GetComponent<EnemyInfo>().speed = reachTime;//도달 시간
        obj.SetActive(true);
    }

    private string IntToTypename(int i)
    {
        switch (i)
        {
            default: return "";
            case 0: return "HighMonster";
            case 1: return "HighAttack";
            case 2: return "LowAttack";
            case 3: return "LowMonster";
        }
    }
    
    private void OnDestroy()
    {
        instance = null;
    }
}
