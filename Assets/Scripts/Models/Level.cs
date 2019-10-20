using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level
{
    public int probabilityOfHavingLive = 0;
    public int LevelId { get; set; }
    public int EnemyCount { get; set; }
    public float InstantiateTimeFrom { get; set; }
    public float InstantiateTimeTo { get; set; }

}
