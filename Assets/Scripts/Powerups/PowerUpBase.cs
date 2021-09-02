using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpBase : MonoBehaviour
{
    protected abstract void PowerUp(Player player);
    protected abstract void PowerDown(Player player);

    [SerializeField] float _powerupDuration = 2f;

    Collider _col;
    MeshRenderer _mesh;

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();

        if (player != null)
        {
            PowerUp(player);

            Feedback(false);
        }
    }

    private void Feedback(bool state)
    {
        _col = GetComponent<Collider>();
        _mesh = GetComponent<MeshRenderer>();

        if (state)
        {
            _col.enabled = true;
            _mesh.enabled = true;
        }
        else if (!state)
        {
            
        }
    }
}
