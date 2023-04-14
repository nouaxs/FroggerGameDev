using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] float spawnInterval;
    [SerializeField] GameObject carObject;
    [SerializeField] bool isGameActive = true;
    [SerializeField] Transform[] spawnPoints;

    private void Start()
    {
        StartCoroutine(SpawnCars());
    }

    IEnumerator SpawnCars()
    {
        while(isGameActive == true)
        {
            int randomIndx = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[randomIndx];
            GameObject spawnedCar = Instantiate(carObject, spawnPoint.position, spawnPoint.rotation);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
