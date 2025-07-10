using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    None = 0,
    Normal = 1,
}
public enum CharacterType
{
    None = 0,
    Normal = 1,
}
public class ObjectPool : MonoBehaviour
{

    [SerializeField] GameObject enemyPrefabs;
    [SerializeField] GameObject characterPrefabs;
    private Dictionary<EnemyType, List<GameObject>> enemyPools = new Dictionary<EnemyType, List<GameObject>>();
    private Dictionary<CharacterType, List<GameObject>> characterPools = new Dictionary<CharacterType, List<GameObject>>();


    public GameObject GetEnemyByType(EnemyType enemyType)
    {
        if (enemyPools.ContainsKey(enemyType))
        {

            var lsEnemy = enemyPools[enemyType];
            foreach (var item in lsEnemy)
            {
                if (!item.activeInHierarchy)
                {
                    return item;
                }
            }
            return InstantiateEnemyByType(enemyType);
        }
        else
        {
            return InstantiateEnemyByType(enemyType);
        }
    }
    private GameObject InstantiateEnemyByType(EnemyType enemyType)
    {
        var obj = InstantiateNormalEnemy();
        if (enemyPools.ContainsKey(enemyType))
        {
            var lsEnemy = enemyPools[enemyType];
            lsEnemy.Add(obj);
        }
        else
        {
            List<GameObject> lsEnemy = new List<GameObject>();
            lsEnemy.Add(obj);
            enemyPools.Add(enemyType, lsEnemy);
        }
        return obj;
    }

    private GameObject InstantiateNormalEnemy()
    {
        return Instantiate(enemyPrefabs);
    }
    public GameObject GetCharacterByType(CharacterType characterType)
    {
        if (characterPools.ContainsKey(characterType))
        {

            var lsCharacter = characterPools[characterType];
            foreach (var item in lsCharacter)
            {
                if (!item.activeInHierarchy)
                {
                    return item;
                }
            }
            return InstantiateCharacterByType(characterType);
        }
        else
        {
            return InstantiateCharacterByType(characterType);
        }
    }
    private GameObject InstantiateCharacterByType(CharacterType characterType)
    {
        var obj = InstantiateNormalCharacter();
        if (characterPools.ContainsKey(characterType))
        {
            var lsCharacter = characterPools[characterType];
            lsCharacter.Add(obj);
        }
        else
        {
            List<GameObject> lsCharacter = new List<GameObject>();
            lsCharacter.Add(obj);
            characterPools.Add(characterType, lsCharacter);
        }
        return obj;
    }

    private GameObject InstantiateNormalCharacter()
    {
        return Instantiate(characterPrefabs);
    }
}
