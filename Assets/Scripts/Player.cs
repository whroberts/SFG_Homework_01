using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int _maxHealth = 3;
    [SerializeField] int _currentTreasureCount = 0;

    int _currentHealth;

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
    }

    void Update()
    {

    }

    public void IncreaseHealth(int amount)
    {
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
        Debug.Log("Player's health: " + _currentHealth);
    }

    public void DecreaseHealth(int amount)
    {
        _currentHealth -= amount;
        Debug.Log("Player's health: " + _currentHealth);

        if (_currentHealth <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        gameObject.SetActive(false);
        //particles
        //sound
    }

    public void CollectTreasure(int value)
    {
        CurrentTreasureCount += value;
        _ui.SetCount();
    }
}
