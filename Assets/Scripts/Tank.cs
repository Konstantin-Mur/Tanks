using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D), typeof(AudioSource))]
public abstract class Tank : MonoBehaviour
{
    [SerializeField] public int _maxHeart = 30;
    [SerializeField] protected float _movementSpeed = 3f;
    [SerializeField] protected float _angleOffset = 90f;
    [SerializeField] protected float _rotationSpeed = 7f;
    [SerializeField] private int _points = 0;
    [SerializeField] private AudioSource audio;
    [SerializeField] private UnityEvent audioAndParticle;
    [SerializeField] private ParticleSystem paticle;
    [SerializeField] protected List<GameObject> _boxes;

    protected Rigidbody2D _rigidbody;
    protected int _currentHeart = 30;
    protected UI _ui;

    protected virtual void Start()
    {
        audio = GetComponent<AudioSource>();
        _currentHeart = _maxHeart;
        _rigidbody = GetComponent<Rigidbody2D>();
        _ui = GameObject.FindGameObjectWithTag("UI").GetComponent<UI>();
    }
   
    public virtual void TakeDamage(int damage)
    {
        _currentHeart-=damage;
        audioAndParticle.AddListener(paticle.Play);
        audioAndParticle.Invoke();
        if (_currentHeart<=0)
        {
            Stats.Score += _points;
            _ui.UpdateScoreAndlevel();
            Destroy(gameObject);
            if (Stats.Level < 2)
            {
                Instantiate(_boxes[Random.Range(0, 1)], this.transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(_boxes[Random.Range(0, 4)], this.transform.position, Quaternion.identity);
            }


        }
    }
    protected abstract void Move();

    protected void SetAngle(Vector3 target)
    {
        Vector3 deltaPosition = target - transform.position;
        float angleZ = Mathf.Atan2(deltaPosition.y,deltaPosition.x) * Mathf.Rad2Deg;
        Quaternion angle = Quaternion.Euler(0f,0f, angleZ+_angleOffset);
        transform.rotation = Quaternion.Lerp(transform.rotation, angle, Time.deltaTime * _rotationSpeed);
    }
}
