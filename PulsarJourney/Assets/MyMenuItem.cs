using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MyMenuItem : MonoBehaviour
{
    public Text m_chapterLabel;

	// Use this for initialization
	void Start ()
    {
        //m_chapterLabel.text = Localization.Get(string.Concat("Chapter_", transform.name[0].ToString(), "_Title"));
        m_chapterLabel.text = string.Concat("Chapter ", transform.GetSiblingIndex());

        if ( transform.GetSiblingIndex() == 0 )
            m_chapterLabel.text = "Introduction";
        else if ( transform.GetSiblingIndex() == 12 )
            m_chapterLabel.text = "Thank You";

        GetComponent<Button>().onClick.AddListener(delegate
        {
            UIManager.Instance.m_galleryController.ChangeToChapter(transform.GetSiblingIndex());
        });
    }
	
}
