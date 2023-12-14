using System.Collections.Generic;
using UnityEngine;

public class Targets : MonoBehaviour
{
    [SerializeField] List<Transform> childTargets = new List<Transform>();
    [Range(0,3)]
    [SerializeField] float gizmosSize = 2f;

    public Transform GetRandomTarget()
    {
        if (childTargets.Count == 0)
        {
            Debug.LogWarning("No targets available!");
            return null;
        }

        int randomIndex = Random.Range(0, childTargets.Count);
        return childTargets[randomIndex];
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        foreach (Transform t in childTargets)
        {
            Gizmos.DrawSphere(t.position, gizmosSize);
        }
    }
}
