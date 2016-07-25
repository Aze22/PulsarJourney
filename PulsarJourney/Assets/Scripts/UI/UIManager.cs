using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public PopupController m_introPopup;
    public GalleryController m_galleryController;
    public static UIManager Instance;
    public MenuController m_menuController;

    void Awake()
    {
        Instance = this;
        m_galleryController.gameObject.SetActive(false);
        m_introPopup.gameObject.SetActive(false);
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
}
