using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] ObjectPool objectPool;
    public Enemy enemyPrefab;
    public Transform spawnPoint;
    private void Start()
    {
        SpwanNewEnemy();
    }
    public void SpwanNewEnemy()
    {
        GameObject enemyGO = objectPool.GetEnemyByType(EnemyType.Normal);

        enemyGO.transform.position = spawnPoint.position;
        enemyGO.SetActive(true);
    }
}
