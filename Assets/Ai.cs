using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ai : MonoBehaviour
{
	private NavMeshAgent agent;
	public Transform goal;
	private Vector3 oldgoal;
	
    // Start is called before the first frame update
    void Start()
    {
		agent = GetComponent<NavMeshAgent>();
		
    }

    // Update is called once per frame
    void Update()
    {
		if(goal.position != oldgoal)
		{
			agent.SetDestination(goal.position);
			oldgoal = goal.position;
		}
    }
}
