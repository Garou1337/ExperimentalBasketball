using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameObject currentlyHeldBall;
    private Rigidbody ballBody;
    private bool isBallHeld = false;
    private Vector3 currentFrameCursorPosition = Vector3.zero;
    private Vector3 currentBallPosition = Vector3.zero;

    private Vector3 startCursorPosition = Vector3.zero;

    private float armReach = 1f;
    private float forceMultiplier = 140f;
    private float upwardsThrowAttenuation = 0.002f;

    void Update()
    {
        ProcessingInput();
    }

    private void ProcessingInput()
    {
        currentFrameCursorPosition = Input.mousePosition;
        currentFrameCursorPosition.z = armReach;

        if (Input.GetKey(KeyCode.Mouse1))
        {
            RaycastHit hit;
            Ray origin = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(origin, out hit))
            {
                if (hit.transform.CompareTag(ProjectUtilities.BALL_TAG))
                {
                    currentlyHeldBall = hit.transform.gameObject;
                    ballBody = currentlyHeldBall.GetComponent<Rigidbody>();
                    isBallHeld = true;
                }
            }
        }

        Vector3 screenToWorldPoint = Camera.main.ScreenToWorldPoint(currentFrameCursorPosition);

        if (isBallHeld)
        {

            currentBallPosition = new Vector3(
                                    screenToWorldPoint.x,
                                    screenToWorldPoint.y,
                                    transform.position.z + (transform.forward.magnitude * armReach)
                                    );

            currentlyHeldBall.transform.position = currentBallPosition;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            startCursorPosition = Input.mousePosition;
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (ballBody != null)
            {
                ballBody.linearVelocity = Vector3.zero;
                ballBody.angularVelocity = Vector3.zero;
                isBallHeld = false;

                Vector3 forceVector = CalculateForceVector(currentFrameCursorPosition, startCursorPosition);

                ballBody.AddForce(forceVector);
            }
        }
    }

    private Vector3 CalculateForceVector(Vector3 currentFrameCursorPosition, Vector3 lastFrameCursorPosition)
    {
        Vector3 mousePositionDelta = currentFrameCursorPosition - lastFrameCursorPosition;

        Vector3 throwForwardMomentum = ballBody.transform.position - gameObject.transform.position;
        throwForwardMomentum.Normalize();

        Vector3 XYForceVector = mousePositionDelta * upwardsThrowAttenuation;
        Vector3 forceVector = (XYForceVector + throwForwardMomentum) * forceMultiplier;

        return forceVector;
    }
}
