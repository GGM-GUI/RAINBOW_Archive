using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMobSpawner : MonoBehaviour
{
    public float spawnDelay = 10f;

    private Transform player;

    public GameObject mobPrefab;
    public GameObject blinkerPrefab;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        StartCoroutine(SpawnTreeMob());
    }

    IEnumerator SpawnTreeMob()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);
            GameObject blinker = Instantiate(blinkerPrefab, player.position, Quaternion.identity);

            blinker.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            blinker.SetActive(false);
            yield return new WaitForSeconds(0.2f);
            blinker.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            blinker.SetActive(false);
            yield return new WaitForSeconds(0.2f);
            blinker.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            Destroy(blinker);

            GameObject newMob = Instantiate(mobPrefab, blinker.transform.position, Quaternion.identity);

            newMob.SetActive(true);  // 활성화합니다.

            yield return new WaitForSeconds(2.8f);
            Destroy(newMob);
        }
    }
}
