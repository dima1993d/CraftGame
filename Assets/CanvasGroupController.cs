using UnityEngine;

public class CanvasGroupController : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    private void Awake()
    {
        if (!canvasGroup)
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }
    }

    public void SetVisible(bool var)
    {
        if (var)
        {
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
        }
        else
        {
            canvasGroup.interactable = false;

            canvasGroup.alpha = 0;
        }
        
    }
}
