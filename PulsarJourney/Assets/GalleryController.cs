using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GalleryController : MonoBehaviour {

    CanvasGroup m_canvasGroup;
    private int m_currentChapter = 1;
    public Text m_chapterText;
    public Text m_contentText;
    public Image m_image;
    public CanvasGroup m_contentCanvas;

    public Button m_previousButton;
    public Button m_nextButton;

    private IEnumerator m_changeChapterRoutine;

    void Awake()
    {   
        m_canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Show()
    {
        gameObject.SetActive(true);
        ResetGallery();
        m_canvasGroup.alpha = 0f;
        TweenGroupAlpha.Begin(m_canvasGroup, 1.5f, 1f, 1.5f);
    }

    public void ResetGallery()
    {
        SetContentToChapter(1);
    }

    public void MenuClicked()
    {

    }

    private void SetContentToChapter( int _newChapter )
    {
        m_currentChapter = _newChapter;
        m_image.sprite.name = string.Concat("Chapter_", m_currentChapter);
        m_chapterText.text = Localization.Get(string.Concat("Chapter_", m_currentChapter, "_Title"));
        m_contentText.text = Localization.Get(string.Concat("Chapter_", m_currentChapter, "_Content"));
    }

    public void NextClicked()
    {
        if(m_currentChapter < 11)
            ChangeToChapter(m_currentChapter + 1);

        CheckButtons();
    }

    private void ChangeToChapter(int _newChapter)
    {
        m_currentChapter = _newChapter;

        if ( m_changeChapterRoutine != null )
        {
            StopCoroutine(m_changeChapterRoutine);
            m_changeChapterRoutine = null;
        }

        m_changeChapterRoutine = ChangeChapterRoutine(m_currentChapter);
        StartCoroutine(m_changeChapterRoutine);
    }

    private IEnumerator ChangeChapterRoutine(int _newChapter)
    {
        TweenGroupAlpha.Begin(m_contentCanvas, 0.5f, 0);
        yield return new WaitForSeconds(1f);
        SetContentToChapter(_newChapter);
        TweenGroupAlpha.Begin(m_contentCanvas, 0.5f, 1);
    }

    public void PreviousClicked()
    {
        if(m_currentChapter > 1)
            ChangeToChapter(m_currentChapter - 1);

        CheckButtons();
    }

    public void CheckButtons()
    {
        if ( m_currentChapter <= 1 )
        {
            m_previousButton.interactable = false;
        }
        else
            m_previousButton.interactable = true;

        if ( m_currentChapter >= 11 )
        {
            m_nextButton.interactable = false;
        }
        else
            m_nextButton.interactable = true;
    }

    public void Hide()
    {
        TweenGroupAlpha.Begin(m_canvasGroup, 0.5f, 0f);
    }
}
