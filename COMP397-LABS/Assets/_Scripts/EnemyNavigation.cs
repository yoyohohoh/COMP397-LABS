using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigation : MonoBehaviour
{
    [SerializeField] private List<Transform> _points;
    [SerializeField] private Transform _player;
    [SerializeField] private int _index = 0;
    [SerializeField] private LayerMask _mask;
    [SerializeField] private int _viewDistance = 10;
    [SerializeField] private Vector3 _destination;
    NavMeshAgent _agent;
    EnemyEnums _enemyState;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _enemyState = EnemyEnums.Patrolling;
        _destination = _points[_index].position;
        _agent.destination = _destination;
    }

    private void Update()
    {
        if (_enemyState == EnemyEnums.Chasing)
        {
            _destination = _player.position;
            _agent.destination = _destination;
        }
        else
        {
            if (Vector3.Distance(_destination, _agent.transform.position) < 1.0f)
            {
                _index = (_index + 1) % _points.Count;
                _destination = _points[_index].position;
                _agent.destination = _destination;
            }

            // loop through the points by getting the remainder
            // (e.g. 4 points in the list, when 4th % 4 = 0, 5th % 4 = 1, 6th % 4 = 2, 7th % 4 = 3, 8th % 4 = 0 ...)s
        }

    }
    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, _viewDistance, _mask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
            if (hit.transform.gameObject.name.Equals("Player"))
            {
                Debug.Log($"Change destination to {hit.transform.gameObject.name}");
                _enemyState = EnemyEnums.Chasing;
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * _viewDistance, Color.yellow);
            Debug.Log("I hit NOTHING");
        }
    }

}
