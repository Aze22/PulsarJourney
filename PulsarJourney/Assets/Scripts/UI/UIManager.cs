using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public PopupController m_introPopup;
    public GalleryController m_galleryController;
    public static UIManager Instance;
    public MenuController m_menuController;
    public GameObject m_supportButtons;

    void Awake()
    {
        Instance = this;
        m_galleryController.gameObject.SetActive(false);
        m_introPopup.gameObject.SetActive(false);
        m_supportButtons.gameObject.SetActive(false);
        Localization.language = "English";
        m_menuController.gameObject.SetActive(true);
    }
	// Use this for initialization
	void Start ()
    {
        m_introPopup.Show();
    }

    public void ShowGallery()
    {
        m_galleryController.Show();
    }

    public void ShowSupportButtons()
    {
        m_supportButtons.SetActive(true);
    }

    public void HideSupportButtons()
    {
        m_supportButtons.SetActive(false);
    }

    public void PatreonSupportClicked()
    {
        Application.OpenURL("https://www.patreon.com/bePatron?u=346493&redirect_uri=https%3A%2F%2Fwww.patreon.com%2FFromTheEdge%2Fposts");
    }

    public void ViewMyWebsiteClicked()
    {
        Application.OpenURL("http://www.pari.edu/support-pari/");
    }
}
