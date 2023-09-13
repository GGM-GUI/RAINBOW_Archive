using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcornCounting : MonoBehaviour
{
    bool TP = false;
    [SerializeField] private GameObject player;
    void Update()
    {
        if(Acorn.ACOCount == 2 && TP == false)
        {
            player.transform.position = new Vector3(-121.4f, -37.39f, 0);
            TP = true;
        }
    }
}
