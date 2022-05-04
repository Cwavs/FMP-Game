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
        rand = Random.Range(0, goals.Length - 1);
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(goals[rand].position);
        oldGoal = rand;
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
        if(other.tag == "Goal")
        {
            rand = randomGoal();
            agent.SetDestination(goals[rand].position);
            oldGoal = rand;

        }
    }

    public void OnHit()
    {
        Destroy(gameObject);
    }

    public int randomGoal()
    {
        rand = Random.Range(0, goals.Length - 1);
        if(rand == oldGoal)
        {
            rand = randomGoal();
        }
        return rand;
    }
}
