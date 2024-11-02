using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class PatrolBehavior : StateMachineBehaviour
{
    float timer;
    List<Transform> wayPoints = new List<Transform>();
    NavMeshAgent agent;
    Transform player;
    float ChaseRange = 15;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;

        GameObject wayPointsObject = GameObject.Find("WayPointsBlue");
        if (wayPointsObject != null)
        {
            foreach (Transform t in wayPointsObject.transform)
                wayPoints.Add(t);
        }

        // Initialize agent and player references
        agent = animator.GetComponent<NavMeshAgent>();
        if (agent != null && wayPoints.Count > 0)
        {
            if (agent.isOnNavMesh)
            {
                agent.SetDestination(wayPoints[0].position);
            }
        }

        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (wayPoints.Count > 0 && agent != null && agent.isOnNavMesh)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                int randomIndex = Random.Range(0, wayPoints.Count);
                agent.SetDestination(wayPoints[randomIndex].position);
            }
        }

        timer += Time.deltaTime;
        if (timer >= 10)
        {
            animator.SetBool("isPatrolling", false);
        }

        if (player != null)
        {
            float distance = Vector3.Distance(animator.transform.position, player.position);
            if (distance < ChaseRange)
            {
                animator.SetBool("isChasing", true);
            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (agent != null && agent.isOnNavMesh)
        {
            agent.SetDestination(agent.transform.position); // Stop the agent
        }
    }
}