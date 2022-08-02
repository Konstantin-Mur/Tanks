using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : ShotableTank
{
    private float _timer;
    [SerializeField] public int _cartridges = 20;
    [SerializeField] public int _maxPlayerHP = 30;
    [SerializeField] protected HealsBar _healsBar;

    protected override void Start()
    {
        base.Start();
        _currentHeart = _maxPlayerHP;
        _ui.UpdateHp(_currentHeart);
        _ui.UpdateRpunds(_cartridges);
        _ui.UpdateTankSpeed((int)_movementSpeed);
        _healsBar.SetHealthValue(_maxHeart, _maxHeart);
    }
    protected override void Move()
    {
        Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _rigidbody.velocity = direction.normalized * _movementSpeed;
    }

    public override void TakeDamage(int damage)
    {
        _currentHeart -= damage;
        _healsBar.SetHealthValue(_currentHeart, _maxHeart);
        _ui.UpdateHp(_currentHeart);
        if (_currentHeart <= 0)
        {
            Stats.ResetAllStats();
            _ui.UpdateHp(_maxHeart);

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    // Update is called once per frame
    void Update()
    {
        Move();
        SetAngle(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        if (_timer <= 0)
        {
            if (Input.GetMouseButton(0) & _cartridges>0)
            {
                _cartridges--;
                _ui.UpdateRpunds(_cartridges);
                Shoot();
                _timer = _reloadTime;
            }
        }
        else
        {
            _timer -= Time.deltaTime;
        }

    }

    public void UpdateСartridges(int cartridges)
    {
        _cartridges += cartridges;
    }
   public void TakeBox(GameObject gameObject)
    {
        var heal = FindObjectOfType<Heal>();
        var cartridger = FindObjectOfType<Сartridges>();
        var bigHeart = FindObjectOfType<BigHeart>();
        var bigСartridges = FindObjectOfType<BigСartridges>();
        var speedBox = FindObjectOfType<SpeedBox>();
        if (heal != null)
        {
            _currentHeart += 5;
            _ui.UpdateHp(_currentHeart);
        }
        if (cartridger != null)
        {
            _cartridges += 10;
            if (_cartridges>50)
            {
                _cartridges = 50;
            }
            _ui.UpdateRpunds(_cartridges);
        }
        if (bigHeart != null)
        {
            _currentHeart += 10;
            _ui.UpdateHp(_currentHeart);
            //Destroy(x);
        }
        if (bigСartridges != null)
        {
            _cartridges += 20;
            if (_cartridges > 50)
            {
                _cartridges = 50;
            }
            _ui.UpdateRpunds(_cartridges);
            //Destroy(x);
        }
        if (speedBox != null)
        {
            _movementSpeed += 4;
            _rotationSpeed += 4;
            _ui.UpdateTankSpeed((int)_movementSpeed);
            //Destroy(x);
        }
    }
}
