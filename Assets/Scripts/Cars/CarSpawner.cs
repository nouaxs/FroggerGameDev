using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] float spawnInterval; // Duration between each car spawn action
    [SerializeField] GameObject carObject;
    [SerializeField] bool isGameActive = true;
    [SerializeField] Transform[] spawnPoints;
    private const float timeToDestroy = 10f;

    private void Start()
    {
        StartCoroutine(SpawnCars());
    }

    /**
     * This method spawns cars at random spawn points and then destroys then after a certain amount of time
     */
    IEnumerator SpawnCars()
    {
        while (isGameActive == true)
        {
            int randomIndx = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[randomIndx];
            GameObject spawnedCar = Instantiate(carObject, spawnPoint.position, spawnPoint.rotation);
            yield return new WaitForSeconds(spawnInterval);

            Destroy(spawnedCar, timeToDestroy);
        }
    }


}