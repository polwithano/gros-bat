using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField]
    private float colliderSphereRadius = 3f;
    [SerializeField]
    private LayerMask ballMask; 

    private void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(gameObject.GetComponent<Transform>().position, colliderSphereRadius, ballMask); 
        foreach (var hitCollider in hitColliders)
        {
            hitCollider.GetComponent<Transform>().localScale = new Vector3(5, 5, 5); 
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(gameObject.GetComponent<Transform>().position, colliderSphereRadius); 
    }
}
