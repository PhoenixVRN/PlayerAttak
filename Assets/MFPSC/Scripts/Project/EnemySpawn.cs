using System.Collections;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPosition;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private int _timeSpawn;
    
    void Start()
    {
        StartCoroutine(SpawnPosinion());
    }

    IEnumerator SpawnPosinion()
    {
        while (true)
        {
            var _randomSpot = Random.Range(0, _spawnPosition.Length);
            Instantiate(_enemy, _spawnPosition[_randomSpot].position, Quaternion.identity);
            yield return new WaitForSeconds(_timeSpawn);
        }
    }
}
