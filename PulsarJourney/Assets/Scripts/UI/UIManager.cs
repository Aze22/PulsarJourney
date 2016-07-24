using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public PopupController m_introPopup;
    public GalleryController m_galleryController;

    void Awake()
    {
        m_galleryController.gameObject.SetActive(false);
        m_introPopup.gameObject.SetActive(false);
        Localization.language = "English";
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
