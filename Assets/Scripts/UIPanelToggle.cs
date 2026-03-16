using UnityEngine;

public class UIPanelToggle : MonoBehaviour
{
    [SerializeField]
    private GameObject panel;

    public void TogglePanelVisibility()
    {
        panel.SetActive(!panel.activeInHierarchy);
    }
}
