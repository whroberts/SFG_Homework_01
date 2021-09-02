using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class CollectibleBase : MonoBehaviour
{
    protected abstract void Collect(Player player);

    [SerializeField] float _movementSpeed = 1;
    protected float MovementSpeed => _movementSpeed;

    [SerializeField] ParticleSystem _collectParticles;
    [SerializeField] AudioClip _collectSound;

    Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Movement(_rb);
    }

    protected virtual void Movement(Rigidbody rb)
    {
        // calculate rotation

        Quaternion turnOffset = Quaternion.Euler(0, _movementSpeed, 0);
        rb.MoveRotation(_rb.rotation * turnOffset);
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();

        if (player != null)
        {
            Collect(player);

            //spawn particles & sfx because we need to disable object
            Feedback();

            gameObject.SetActive(false);
        }
    }

    private void Feedback()
    {
        // particles
        if (_collectParticles != null)
        {
            _collectParticles = Instantiate(_collectParticles, transform.position, Quaternion.identity);
        }

        //audio. TODO - consider Object Pooling for performance
        if (_collectSound != null)
        {
            AudioHelper.PlayClip2D(_collectSound, 1f);
        }
    }
}
