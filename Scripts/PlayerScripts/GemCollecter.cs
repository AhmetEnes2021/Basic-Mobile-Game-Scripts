using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GemCollecter : MonoBehaviour
{
    [Tooltip("PopUp i�erisinde gemlerin eklendi�i panel")]
    public Transform PopUpElementPanel;

    [Space]
    [Tooltip("PopUp i�erisinde gemlerin g�sterildi�i panel")]
    public GameObject GemPanel;

    [Space]
    [Tooltip("Karakterin v�cudu (Gemlerin karakter arkas�nda d�zg�n s�ralanmas� i�in) ")]
    public Transform Boady;

    [Space]
    [Tooltip("Karakterin Toplad��� Gemler")]
    public List<GameObject> GemList = new List<GameObject>();

    public static GemCollecter Instance;
    private GameObject NewGemPanel;

    private void Awake()//Oyun ba�lad��� an PopUp k�sm�nda gem listesine ekli t�m gemleri s�ralay�p ka� tane topland��� yaz�l�yor
    {
        Instance = this;
        foreach (var gem in AddGemOnInspector.Instance.GemProperties)
        {
            gem.CollectedCount = PlayerPrefs.GetInt(gem.Name);
            if (!gem.IsInPopUp)
            {
                gem.IsInPopUp = true;
                NewGemPanel = Instantiate(GemPanel, new Vector3(0f, 0f, 0f), Quaternion.identity);
                NewGemPanel.transform.SetParent(PopUpElementPanel, false);
                NewGemPanel.GetComponent<GemPanelProperties>().GemIcon.GetComponent<Image>().sprite = gem.GemIcon;
                NewGemPanel.GetComponent<GemPanelProperties>().GemNameText.text = gem.Name;
                NewGemPanel.GetComponent<GemPanelProperties>().CollectedGemCountText.text = gem.CollectedCount.ToString();
                gem.GemPanel = NewGemPanel;
            }
        }
    }
    private void OnTriggerEnter(Collider GemCollider)
    {
        //karakterin ta��ma kapasitesi yeterli ise gemin t�r�n� belirleyip boyutu yeterince b�y�k ise topluyor, Gem'in b�y�mesi durduruluyor
        if (GemList.Count < CarryCapacityScript.Instance.CurrentCarryCapacity)
        {
            foreach (var gem in AddGemOnInspector.Instance.GemProperties)
            {
                if (GemCollider.tag == gem.GemTag && GemCollider.gameObject.transform.localScale.x > 0.25f)
                {

                    CollectGem(GemCollider);
                    gem.CollectedCount++;
                    gem.GemPanel.GetComponent<GemPanelProperties>().CollectedGemCountText.text = gem.CollectedCount.ToString();
                    PlayerPrefs.SetInt(gem.Name, gem.CollectedCount);
                }
            }
        }
    }

    private void CollectGem(Collider other)
    {
        
        other.gameObject.GetComponent<GemBreeder>().CanBreed = false;
        other.gameObject.transform.SetParent(Boady);
        other.transform.DOLocalMove(new Vector3(0, Boady.localPosition.y + (1.5f * GemList.Count) + 1, -1), 2f, false);
        other.GetComponent<BoxCollider>().enabled = false;
        GemList.Add(other.gameObject);
        GridScript.Instance.GrowingGems.Remove(other.gameObject);
        GridScript.Instance.AddNewGem(int.Parse(other.name));
        CarryCapacityScript.Instance.CurrentCarryCapacityText.text = "Carry Capacity : " + GemList.Count + "/" + CarryCapacityScript.Instance.CurrentCarryCapacity;
    }
}
