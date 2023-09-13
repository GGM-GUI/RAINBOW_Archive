using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBallVisual : MonoBehaviour
{
    [SerializeField] private Transform bulletCollider;
    void Update()
    {
        transform.position = bulletCollider.transform.position;
    }
}
