using UnityEngine;
using MoreMountains.Feedbacks;

public class BallFeedbackStateMachine : MonoBehaviour
{
    public int BallState;

    [Header("Feedbacks")]
    public MMFeedbacks initialFeedbacks;
    public MMFeedbacks baseHitFeedback;

    private void Start()
    {
        SetBallState(0);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            BallHit();
        }
    }

    public void SetBallState(int state)
    {
        BallState = state;
        ApplyState();
    }

    void ApplyState()
    {
        if (BallState == 0)
        {
            initialFeedbacks.PlayFeedbacks();
        }
    }

    public void BallHit()
    {
        initialFeedbacks.PauseFeedbacks();
        baseHitFeedback.PlayFeedbacks();
    }
}
