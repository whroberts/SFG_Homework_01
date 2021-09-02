using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] Player _player;
    [SerializeField] TMP_Text _treasureCount;
    [SerializeField] TMP_Text _healthValue;

    public void SetCount()
    {
        _treasureCount.text = _player.CurrentTreasureCount.ToString();
    }

    public void SetHealth()
    {
        _healthValue.text = _player._currentHealth.ToString();
    }
}
