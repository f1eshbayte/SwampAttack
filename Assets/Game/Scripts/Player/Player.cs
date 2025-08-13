using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Transform _shootPoint;

    private Weapon _currentWeapon;
    private int _currentWeaponNumber = 0;
    private int _currentHealth;

    public int Money { get; private set; }

    public event UnityAction<int, int> HealthChanged; 
    public event UnityAction<int> MoneyChanged; 
    
    private void Start()
    {
        ChangedWeapon(_weapons[_currentWeaponNumber]);
        _currentHealth = _maxHealth;
    }

    private void Update()
    {
        _currentWeapon.HandleShooting(_shootPoint);
    }

    public void BuyWeapon(Weapon weapon)
    {
        Money -= weapon.Price;
        MoneyChanged?.Invoke(Money);
        _weapons.Add(weapon);
    }

    public void AddMoney(int money)
    {
        Money += money;
        MoneyChanged?.Invoke(Money);
    }
    
    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth, _maxHealth);
        
        if (_currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void NextWeapon()
    {
        if (_currentWeaponNumber == _weapons.Count - 1)
            _currentWeaponNumber = 0;
        else
            _currentWeaponNumber++;
        
        ChangedWeapon(_weapons[_currentWeaponNumber]);
    }

    public void PreviousWeapon()
    {
        if (_currentWeaponNumber == 0)
            _currentWeaponNumber = _weapons.Count - 1;
        else
            _currentWeaponNumber--;
        
        ChangedWeapon(_weapons[_currentWeaponNumber]);
    }

    private void ChangedWeapon(Weapon weapon)
    {
        _currentWeapon = weapon;
    }
}