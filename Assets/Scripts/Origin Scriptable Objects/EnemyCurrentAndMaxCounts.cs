using UnityEngine;

[CreateAssetMenu(menuName = "Create current and max enemy count")]
public class EnemyCurrentAndMaxCounts : ScriptableObject
{
    public int currentCount;
    public int maxCount;
    public int nextEnemyID;
}
