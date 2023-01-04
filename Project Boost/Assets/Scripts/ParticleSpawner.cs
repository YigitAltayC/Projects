using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    public static void SpawnParticle(Transform targetPosition, ParticleSystem particleSystem)
    {
        Instantiate(particleSystem.gameObject, targetPosition);
    }
}
