using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] ObjectPool objectPool;
    public Player playerPrefab;
    public Transform spawnPoint;
    private void Start()
    {
        SpwanNewPlayer();
    }
    public void SpwanNewPlayer()
    {
        GameObject playerGo = objectPool.GetCharacterByType(CharacterType.Normal);

        playerGo.transform.position = spawnPoint.position;
        // playerGo.transform.rotation = Quaternion.identity;
        playerGo.SetActive(true);
    }
}
