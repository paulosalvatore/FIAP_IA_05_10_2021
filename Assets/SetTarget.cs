using System;
using UnityEngine;
using UnityEngine.AI;
public class SetTarget : MonoBehaviour
{
    [Header("Config")]
    [SerializeField]
    private Transform target;

    [Header("Components")]
    [SerializeField]
    private NavMeshAgent navMeshAgent;

    private void Update()
    {
        navMeshAgent.destination = target.position;
    }
}
