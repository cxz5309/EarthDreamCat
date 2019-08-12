using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage
{
    public string stageName;
    public string stageBGM;

    public Stage(string stageName, string stageBGM)
    {
        this.stageName = stageName;
        this.stageBGM = stageBGM;
    }
}
