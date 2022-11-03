using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(Enemy))]
[RequireComponent(typeof(SpriteRenderer))]
public class Patrol : MonoBehaviour
{
    [SerializeField] private PatrolPointCollector _patrolPointsCollector;

    private SpriteRenderer _spriteRenderer;
    private Enemy _enemy;

    private List<PatrolPoint> _patrolPoints;

    private PatrolPoint _currentTarget;

    public bool IsWalking { get; private set; }

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _enemy = GetComponent<Enemy>();
    }

    private void Start()
    {
        _patrolPoints = _patrolPointsCollector.PatrolPoints.ToList();

        _currentTarget = SelectPatrolPoint();

        StartCoroutine(MoveToSelectedPoint());
    }

    private IEnumerator MoveToSelectedPoint()
    {
        var waitingTimeAfterCompleteTarget = new WaitForSeconds(2);

        while (true)
        {
            _spriteRenderer.flipX = transform.position.x < _currentTarget.transform.position.x;
            
            while(Vector3.Distance(transform.position , _currentTarget.transform.position) > 0.5f)
            {
                transform.position = Vector3.MoveTowards(transform.position, _currentTarget.transform.position, _enemy.Speed * Time.deltaTime);

                IsWalking = true;
                
                yield return null;
            }

            IsWalking = false;

            yield return waitingTimeAfterCompleteTarget;

            _currentTarget = SelectPatrolPoint();
        }
    }

    private PatrolPoint SelectPatrolPoint()
    {
        int randomPatrolPointNumber = Random.Range(0, _patrolPoints.Count);

        return _patrolPoints[randomPatrolPointNumber];
    }
}
