using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Lab4MoveTarget : MonoBehaviour
{
    public Transform Target;
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame

    void Update()
    {
        if (Target != null)
        {
            agent.SetDestination(Target.position);
        }   
    }
}
