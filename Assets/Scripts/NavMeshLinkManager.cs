using Unity.AI.Navigation;
using UnityEngine;

public class NavMeshLinkManager : MonoBehaviour
{
    [SerializeField] private Transform startPosition, endPosition;
    private NavMeshLink navMeshLink;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navMeshLink = GetComponent<NavMeshLink>();
    }

    // Update is called once per frame
    void Update()
    {
        navMeshLink.startPoint = startPosition.position;
        navMeshLink.endPoint = endPosition.position;
    }
}
