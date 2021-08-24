using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject playerGO;

    private void Update()
    {
        GetComponent<NavMeshAgent>().SetDestination(player.position);
    }
}
