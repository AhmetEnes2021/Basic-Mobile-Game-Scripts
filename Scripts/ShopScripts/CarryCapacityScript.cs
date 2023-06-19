using UnityEngine;
using TMPro;

public class CarryCapacityScript : MonoBehaviour
{
    [Header("Properties")]
    [Tooltip("Ba�lang�� Fiyat�")]
    public int Price;
    [Space]

    [Tooltip("Ba�lang�� Ta��ma Kapasitesi (Minimum 1)")]
    public int DefoultCarryCapacity = 10;
    [Space]

    [Tooltip("Ba�lang�� Seviyesi (Minimum 1) ")]
    public int DefoultLevel = 1;
    [Space]

    [Tooltip("Maksimum Ta��ma Kapasitesi Seviyesi")]
    public int MaxCarryCapacityLevel;
    [Space]

    [Header("GameObjects")]
    [Tooltip("Shop �zerinde Fiyat�n Yaz�laca�� Text Objesi")]
    public TMP_Text PriceText;
    [Space]

    [Tooltip("Shop �zerinde Level'�n Yaz�laca�� Text Objesi")]
    public TMP_Text CurrentLevelText;
    [Space]

    [Tooltip("Ta��ma Kapasitesini G�steren Text Objesi")]
    public TMP_Text CurrentCarryCapacityText;


    [HideInInspector] public int CurrentCarryCapacity;
    [HideInInspector] public int CurrentLevel;

    public static CarryCapacityScript Instance;
    private void Awake()
    {
        Instance = this;
        Control(Price, DefoultCarryCapacity,DefoultLevel);
        Print(Price, CurrentCarryCapacity, CurrentLevel);
    }
    public void UpgradeLevel()//Ma�azada ��eye t�klan�ld���nda yeterli para var ise seviye y�kseltiyor, her bir seviye y�kseldi�inde yeni ta��ma kapasitesi Defoult kapasitesi ile Seviyenin �arp�m�na e�it oluyor
    {
        if (CurrentGoldScript.Instance.CurrentGold > Price && MaxCarryCapacityLevel > CurrentLevel)
        {
            CurrentGoldScript.Instance.CurrentGold -= Price;
            CurrentLevel++;
            CurrentCarryCapacity = DefoultCarryCapacity * CurrentLevel;
            Price = Price * CurrentLevel;
            Save(Price, CurrentCarryCapacity, CurrentLevel);
            Print(Price, CurrentCarryCapacity, CurrentLevel);
        }
    }  
    private void Save(int _Price, int _CurrentCarryCapacity, int _CurrentLevel)
    {
        PlayerPrefs.SetInt("_Price", _Price);
        PlayerPrefs.SetInt("_CurrentCarryCapacity", _CurrentCarryCapacity);
        PlayerPrefs.SetInt("_CurrentLevel", _CurrentLevel);
    }
    private void Control(int _Price, int _DefoultCarryCapacity,int _DefoultLevel)
    {
        if (PlayerPrefs.GetInt("_Price") < _Price)
        {
            PlayerPrefs.SetInt("_Price", _Price);
        }
        else
        {
            Price = PlayerPrefs.GetInt("_Price");
        }
        if (PlayerPrefs.GetInt("_CurrentCarryCapacity") < _DefoultCarryCapacity)
        {
            PlayerPrefs.SetInt("_CurrentCarryCapacity", _DefoultCarryCapacity);
            CurrentCarryCapacity = _DefoultCarryCapacity;
        }
        else
        {
            CurrentCarryCapacity = PlayerPrefs.GetInt("_CurrentCarryCapacity");
        }
        if (PlayerPrefs.GetInt("_CurrentLevel") < _DefoultLevel)
        {
            PlayerPrefs.SetInt("_CurrentLevel", _DefoultLevel);
            CurrentLevel = _DefoultLevel;
        }
        else
        {
            CurrentLevel = PlayerPrefs.GetInt("_CurrentLevel");
        }
    }
    private void Print(int _Price, int _CurrentCarryCapacity, int _CurrentLevel)
    {
        PriceText.text = _Price.ToString() + " Gold";
        CurrentLevelText.text = _CurrentLevel.ToString();
        CurrentCarryCapacityText.text = "Carry Capacity : " + 0 + "/" + CurrentCarryCapacity;
    }
}
