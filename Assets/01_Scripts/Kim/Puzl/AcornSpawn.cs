using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcornSpawn : MonoBehaviour
{
    [SerializeField] private GameObject _acorn;
    public bool isClearAcorn = false;

    private PuzlBottonManager puzlbottonManager;
    private bool drop = true;

    void Start()
    {
        puzlbottonManager = FindObjectOfType<PuzlBottonManager>();
    }
    void Update()
    {
        if (puzlbottonManager.isAcornSpawn == true)
        {
            if (drop == true)
            {
                drop = false;
                Instantiate(_acorn, transform.position, Quaternion.identity);
            }
        }
    }
}
