using UnityEngine;

public class AutomaticRifle : Weapon
{
    public override void Shoot(Transform shootPoint)
    {
        Instantiate(Bullet, shootPoint.position,Quaternion.Euler(0, 0, 90));
    }
}
