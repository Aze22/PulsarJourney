using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GalleryController : MonoBehaviour {

    CanvasGroup m_canvasGroup;
    private int m_currentChapter = 0;
    public Text m_chapterText;
    public Text m_contentText;
    public Image m_image;
    public CanvasGroup m_contentCanvas;

    public Button m_previousButton;
    public Button m_nextButton;
    public Scrollbar m_scrollbar;
    public ScrollRect m_scrollRect;

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
        m_scrollRect.verticalNormalizedPosition = 1;
        TweenGroupAlpha.Begin(m_canvasGroup, 1.5f, 1f, 1.5f);
    }

    public void ResetGallery()
    {
        SetContentToChapter(0);
        CheckButtons();
    }

    public void MenuClicked()
    {
        UIManager.Instance.m_menuController.Show(true);
    }

    private void SetContentToChapter( int _newChapter )
    {
        m_currentChapter = _newChapter;
        m_image.sprite = Resources.Load<Sprite>(string.Concat("Photos/Chapter_", (m_currentChapter > 0 ? (m_currentChapter-1) : m_currentChapter)));
        m_chapterText.text = Localization.Get(string.Concat("Chapter_", m_currentChapter, "_Title"));

        if ( m_currentChapter == 1 || m_currentChapter == 13 )
        {
            m_image.sprite = null;
            m_image.color = Color.black;
        }
        else
        {
            m_image.color = Color.white;
        }

        if ( m_chapterText.text == string.Concat("Chapter_", m_currentChapter, "_Title") )
            m_chapterText.text = "";

        m_contentText.text = Localization.Get(string.Concat("Chapter_", m_currentChapter, "_Content"));
       
        
    }

    public void NextClicked()
    {
        if(m_currentChapter < 14)
            ChangeToChapter(m_currentChapter + 1);

        //CheckButtons();
    }

    public int GetCurrentChapter()
    {
        return m_currentChapter;
    }

    public void ChangeToChapter(int _newChapter)
    {
        if ( UIManager.Instance.m_menuController.IsShown() )
            UIManager.Instance.m_menuController.Show(false);

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
        yield return null;
       // m_scrollRect.verticalScrollbar.value = 1f;
        m_scrollRect.verticalNormalizedPosition = 1;
        CheckButtons();
        TweenGroupAlpha.Begin(m_contentCanvas, 0.5f, 1);
    }

    public void PreviousClicked()
    {
        if(m_currentChapter > 0)
            ChangeToChapter(m_currentChapter - 1);

        //CheckButtons();
    }

    public void CheckButtons()
    {
        if ( m_currentChapter <= 0 )
        {
            m_previousButton.interactable = false;
        }
        else
            m_previousButton.interactable = true;

        if ( m_currentChapter >= 14 )
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
