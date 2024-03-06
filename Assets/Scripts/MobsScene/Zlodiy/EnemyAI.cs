using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> patrolPoints;
    public PlayerController player;
    public float viewAngle;

    private NavMeshAgent _navMeshAgent;
    bool isPlayer;

    void Start()
    {
        InitComponentLinks();
    }

    void Update()
    {
        PatrolUpdate();
        NoticePlayerUpdate();
        ChaseUpdate();
    }

    private void InitComponentLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();

    }
    private void PatrolUpdate()
    {
        if (!isPlayer && _navMeshAgent.remainingDistance == 0)
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
}
