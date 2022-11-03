using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private int _coins;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<Coin>(out Coin coin))
        {
            _coins++;            
        }
    }
}
