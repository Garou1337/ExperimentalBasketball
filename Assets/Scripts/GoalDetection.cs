using UnityEngine;

public class GoalDetection : MonoBehaviour
{
    [SerializeField]
    private HUDView HUD;

    private int numberOfGoals;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(ProjectUtilities.BALL_TAG))
        {
            Debug.Log("GOAL!");
            numberOfGoals++;
            HUD.UpdateScore(numberOfGoals);
        }
    }

}
