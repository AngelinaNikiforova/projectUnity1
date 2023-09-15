using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyAI : MonoBehaviour
    {
        public Transform target;            // The target to move towards
        private NavMeshAgent navMeshAgent;  // Reference to the NavMesh Agent component

        private void Start()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            if (navMeshAgent == null)
            {
                Debug.LogError("NavMeshAgent component not found on the enemy.");
                enabled = false;
                return;
            }

            if (target == null)
            {
                Debug.LogError("Target is not assigned to the EnemyAI script.");
                enabled = false;
                return;
            }

            // Set the initial target
            SetTargetPosition(target.position);
        }

        private void Update()
        {
            // Update the NavMesh Agent's destination to the target's position
            SetTargetPosition(target.position);
        }

        private void SetTargetPosition(Vector3 position)
        {
            NavMeshHit navMeshHit;

            // Try to find a valid position on the navigation mesh closest to the target
            if (NavMesh.SamplePosition(position, out navMeshHit, navMeshAgent.height * 2, NavMesh.AllAreas))
            {
                // Set the NavMesh Agent's destination to the valid position
                navMeshAgent.SetDestination(navMeshHit.position);
            }
        }
    }
}