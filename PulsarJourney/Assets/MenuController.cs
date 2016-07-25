using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

    private bool m_isShown = false;
    public CanvasGroup m_group;
    public static MenuController Instance;
    public Button m_left;
    public Button m_right;
    public Button m_menu;

    public bool IsShown()
    {
        return m_isShown;
    }
	// Use this for initialization
	void Awake () {
        Instance = this;
        m_group.alpha = 0f;
        m_group.interactable = false;
        m_group.blocksRaycasts = false;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Show( bool state )
    {
        float targetValue = 1f;

        if ( !state )
            targetValue = 0f;

        TweenGroupAlpha.Begin(m_group, 0.5f, targetValue);

        m_isShown = state;
        m_group.interactable = state;
        m_group.blocksRaycasts = state;

        foreach ( Button currentButton in transform.GetComponentsInChildren<Button>() )
        {
            currentButton.interactable = true;
        }

        if ( state )
        {
            transform.FindChild("Background").GetChild(UIManager.Instance.m_galleryController.GetCurrentChapter()).GetComponent<Button>().interactable = false;
            m_left.gameObject.SetActive(false);
            m_right.gameObject.SetActive(false);
            m_menu.gameObject.SetActive(false);
        }
        else
        {
            m_left.gameObject.SetActive(true);
            m_right.gameObject.SetActive(true);
            m_menu.gameObject.SetActive(true);
        }

        UIManager.Instance.m_galleryController.CheckButtons();
    }
}
