using UnityEngine;

public class CanvasGroupController : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public bool visible = false;
    private void Awake()
    {
        if (!canvasGroup)
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }
    }
    public void SetVisible()
    {
        visible = !visible;
        SetVisible(visible);
    }
    public void SetVisible(bool var)
    {
        if (var)
        {
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }
        else
        {
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;

            canvasGroup.alpha = 0;
        }
        
    }
}
