using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NoteManager : MonoBehaviour
{
    private List<Enemy> enemies= new List<Enemy>();
    private float beatInterval;
    public Transform[] spawnPoint;
    public float reachTime;


    private void MakeNote(Enemy enemy)
    {
        GameObject obj = ObjectPoolContainer.Instance.Pop(IntToTypename(enemy.typeNum));
        obj.transform.position = spawnPoint[enemy.typeNum].position;
        obj.GetComponent<EnemyInfo>().SetType(IntToTypename(enemy.typeNum));
        obj.GetComponent<EnemyInfo>().speed = reachTime;
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

    private void Start()
    {
        beatInterval = 0.5f;//노트 사이의 시간간격
        reachTime = 1.2f;//적의 도달시간(짧을수록 빠름)
        enemies.Add(new Enemy("sharpSquare", 1, 0, 10));//3번째만 바꾸면 됨(몬스터 위치)
        enemies.Add(new Enemy("sharpSquare", 2, 3, 10));
        enemies.Add(new Enemy("sharpSquare", 3, 1, 10));
        enemies.Add(new Enemy("sharpSquare", 4, 0, 10));
        enemies.Add(new Enemy("sharpSquare", 5, 3, 10));
        enemies.Add(new Enemy("sharpSquare", 6, 1, 10));
        enemies.Add(new Enemy("sharpSquare", 7, 0, 10));
        enemies.Add(new Enemy("sharpSquare", 8, 1, 10));
        enemies.Add(new Enemy("sharpSquare", 9, 2, 10));
        enemies.Add(new Enemy("sharpSquare", 10, 0, 10));
        enemies.Add(new Enemy("sharpSquare", 11, 3, 10));
        enemies.Add(new Enemy("sharpSquare", 12, 1, 10));
        enemies.Add(new Enemy("sharpSquare", 13, 0, 10));
        enemies.Add(new Enemy("sharpSquare", 14, 3, 10));
        enemies.Add(new Enemy("sharpSquare", 15, 1, 10));
        enemies.Add(new Enemy("sharpSquare", 16, 0, 10));
        enemies.Add(new Enemy("sharpSquare", 17, 2, 10));
        enemies.Add(new Enemy("sharpSquare", 18, 3, 10));
        enemies.Add(new Enemy("sharpSquare", 19, 1, 10));
        enemies.Add(new Enemy("sharpSquare", 20, 3, 10));
        enemies.Add(new Enemy("sharpSquare", 21, 0, 10));
        enemies.Add(new Enemy("sharpSquare", 22, 3, 10));
        enemies.Add(new Enemy("sharpSquare", 23, 2, 10));
        enemies.Add(new Enemy("sharpSquare", 24, 0, 10));
        enemies.Add(new Enemy("sharpSquare", 25, 0, 10));
        enemies.Add(new Enemy("sharpSquare", 26, 2, 10));
        enemies.Add(new Enemy("sharpSquare", 27, 2, 10));
        enemies.Add(new Enemy("sharpSquare", 28, 1, 10));
        enemies.Add(new Enemy("sharpSquare", 29, 3, 10));
        enemies.Add(new Enemy("sharpSquare", 30, 1, 10));
        enemies.Add(new Enemy("sharpSquare", 31, 0, 10));
        enemies.Add(new Enemy("sharpSquare", 32, 1, 10));
        enemies.Add(new Enemy("sharpSquare", 33, 2, 10));
        enemies.Add(new Enemy("sharpSquare", 34, 0, 10));
        enemies.Add(new Enemy("sharpSquare", 35, 0, 10));
        enemies.Add(new Enemy("sharpSquare", 36, 1, 10));
        enemies.Add(new Enemy("sharpSquare", 37, 0, 10));
        enemies.Add(new Enemy("sharpSquare", 38, 3, 10));
        enemies.Add(new Enemy("sharpSquare", 39, 1, 10));
        enemies.Add(new Enemy("sharpSquare", 40, 3, 10));
        enemies.Add(new Enemy("sharpSquare", 41, 2, 10));
        enemies.Add(new Enemy("sharpSquare", 42, 0, 10));
        enemies.Add(new Enemy("sharpSquare", 43, 1, 10));
        enemies.Add(new Enemy("sharpSquare", 44, 3, 10));
        enemies.Add(new Enemy("sharpSquare", 45, 1, 10));
        enemies.Add(new Enemy("sharpSquare", 46, 0, 10));
        enemies.Add(new Enemy("sharpSquare", 47, 3, 10));
        enemies.Add(new Enemy("sharpSquare", 48, 1, 10));
        enemies.Add(new Enemy("sharpSquare", 49, 2, 10));
        enemies.Add(new Enemy("sharpSquare", 50, 3, 10));
        for (int i = 0; i < enemies.Count; i++)
        {
            StartCoroutine(coNoteTimer(enemies[i]));
        }
        StartCoroutine(coEndGame(enemies.Count));
    }

    IEnumerator coNoteTimer(Enemy enemy)
    {
        yield return new WaitForSeconds(enemy.order * beatInterval);
        MakeNote(enemy);
    }

    IEnumerator coEndGame(int order)
    {
        yield return new WaitForSeconds(order * beatInterval + 4f);
        GoToGameResult();
    }

    public void GoToGameResult()
    {
        SceneManager.LoadScene("ResultScene");
    }
}
