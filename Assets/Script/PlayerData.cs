using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{

    public bool isDead;
    public bool coin1Collect;
    public bool coin2Collect;
    public bool coin3Collect;

    public int coinNumber;

    public Vector3 playerPosition;
    public Quaternion playerRotation;
    public Vector3 playerScale;
}
