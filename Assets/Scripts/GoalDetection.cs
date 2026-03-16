using UnityEngine;

public class GoalDetection : MonoBehaviour
{
    [SerializeField]
    private HUDView HUD;
    [SerializeField]
    private AudioSource goalSound;

    private int numberOfGoals;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(ProjectUtilities.BALL_TAG))
        {
            goalSound.Play();
            numberOfGoals++;
            HUD.UpdateScore(numberOfGoals);
        }
    }

}
