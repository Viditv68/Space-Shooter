using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemeyShipPrefab;
    [SerializeField]
    private GameObject[] powerups;
    // Start is called before the first frame update

    private GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        StartCoroutine(EnemySpawnRoutine());
        StartCoroutine(PowerupSpawnRoutine());
    }

    // Update is called once per frame

    public void StartSpawnRoutines()
    {
        StartCoroutine(EnemySpawnRoutine());
        StartCoroutine(PowerupSpawnRoutine());
    }
    IEnumerator EnemySpawnRoutine()
    {
        while(gameManager.gameOver == false)
        {
            Instantiate(enemeyShipPrefab, new Vector3(Random.Range(-8.80f, 8.80f), 5.3f, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }

    IEnumerator PowerupSpawnRoutine()
    {
        while (gameManager.gameOver == false)
        {
            int randomPowerup = Random.Range(0, 3);
            Instantiate(powerups[randomPowerup], new Vector3(Random.Range(-8.0f, 8.80f), 5.3f, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
       
    }
}
