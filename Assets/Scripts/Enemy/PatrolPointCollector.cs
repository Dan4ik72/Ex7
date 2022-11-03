using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PatrolPointCollector : MonoBehaviour
{
    private List<PatrolPoint> _patrolPoints;

    public IReadOnlyList<PatrolPoint> PatrolPoints => _patrolPoints; 

    private void Awake()
    {
        _patrolPoints = GetComponentsInChildren<PatrolPoint>().ToList();
    }
}
