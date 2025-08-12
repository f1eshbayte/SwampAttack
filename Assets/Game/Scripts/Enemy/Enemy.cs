using System;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward;
    [SerializeField] private float _durationAfterDeath;

    private Player _target;

    private float _time = 0;
    public int Reward => _reward;
    public Player Target => _target;

    public event UnityAction<Enemy> Dying;

    private void Update()
    {
        _time += Time.deltaTime;
    }

    public void Init(Player target)
    {
        _target = target;
    }

    public void TakeDagame(int damage)
    {
        _health -= damage;

        DetectDie();
    }

    private void DetectDie()
    {
        if (_health <= 0)
        {
            Dying?.Invoke(this);
            Destroy(gameObject, _durationAfterDeath);
        }
    }
}