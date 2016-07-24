using UnityEngine;
using System.Collections;

public class PopupController : MonoBehaviour
{
    CanvasGroup m_canvasGroup;

    void Awake()
    {
        m_canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Show()
    {
        gameObject.SetActive(true);
        m_canvasGroup.alpha = 0f;
        TweenGroupAlpha.Begin(m_canvasGroup, 1.5f, 1f, 0.4f);
    }

    public void Hide()
    {
        TweenGroupAlpha.Begin(m_canvasGroup, 1f, 0f);
    }
}
