using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class HUDView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI goalsValueText;
    [SerializeField]
    private GameObject goalsAnnouncementText;

    private bool isShowingGoalText = false;
    private float goalShowDuration = 1f;
    private float goalShowTimer = 0f;

    private void Start()
    {
        goalsAnnouncementText.SetActive(false);
    }

    private void Update()
    {
        if (isShowingGoalText)
        {
            goalShowTimer -= Time.deltaTime;

            if (goalShowTimer <= 0)
            {
                goalShowTimer = 0f;
                isShowingGoalText = false;
                goalsAnnouncementText.SetActive(false);
            }
        }
    }

    public void UpdateScore(int value)
    {
        goalsValueText.text = value.ToString();
        goalsAnnouncementText.SetActive(true);
        isShowingGoalText = true;
        goalShowTimer = goalShowDuration;
    }
}
