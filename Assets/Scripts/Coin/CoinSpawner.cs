using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class CoinSpawner : MonoBehaviour {

    // Prefab for coin
    public GameObject Coin;

    int _chapterState;

    // First coin of each chapter
    public List<Transform> FirstCoin, FinalGate;
    public List<int> spawnQuantity;

    // Spawn distance between coins and the quantity of coins to be spawned from a chapter
    public float spawnDistance = 8;

    private void Awake() {

        for (int i = 0; i < 15; i++) {

            GameObject pooledCoin = Instantiate(Coin, transform.position, Quaternion.identity);
            pooledCoin.SetActive(false);
            FindObjectOfType<Manager>().CoinPool.Add(pooledCoin);
        }

        _chapterState= 1;

        spawnQuantity.Add(11);
        // Spawn quantity
        for (int i = 1; i < 8; i++) {
            spawnQuantity.Add(Mathf.FloorToInt(Vector3.Distance(FirstCoin[i].position, FinalGate[i].position) / spawnDistance));
        }
        //StartCoroutine(StarterSpawn());
    }

    // Update for chapter state
    private void Update() {

        
    }

    // When gameobject is enabled on the scene
    private void OnEnable() {

        SpawnCoin();
    }

    //IEnumerator StarterSpawn() {
    //    yield return new WaitForSeconds(.5f);
    //    // Start level spawner
    //    if (gameObject.tag == "StartLevel") {
    //        SpawnCoin();
    //    }
    //}

    public void SpawnCoin() {

        GameObject coin;
        _chapterState = FindObjectOfType<Manager>().ChapterState;

        for (int i = 0; i < spawnQuantity[_chapterState - 1]; i++) {

            // Find an inactive coin in the object pool, if there are sufficient coins in the pool
            if (FindObjectOfType<Manager>().CoinPool.Count !=0) {
                coin = FindObjectOfType<Manager>().CoinPool.FirstOrDefault();
                FindObjectOfType<Manager>().CoinPool.Remove(coin);
                coin.SetActive(true);
            }
            else {
                coin = Instantiate(Coin);
            }

            Vector3 lastposition = FirstCoin[_chapterState - 1].position;
            // coin spawn transform
            coin.transform.position = new Vector3(((_chapterState - 1) * 50 + Random.Range(-4, 5)), 0.5f, lastposition.z) + Vector3.forward * (i + 1) * spawnDistance;
        }
    }

    // Horizontal transform generator, returns a random x transform which the coin is spawned.
    //public float RandomHorizontalPlaceGenerator() {

    //    float random = Random.Range(-4, 4);
    //    return random;
    //}




}
