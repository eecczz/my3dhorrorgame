using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    private NavMeshAgent ai;
    private Animator anim;
    [SerializeField] private Transform _player;
    private void Awake()
    {
        ai = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        ai.SetDestination(_player.position);
        anim.SetBool("isStopped", ai.remainingDistance<=5);
    }
}
