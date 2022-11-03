using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GroundChecker : MonoBehaviour
{
    public UnityEvent GroundOff;
    public UnityEvent Landed;

    [SerializeField] private LayerMask _ground;

    private readonly int _groundLayerNumber = 6;

    public bool IsOnGround { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == _groundLayerNumber)
        {
            if (IsOnGround == false)
                Landed.Invoke();

            IsOnGround = true;   
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.layer == _groundLayerNumber)
        {
            IsOnGround = false;
            GroundOff.Invoke();            
        }
    }
}
