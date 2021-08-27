using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float damage;
    [SerializeField] Vector3 offset;

    private void Update()
    {
        GetComponent<NavMeshAgent>().SetDestination(player.position + offset);
    }

    private void OnTriggerEnter(Collider other)
    {
            if (other.CompareTag("Player"))
            {
                player.GetComponent<PlayerTakeDamage>().DamageHealth(damage);
            }
    }
}
