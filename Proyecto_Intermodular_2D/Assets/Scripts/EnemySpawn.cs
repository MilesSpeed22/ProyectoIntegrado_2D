using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float firstSpawn;
    [SerializeField] float repeatSpawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(CannonShoot), firstSpawn, repeatSpawn);
    }

    void CannonShoot()
    {
        Instantiate(enemy, spawnPoint.position, Quaternion.identity);
    }
}
