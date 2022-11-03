using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenedChest : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;

    [SerializeField] private int _coinsNumber;

    private float _pushforce = 5f;
    private float _maxLeftCoinPushForce = 1f;

    private void OnEnable()
    {
        StartCoroutine(SpawnCoins());
    }

    private IEnumerator SpawnCoins()
    {
        for (int i = 0; i < _coinsNumber; i++)
        {
            var createdCoin = Instantiate(_coinPrefab.gameObject, transform.position, Quaternion.identity, gameObject.transform);

            PushCoin(createdCoin);
            
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void PushCoin(GameObject coin)
    {
        coin.GetComponent<Rigidbody2D>().AddForce(Vector2.up * _pushforce, ForceMode2D.Impulse);
        coin.GetComponent<Rigidbody2D>().AddForce(Vector2.left * Random.Range(0, _maxLeftCoinPushForce), ForceMode2D.Impulse);
    }
}
