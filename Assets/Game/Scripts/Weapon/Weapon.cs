using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private string _label;
    [SerializeField] private int _price;
    [SerializeField] private Sprite _icon;
    [SerializeField] protected Bullet Bullet;
    [SerializeField] private bool _isBuyed = false;
    [SerializeField] private bool _isAutomatic = false;
    [SerializeField] private float _fireRate;

    private float _nextFireTime;
    
    public string Label => _label;
    public int Price => _price;
    public Sprite Icon => _icon;
    public bool IsBuyed => _isBuyed;
    public bool IsAutomatic => _isAutomatic; 
    
    public abstract void Shoot(Transform shootPoint);

    public virtual void HandleShooting(Transform shootPoint)
    {
        if (_isAutomatic)
        {
            if (Input.GetMouseButton(0) && Time.time >= _nextFireTime)
            {
                Shoot(shootPoint);
                _nextFireTime = Time.time + _fireRate;
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shoot(shootPoint);
            }
        }
    }
    public void Buy()
    {
        _isBuyed = true;
    }
}
