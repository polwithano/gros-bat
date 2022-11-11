using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField]
    private float colliderSphereRadius = 3f;
    [SerializeField]
    private LayerMask ballMask;

    [Header("Ball")]
    [SerializeField]
    private Color ballColorGradientA;
    [SerializeField]
    private Color ballColorGradientB;

    private void Start()
    {
        
    }

    private void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(gameObject.GetComponent<Transform>().position, colliderSphereRadius, ballMask); 
        foreach (var hitCollider in hitColliders)
        {
            Transform ball = hitCollider.GetComponent<Transform>();
            float distance = Vector3.Distance(ball.position, transform.position);
            Color distanceGradient = Color.Lerp(ballColorGradientA, ballColorGradientB, distance / colliderSphereRadius);
            Material ballMaterial = ball.gameObject.GetComponent<MeshRenderer>().material;
            ballMaterial.color = distanceGradient;
        }
    }

    private void OnDrawGizmos()
    {
        // Ball collider sphere radius
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(gameObject.GetComponent<Transform>().position, colliderSphereRadius); 
    }
}
