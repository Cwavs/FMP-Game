using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ai : MonoBehaviour
{
	private NavMeshAgent agent;
	public Transform[] goals;
    private int oldGoal;
    private int rand;
	
    // Start is called before the first frame update
    void Start()
    {
		agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(goals[0].position);
        oldGoal = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            rand = Random.Range(0, goals.Length - 1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        print("T");
        if(other.tag == "Goal")
        {
            print("T2");
            rand = Random.Range(0, goals.Length - 1);
            if(rand == oldGoal)
            {
                if(rand == 0)
                {
                    rand++;
                }
                else
                {
                    rand--;
                }
            }else
            {
                agent.SetDestination(goals[rand].position);
                oldGoal = rand;
            }
        }
    }
}
