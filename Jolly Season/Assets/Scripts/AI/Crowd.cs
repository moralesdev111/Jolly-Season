using UnityEngine;
using UnityEngine.AI;

public class Crowd : MonoBehaviour
{
    [SerializeField] Targets targets;
    [SerializeField] NavMeshAgent navMeshAgent;

    void Start()
    {
        if (targets == null)
        {
            Debug.LogError("Targets reference not set in the Inspector!");
            return;
        }

        FindTarget();
    }

    void Update()
    {
        if (navMeshAgent == null || targets == null)
            return;

        if (navMeshAgent.remainingDistance < 0.2f)
        {
            FindTarget();
        }
    }

    private void FindTarget()
    {
        Transform randomTarget = targets.GetRandomTarget();

        if (randomTarget != null)
        {
            navMeshAgent.SetDestination(randomTarget.position);
        }
    }
}
