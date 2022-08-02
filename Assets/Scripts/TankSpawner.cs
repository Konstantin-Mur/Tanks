using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawner : MonoBehaviour
{
    [SerializeField] protected List<GameObject> _tanks;
    [SerializeField] private List<Transform> _spawmPoints;
    [SerializeField] private float _spawnTime = 4f;

    private void Start()
    {

        StartCoroutine(SpawnTank());
    }

    IEnumerator SpawnTank()
    {
        while (true)
        {
            int limit;
            if (Stats.Level <_tanks.Count)
            {
                limit = Stats.Level;
            }
            else
            {
                limit = _tanks.Count;
            }
            Instantiate(_tanks[Random.Range(0, limit)], _spawmPoints[Random.Range(0, _spawmPoints.Count)].position, Quaternion.identity);
            yield return new WaitForSeconds(_spawnTime);
        }
    }
}
