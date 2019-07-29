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
    public Button button;
    public float speed;
    public float damage;

    public Type type;

    public enum Type
    {
        HighMonster, LowMonster, HighAttack, LowAttack
    }
    

    private void Awake()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        damage = 10;
        Move(-20f, speed);
    }
    private void Move(float to, float duration)
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(transform.DOMoveX(to, duration));
    }
    public void SetType(string type)
    {
        this.type = (Type)Enum.Parse(typeof(Type), type);
    }

    public void DestroyThis()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "EndLine")
        {
            ControlManager.instance.judge = ControlManager.judges.MISS;
            ControlManager.instance.GetThisEnemy(gameObject);
            ControlManager.instance.ProcessJudge(ControlManager.judges.MISS);
            ControlManager.instance.DestroyCombo();
            PlayerInfo.instance.GetDamage(damage);
            DOTween.Kill(gameObject);
            gameObject.SetActive(false);
        }
        else if (col.tag == "HitLine")
        {
            ControlManager.instance.judge = ControlManager.judges.GOOD;
            ControlManager.instance.GetThisEnemy(gameObject);
        }
        else if (col.tag == "PerfectLine")
        {
            ControlManager.instance.judge = ControlManager.judges.PERFECT;
            ControlManager.instance.GetThisEnemy(gameObject);
        }
    }
}
