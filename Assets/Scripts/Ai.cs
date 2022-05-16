using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ai : MonoBehaviour
{
	private NavMeshAgent agent;
	public Transform[] goals;
	private Vector3 oldgoal;
	
    // Start is called before the first frame update
    void Start()
    {
		agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(pickRandomGoal());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        agent.SetDestination(pickRandomGoal());
    }

    private Vector3 pickRandomGoal()
    {
        int rand = Random.Range(0, goals.Length - 1);
        Vector3 goal = goals[rand].position;
        if(goal == oldgoal)
        {
            goal = pickRandomGoal();
        } 
        oldgoal = goal;
        return goal;
    }
}
