using TMPro;
using UnityEngine;

public class GemGrowSpeed : MonoBehaviour
{
    [Header("Properties")]
    [Tooltip("Baþlangýç Fiyatý")]
    public int Price;
    [Space]

    [Tooltip("Baþlangýç Oluþma Hýzý")]
    public int DefoultGrowSpeed = 5;
    [Space]

    [Tooltip("Baþlangýç Seviyesi")]
    public int DefoultLevel = 1;
    [Space]

    [Tooltip("Maksimum Oluþma Hýzý Seviyesi")]
    public int MaxGrowSpeedLevel;
    [Space]

    [Header("GameObjects")]
    [Tooltip("Shop üzerinde Fiyatýn Yazýlacaðý Text Objesi")]
    public TMP_Text PriceText;
    [Space]

    [Tooltip("Shop üzerinde Level'ýn Yazýlacaðý Text Objesi")]
    public TMP_Text CurrentLevelText;
    [Space]

    [HideInInspector] public int CurrentGrowSpeed;
    [HideInInspector] public int CurrentLevel;

    public static GemGrowSpeed Instance;
    private void Awake()
    {
        Instance = this;
        Control(Price, DefoultGrowSpeed, DefoultLevel);
        Print(Price, CurrentLevel);
    }
    public void UpgradeLevel()//Maðaza üzerinde öðeye týklanýldýðýnda yeterli para var ise gemlerin oluþum hýzýný (büyüme hýzý/10) oranýnda arttýrýyor
    {
        if (CurrentGoldScript.Instance.CurrentGold > Price && MaxGrowSpeedLevel > CurrentLevel)
        {
            CurrentGoldScript.Instance.CurrentGold -= Price;
            CurrentLevel++;
            CurrentGrowSpeed = DefoultGrowSpeed * CurrentLevel;
            Price = Price * CurrentLevel;
            Save(Price, CurrentGrowSpeed, CurrentLevel);
            Print(Price, CurrentLevel);
        }
    }
    private void Save(int _Price, int _CurrentGrowSpeed, int _CurrentLevel)
    {
        PlayerPrefs.SetInt("_GrowSpeedPrice", _Price);
        PlayerPrefs.SetInt("_CurrentGrowSpeed", _CurrentGrowSpeed);
        PlayerPrefs.SetInt("_GrowSpeedCurrentLevel", _CurrentLevel);
    }
    private void Control(int _Price, int _DefoultCarryCapacity, int _DefoultLevel)
    {
        if (PlayerPrefs.GetInt("_GrowSpeedPrice") < _Price)
        {
            PlayerPrefs.SetInt("_GrowSpeedPrice", _Price);
        }
        else
        {
            Price = PlayerPrefs.GetInt("_GrowSpeedPrice");
        }
        if (PlayerPrefs.GetInt("_CurrentGrowSpeed") < _DefoultCarryCapacity)
        {
            PlayerPrefs.SetInt("_CurrentGrowSpeed", _DefoultCarryCapacity);
            CurrentGrowSpeed = _DefoultCarryCapacity;
        }
        else
        {
            CurrentGrowSpeed = PlayerPrefs.GetInt("_CurrentGrowSpeed");
        }
        if (PlayerPrefs.GetInt("_GrowSpeedCurrentLevel") < _DefoultLevel)
        {
            PlayerPrefs.SetInt("_GrowSpeedCurrentLevel", _DefoultLevel);
            CurrentLevel = _DefoultLevel;
        }
        else
        {
            CurrentLevel = PlayerPrefs.GetInt("_GrowSpeedCurrentLevel");
        }
    }
    private void Print(int _Price, int _CurrentLevel)
    {
        PriceText.text = _Price.ToString() + " Gold";
        CurrentLevelText.text = _CurrentLevel.ToString();
    }
}
