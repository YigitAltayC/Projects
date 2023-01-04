using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoSingleton<Player>
{
    [SerializeField] private float thrustForce;
    [SerializeField] private float thrustRotation;
    [SerializeField] private ParticleSystem thrustParticle;
    private Rigidbody _rigidbody;

    private bool isAlive = true;

    public bool IsAlive { get => isAlive; set => isAlive = value; }


    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        InputThrust();
        InputRotate();
    }

    private void InputThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
            
    }

    private void StopThrusting()
    {
        PlayerLook.Instance.DarkenSurfaceColor();
        AudioManager.Instance.StopSound();
        thrustParticle.Stop();
    }

    private void StartThrusting()
    {
        _rigidbody.AddRelativeForce(Vector3.up * thrustForce * Time.deltaTime);

        if (!AudioManager.Instance.IsSoundPlaying(GameSFX.PlayerFlySFX))
        {
            AudioManager.Instance.PlaySound(GameSFX.PlayerFlySFX);
        }

        PlayerLook.Instance.BrightenSurfaceColor();

        if (!thrustParticle.isPlaying)
        {
            thrustParticle.Play();
        }
    }

    private void InputRotate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(thrustRotation);

        } else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-thrustRotation);

        }
    }

    private void ApplyRotation(float rotationFrame)
    {
        _rigidbody.freezeRotation = true;   // This disables automatic rotations.
        
        transform.Rotate(Vector3.forward * rotationFrame * Time.deltaTime);
        
        _rigidbody.freezeRotation = false;  // This enables automatic rotations.

    }
}
