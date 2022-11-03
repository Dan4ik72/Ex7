using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosedChest : MonoBehaviour
{
    [SerializeField] OpenedChest _openedChestPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if(collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            Destroy(gameObject);
            Instantiate(_openedChestPrefab.gameObject, transform.position, Quaternion.identity);
        }
    }
}
