using UnityEngine;

public class AutomaticRifle : Weapon
{
    public override void Shoot(Transform shootPoint)
    {
        Instantiate(Bullet, shootPoint.position,shootPoint.rotation);
    
    }
}
