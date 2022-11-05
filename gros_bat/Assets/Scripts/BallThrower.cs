using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallThrower : MonoBehaviour
{
    [SerializeField]
    private GameObject _ball;

    [SerializeField]
    private float timeInterval;
    private float currentInterval;
    [SerializeField]
    private float throwingForce = 10f; 
    [SerializeField]
    private Transform _anchorBallPoint; 
    [SerializeField]
    private Vector2 throwingAngle = new Vector2(0, 360f);

    private void Start()
    {
        currentInterval = timeInterval;
    }

    private void FixedUpdate()
    {
        currentInterval -= Time.deltaTime;
        if(currentInterval <= 0) { InstantiateBall(); currentInterval = timeInterval; }
    }

    private void InstantiateBall()
    {
        float angle = Random.Range(throwingAngle.x, throwingAngle.y);
        float xComponent = Mathf.Cos(angle * Mathf.PI / 100) * throwingForce;
        float yComponent = Mathf.Sin(angle * Mathf.PI / 100) * throwingForce;

        GameObject newBall = Instantiate(_ball, _anchorBallPoint);
        Rigidbody ballRB = newBall.GetComponent<Rigidbody>();
        ballRB.AddForce(new Vector3(yComponent, 0f, xComponent) * Time.deltaTime, ForceMode.Impulse);
    }
}
