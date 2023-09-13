using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireSpawner : MonoBehaviour
{
    [SerializeField] private GameObject wireUpPrefab;
    [SerializeField] private GameObject wireRightPrefab;
    [SerializeField] private float wireNum;
    [SerializeField] private float wireCount;
    [SerializeField] private Transform[] WirePosUp;
    [SerializeField] private Transform[] WirePosRight;

    YellowBossDown yellowBossDown;
    IEnumerator enumerator;

    private void Start()
    {
        yellowBossDown = FindObjectOfType<YellowBossDown>();
        //yellowBossDown = GameObject.FindGameObjectWithTag("Boss").GetComponent<YellowBossDown>();
        enumerator = WireSpawn();
    }

    //private void Update()
    //{
    //    if (yellowBossDown == null)
    //    {
    //        yellowBossDown = GameObject.FindGameObjectWithTag("Boss").GetComponent<YellowBossDown>();
    //    }
    //}

    public void StartWireSpawn()
    {
        StartCoroutine(enumerator);
        Debug.Log("줄 스폰 시작");
    }

    public IEnumerator WireSpawn()
    {
        if (wireCount < wireNum)
        {
            int rand = Random.Range(0, 2);
            int rand2 = Random.Range(0, 2);
            GameObject clone = Instantiate(wireUpPrefab, WirePosUp[rand].position, Quaternion.identity);
            GameObject clone2 = Instantiate(wireRightPrefab, WirePosRight[rand2].position, wireRightPrefab.transform.rotation);
            Destroy(clone, 5);
            Destroy(clone2, 10);

            wireCount++;
            yield return new WaitForSeconds(2f);
            StartCoroutine(WireSpawn());
        }
        else
        {
            yield return new WaitForSeconds(4f);
            wireCount = 0;
            Debug.Log(yellowBossDown);
            //yellowBossDown.StartBossDown();
            StartCoroutine(yellowBossDown.BossDown());
        }
    }
}
