using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform player;

    private void Update()
    {
        GetComponent<NavMeshAgent>().SetDestination(player.position);
    }
}
