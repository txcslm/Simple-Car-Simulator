using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color(1, 1, 1, 1);
    [SerializeField] private float _destroyDelay = 0.2f;

    private bool _hasPackage;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Package" && _hasPackage == false)
        {
            Debug.Log("Picked Up!");
            _hasPackage = true;
            _spriteRenderer.color = hasPackageColor;
            Destroy(collision.gameObject, _destroyDelay);
        }

        if (collision.tag == "Customer" && _hasPackage)
        {
            Debug.Log("Delivered!");
            _hasPackage = false;
            _spriteRenderer.color = noPackageColor;
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Ouch!");
    }
}