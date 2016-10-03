using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class UIManager : MonoBehaviour
{
    public PopupController m_introPopup;
    public GalleryController m_galleryController;
    public static UIManager Instance;
    public MenuController m_menuController;
    public GameObject m_supportButtons;

    public AudioMixer m_audioMixer;
    public AudioMixerSnapshot m_normalSnapshot;
    public AudioMixerSnapshot m_offSnapshot;
    public AudioSource m_chapterMusic;
    public AudioSource m_chapterVoiceOver;

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

    public void FadeInSound()
    {
        m_normalSnapshot.TransitionTo(2);
    }

    public void FadeOutSound()
    {
        m_offSnapshot.TransitionTo(2);
    }
}
