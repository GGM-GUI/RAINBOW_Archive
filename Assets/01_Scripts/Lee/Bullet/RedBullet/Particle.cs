using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    void Update() => Destroy(gameObject, 0.5f);
}
