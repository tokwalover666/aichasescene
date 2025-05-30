using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 
public class AIRoam : MonoBehaviour 
{
    public NavMeshAgent AI;
    public float range;

    public Transform ground; 
    void Start()
    {
        AI = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        if (AI.remainingDistance <= AI.stoppingDistance)
        {
            Vector3 point;
            if (RandomPoint(ground.position, range, out point)) 
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); 
                AI.SetDestination(point);
            }
        }

    }
    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {

        Vector3 randomPoint = center + Random.insideUnitSphere * range; 
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) 
        {
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }


}