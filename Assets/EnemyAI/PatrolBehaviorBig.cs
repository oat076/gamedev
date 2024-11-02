using UnityEngine.AI;
using UnityEngine;
using System.Collections.Generic;

public class PatrolBehaviorBig : StateMachineBehaviour
{
    float timer;
    List<Transform> wayPoints = new List<Transform>();
    NavMeshAgent agent;
    Transform player;
    float ChaseRange = 15;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;

        // Find waypoints under the "WayPointsPurple" parent object
        GameObject wayPointsObject = GameObject.Find("WayPointsBig");
        if (wayPointsObject != null)
        {
            foreach (Transform t in wayPointsObject.transform)
                wayPoints.Add(t);
        }
        else
        {
            Debug.LogError("WayPointsPurple object not found!");
        }

        // Check if any waypoints were added
        if (wayPoints.Count == 0)
        {
            Debug.LogError("No waypoints found under WayPointsPurple!");
            return;
        }

        // Initialize agent and player references
        agent = animator.GetComponent<NavMeshAgent>();
        if (agent != null)
        {
            agent.SetDestination(wayPoints[0].position);
        }

        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        if (player == null)
        {
            Debug.LogError("Player object not found.");
        }
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (wayPoints.Count > 0 && agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)].position);
        }

        timer += Time.deltaTime;
        if (timer > 10)
            animator.SetBool("isPatrolling", false);

        if (player != null)
        {
            float distance = Vector3.Distance(animator.transform.position, player.position);
            if (distance < ChaseRange)
                animator.SetBool("isChasing", true);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (agent != null)
        {
            agent.SetDestination(agent.transform.position);
        }
    }
}
