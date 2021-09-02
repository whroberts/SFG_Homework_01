using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int _maxHealth = 3;
    [SerializeField] int _currentTreasureCount = 0;

    public int _currentHealth;
    public bool _invincible;

    public int CurrentTreasureCount
    {
        get => _currentTreasureCount;
        set => _currentTreasureCount = value;
    }
    UIController _ui;

    TankController _tankController;

    private void Awake()
    {
        _tankController = GetComponent<TankController>();
        _ui = FindObjectOfType<UIController>();
    }
    void Start()
    {
        _currentHealth = _maxHealth;
        _ui.SetHealth();
    }

    void Update()
    {

    }

    public void IncreaseHealth(int amount)
    {
        _currentHealth += amount;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
        Debug.Log("Player's health: " + _currentHealth);
        _ui.SetHealth();
    }

    public void DecreaseHealth(int amount)
    {
        if (!_invincible)
        {
            _currentHealth -= amount;
            Debug.Log("Player's health: " + _currentHealth);
            _ui.SetHealth();
            if (_currentHealth <= 0)
            {
                Kill();
            }
        }
    }

    public void Kill()
    {
        if (!_invincible)
        {
            gameObject.SetActive(false);
            //particles
            //sound
        }
    }

    public void CollectTreasure(int value)
    {
        CurrentTreasureCount += value;
        _ui.SetCount();
    }
}
