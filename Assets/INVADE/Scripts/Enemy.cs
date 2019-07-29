using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    public string name;             // 이름 ( 프리팹 이름 )
    public int order;
    public int typeNum;   // 위치
    public int damage;              // 공격력

    public Enemy(string name, int order, int typeNum, int damage)
    {
        this.name = name;
        this.order = order;
        this.typeNum = typeNum;
        this.damage = damage;
    }
}
