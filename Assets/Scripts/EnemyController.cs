using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float damage;
    [SerializeField] Vector3 offset;
    [SerializeField] private float range;

    private void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);


        if (distance < range)
        {
            GetComponent<NavMeshAgent>().SetDestination(player.position + offset);
        }       
        
    }

    private void OnTriggerEnter(Collider other)
    {
            if (other.CompareTag("Player"))
            {
                player.GetComponent<PlayerTakeDamage>().DamageHealth(damage);
            }
    }
}
