using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibility : PowerUpBase
{
    [SerializeField] Material _currentlyPoweredMat;
    Material[] _originalMat = new Material[4];
    MeshRenderer[] _mesh;
    Collider playerCol;

    protected override void PowerUp(Player player)
    {
        _mesh = player.GetComponentsInChildren<MeshRenderer>();

        player._invincible = true;

        for (int i = 0; i < _mesh.Length; i++)
        {
            _originalMat[i] = _mesh[i].material;
        }

        for (int i = 0; i < _originalMat.Length; i++) 
        {
            _mesh[i].material = _currentlyPoweredMat;
        }
        
    }

    protected override void PowerDown(Player player)
    {

        player._invincible = false;

        for (int i = 0; i < _originalMat.Length; i++)
        {
            _mesh[i].material = _originalMat[i];
        }
    }
}
