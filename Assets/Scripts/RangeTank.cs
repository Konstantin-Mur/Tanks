using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeTank : ShotableTank
{
    [SerializeField] private float _distanceToPlayer = 5f;
    private float _timer;
    private Transform _target;
    protected override void Move()
    {
        transform.Translate(Vector2.down * _movementSpeed * Time.deltaTime);

    }
    protected override void Start()
    {
        base.Start();
        _target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        if (Vector2.Distance(transform.position, _target.position) > _distanceToPlayer)
        {
            Move();

        }
            SetAngle(_target.position);
        if (_timer <= 0)
        {
            Shoot();
            _timer = _reloadTime;
        }
        else
        {
            _timer -= Time.deltaTime;
        }
    }
}
