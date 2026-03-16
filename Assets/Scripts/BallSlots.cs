using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class BallSlots : MonoBehaviour
{
    [SerializeField]
    private List<Transform> balls = new List<Transform>();
    [SerializeField]
    private AudioSource goalSound;

    public void ResetBalls()
    {
        foreach (Transform transform in balls)
        {
            Rigidbody ballBody = transform.GetComponent<Rigidbody>();
            ballBody.linearVelocity = Vector3.zero;
            ballBody.angularVelocity = Vector3.zero;
            transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
        }
    }
}
