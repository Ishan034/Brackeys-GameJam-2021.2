using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float damage;

    private void Update()
    {
        GetComponent<NavMeshAgent>().SetDestination(player.position);

        if (transform.position == player.position)
        {
            AttackPlayer();
        }
    }

    private void AttackPlayer()
    {
        player.GetComponent<PlayerTakeDamage>().DamageHealth(damage);
    }
}
