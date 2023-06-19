using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpOpenClose : MonoBehaviour
{
    [Header("Gem PopUp")]
    [Tooltip("Gemlerin G�sterildi�i Panel")]
    public GameObject PopUpPanel;
    [Space]

    [Tooltip("Popup Kapatma Butonu")]
    public GameObject PopUpCloseButton;
    [Space]

    [Tooltip("Popup A�ma Butonu")]
    public GameObject PopUpOpenButton;

    [Header("Shop")]
    [Tooltip("Shop Paneli")]
    public GameObject ShopPanel;
    [Space]

    [Tooltip("Shop Kapatma Butonu")]
    public GameObject ShopCloseButton;
    [Space]

    [Tooltip("Shop A�ma Butonu")]
    public GameObject ShopOpenButton;
    [Space]

    [Header("Di�er")]    
    [Tooltip("Kullan�lan Joystic")]
    public GameObject Joystick;


    //PopUp paneli a��yor
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
    //PopUp paneli kapat�yor
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


    //Shop paneli A��l�yor
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
    //Shop paneli kapat�yor
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
