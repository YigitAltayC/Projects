using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{

    [SerializeField] private ParticleSystem explosionParticle;
    
    // Sahne geçişi yaparken collision detectlemeyi engelle
    private void OnCollisionEnter(Collision collision)
    {
        if(!Player.Instance.IsAlive)
            return;
        
        switch (collision.gameObject.tag)
        {
            
            case "Finish Pad":
                AudioManager.Instance.PlaySound(GameSFX.WinSFX);
                break;
            case "Fuel":
                AudioManager.Instance.PlaySound(GameSFX.PickupSFX);
                break;
            case "Launch Pad":
                return;
            default:
                AudioManager.Instance.PlaySound(GameSFX.PlayerDeathSFX);
                ParticleSpawner.SpawnParticle(transform, explosionParticle);
                break;
            
        }

        Player.Instance.IsAlive = false;
        Player.Instance.enabled = false;
    }
    
    
}
