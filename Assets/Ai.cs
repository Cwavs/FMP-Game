using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ai : MonoBehaviour
{
	private NavMeshAgent agent;
	public Transform[] goals;
	
    // Start is called before the first frame update
    void Start()
    {
		agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(goals[0].position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Goal")
        {
            int goalAmount = goals.Length;
            int rand = Random.Range(0, goalAmount-1);
            agent.SetDestination(goals[rand].position);
        }
    }
}
