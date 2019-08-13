using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.UI;

public class EnemyInfo : MonoBehaviour
{
    private Rigidbody2D rb;
    private string effectName;
    public float speed;
    public float damage;

    public int type { get; set; }//0=맨 위 몬스터, 1=2번째 투사체, 2=3번째 투사체, 3=마지막 몬스터
    
    private void Awake()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        damage = 10;
        Move(-10, speed);
    }

    private void Move(float to, float duration)
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(transform.DOMoveX(to, duration));
    }

    public void DestroyThis()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "EndLine")
        {
            ControlManager.instance.GetThisEnemy(gameObject, type);

            ControlManager.instance.judge = ControlManager.judges.MISS;
            ControlManager.instance.ProcessJudge(ControlManager.judges.MISS);
            ControlManager.instance.DestroyCombo();
            PlayerInfo.instance.GetDamage(damage);
            DOTween.Kill(gameObject);
            gameObject.SetActive(false);
        }
        else if(col.tag == "MissLine")
        {

            ControlManager.instance.GetThisEnemy(gameObject, type);

            ControlManager.instance.judge = ControlManager.judges.MISS;

        }
        else if (col.tag == "HitLine")
        {
            ControlManager.instance.GetThisEnemy(gameObject, type);

            ControlManager.instance.judge = ControlManager.judges.GOOD;
        }
        else if (col.tag == "PerfectLine")
        {
            ControlManager.instance.GetThisEnemy(gameObject, type);

            ControlManager.instance.judge = ControlManager.judges.PERFECT;
        }
    }
}
