using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] private float _steerSpeed = 300f;
    [SerializeField] private float _moveSpeed = 20f;
    [SerializeField] private float _boostSpeed = 30f;
    [SerializeField] private float _slowSpeed = 15f;

    private void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * _steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * _moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Booster")
        {
            _moveSpeed = _boostSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _moveSpeed = _slowSpeed;
    }
}