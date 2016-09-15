using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MyMenuItem : MonoBehaviour
{
    public Text m_chapterLabel;
    public int m_idOverride = -1;

	// Use this for initialization
	void Start ()
    {
        //m_chapterLabel.text = Localization.Get(string.Concat("Chapter_", transform.name[0].ToString(), "_Title"));
        m_chapterLabel.text = string.Concat("Chapter ", transform.GetSiblingIndex());

        if ( transform.GetSiblingIndex() == 0 )
            m_chapterLabel.text = "Foreword";
        else if ( transform.GetSiblingIndex() == 12 )
            m_chapterLabel.text = "Afterword";

        GetComponent<Button>().onClick.AddListener(delegate
        {
            UIManager.Instance.m_galleryController.ChangeToChapter(( m_idOverride == -1 ? transform.GetSiblingIndex() : m_idOverride ));

            if ( transform.GetSiblingIndex() == 0 )
                UIManager.Instance.m_galleryController.m_previousButton.interactable = false;
            else
                UIManager.Instance.m_galleryController.m_previousButton.interactable = true;
            if ( transform.GetSiblingIndex() == 12 )
                UIManager.Instance.m_galleryController.m_nextButton.interactable = false;
            else
                UIManager.Instance.m_galleryController.m_nextButton.interactable = true;
        });
    }
}
