using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    public int order; //순서
    public int typeNum; // 위치

    public Enemy(int order, int typeNum)
    {
        this.order = order;
        this.typeNum = typeNum;
    }
}
