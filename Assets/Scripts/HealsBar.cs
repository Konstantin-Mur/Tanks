using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealsBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Vector3 offset;
    [SerializeField] public Transform _transform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        _slider.transform.position = _transform.position + offset;

    }
    public void SetHealthValue(int currentHealth, int maxHealth)
    {
        _slider.gameObject.SetActive(true);
        _slider.value = currentHealth;
        _slider.maxValue = maxHealth;
    }
}
