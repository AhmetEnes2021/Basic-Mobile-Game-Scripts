using TMPro;
using UnityEngine;

public class GemGrowSpeed : MonoBehaviour
{
    [Header("Properties")]
    [Tooltip("Ba�lang�� Fiyat�")]
    public int Price;
    [Space]

    [Tooltip("Ba�lang�� Olu�ma H�z�")]
    public int DefoultGrowSpeed = 5;
    [Space]

    [Tooltip("Ba�lang�� Seviyesi")]
    public int DefoultLevel = 1;
    [Space]

    [Tooltip("Maksimum Olu�ma H�z� Seviyesi")]
    public int MaxGrowSpeedLevel;
    [Space]

    [Header("GameObjects")]
    [Tooltip("Shop �zerinde Fiyat�n Yaz�laca�� Text Objesi")]
    public TMP_Text PriceText;
    [Space]

    [Tooltip("Shop �zerinde Level'�n Yaz�laca�� Text Objesi")]
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
    public void UpgradeLevel()//Ma�aza �zerinde ��eye t�klan�ld���nda yeterli para var ise gemlerin olu�um h�z�n� (b�y�me h�z�/10) oran�nda artt�r�yor
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
