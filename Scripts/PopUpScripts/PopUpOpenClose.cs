using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpOpenClose : MonoBehaviour
{
    [Header("Gem PopUp")]
    [Tooltip("Gemlerin Gösterildiði Panel")]
    public GameObject PopUpPanel;
    [Space]

    [Tooltip("Popup Kapatma Butonu")]
    public GameObject PopUpCloseButton;
    [Space]

    [Tooltip("Popup Açma Butonu")]
    public GameObject PopUpOpenButton;

    [Header("Shop")]
    [Tooltip("Shop Paneli")]
    public GameObject ShopPanel;
    [Space]

    [Tooltip("Shop Kapatma Butonu")]
    public GameObject ShopCloseButton;
    [Space]

    [Tooltip("Shop Açma Butonu")]
    public GameObject ShopOpenButton;
    [Space]

    [Header("Diðer")]    
    [Tooltip("Kullanýlan Joystic")]
    public GameObject Joystick;


    //PopUp paneli açýyor
    public void PopUpOpen()
    {
        PopUpPanel.SetActive(true);
        PopUpPanel.transform.localScale = new Vector3 (0f, 0f, 0f);
        PopUpPanel.transform.DOScale(new Vector3(4f, 7f, 0f), 0.5f);
        PopUpCloseButton.SetActive(true);
        PopUpOpenButton.SetActive(false);
        ShopOpenButton.SetActive(false);
        Joystick.SetActive(false);
    }
    //PopUp paneli kapatýyor
    public void PopUpClose()
    {
        
        PopUpPanel.transform.DOScale(new Vector3(0f, 0f, 0f), 0.3f);
        StartCoroutine(ClosePopUp());
        PopUpCloseButton.SetActive(false);
        PopUpOpenButton.SetActive(true);
        ShopOpenButton.SetActive(true);
        Joystick.SetActive(true);
    }
    IEnumerator ClosePopUp()
    {
        yield return new WaitForSecondsRealtime(0.3f);
        PopUpPanel.SetActive(false);

    }


    //Shop paneli Açýlýyor
    public void ShopOpen()
    {
        ShopPanel.transform.localScale = new Vector3(0f, 0f, 0f);
        ShopPanel.SetActive(true);
        ShopPanel.transform.DOScale(new Vector3(4f, 7f, 0f), 0.5f);
        ShopCloseButton.SetActive(true);
        ShopOpenButton.SetActive(false);
        PopUpOpenButton.SetActive(false);
        Joystick.SetActive(false);
    }
    //Shop paneli kapatýyor
    public void ShopClose()
    {

        ShopPanel.transform.DOScale(new Vector3(0f, 0f, 0f), 0.3f);
        StartCoroutine(CloseShop());
        ShopCloseButton.SetActive(false);
        ShopOpenButton.SetActive(true);
        PopUpOpenButton.SetActive(true);
        Joystick.SetActive(true);
    }
    IEnumerator CloseShop()
    {
        yield return new WaitForSecondsRealtime(0.3f);
        ShopPanel.SetActive(false);

    }
}
