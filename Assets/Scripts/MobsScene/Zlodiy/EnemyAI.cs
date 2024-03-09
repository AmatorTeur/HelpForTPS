using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> patrolPoints;
    public PlayerController player;
    public float viewAngle;
    public float damage = 10;

    private NavMeshAgent _navMeshAgent;
    bool isPlayer;
    private PlayerHealth _playerHealth;

    void Start()
    {
        InitComponentLinks();
        PickNewPatrolPoint();
    }

    void Update()
    {
        PatrolUpdate();
        NoticePlayerUpdate();
        ChaseUpdate();
        AttackUpdate();
    }

    private void InitComponentLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _playerHealth = player.GetComponent<PlayerHealth>();

    }
    private void PatrolUpdate()
    {
        if (!isPlayer &&_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
        {
                PickNewPatrolPoint();

        }

    }
    private void PickNewPatrolPoint()
    {
        _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;

    }

    private void NoticePlayerUpdate()
    {
        var direction = player.transform.position - transform.position;
        isPlayer = false;
        if (Vector3.Angle(transform.forward, direction) < viewAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit) && hit.collider.gameObject == player.gameObject)
            {
                isPlayer = true;
            }
        }
    }

    private void ChaseUpdate()
    {
        if (isPlayer) _navMeshAgent.destination = player.transform.position;
    }

    private void AttackUpdate()
    {
        if(isPlayer && _navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
        {
            _playerHealth.TakeDamage(damage * Time.deltaTime);

        }
    }
}
