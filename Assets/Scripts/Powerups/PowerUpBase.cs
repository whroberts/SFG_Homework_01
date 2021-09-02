using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpBase : MonoBehaviour
{
    protected abstract void PowerUp(Player player);
    protected abstract void PowerDown(Player player);

    [SerializeField] float _powerupDuration = 3f;
    [SerializeField] ParticleSystem _impactParticles;
    [SerializeField] AudioClip _impactSound;

    Collider _col;
    MeshRenderer _mesh;

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();

        if (player != null)
        {
            StartCoroutine(PowerUpDuration(player));

            Feedback(false);
        }
    }

    private IEnumerator PowerUpDuration(Player player)
    {
        PowerUp(player);
        Feedback(false);
        yield return new WaitForSeconds(_powerupDuration);
        StartCoroutine(PowerDownDuration(player));
    }

    private IEnumerator PowerDownDuration(Player player)
    {
        PowerDown(player);
        yield return new WaitForSeconds(_powerupDuration);
        Feedback(true);
    }

    private void Feedback(bool state)
    {
        _col = GetComponent<Collider>();
        _mesh = GetComponent<MeshRenderer>();

        if (state)
        {
            Destroy(gameObject);
        }
        else if (!state)
        {
            _col.enabled = false;
            _mesh.enabled = false;

            //particles
            if (_impactParticles != null)
            {
                _impactParticles = Instantiate(_impactParticles, transform.position, Quaternion.identity);
            }

            // audio. TODO - consider Object Pooling for performance

            if (_impactSound != null)
            {
                AudioHelper.PlayClip2D(_impactSound, 1f);
            }
        }
    }
}
