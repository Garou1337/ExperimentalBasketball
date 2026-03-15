using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class HUDView : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI goalsValueText;

    public void UpdateScore(int value)
    {
        goalsValueText.text = value.ToString();
    }
}
