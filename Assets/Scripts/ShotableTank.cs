using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ShotableTank : Tank
{
    [SerializeField] private GameObject _projectile;
    [SerializeField] private Transform _shotPoint;
    [SerializeField] protected float _reloadTime = 1.5f;

    protected override void Start()
    {
        base.Start();
    }
    protected void Shoot()
    {
        Instantiate(_projectile, _shotPoint.position, transform.rotation);
    }
    
}
