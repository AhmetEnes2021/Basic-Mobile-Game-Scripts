using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrentGoldScript : MonoBehaviour
{
    

    
    [Tooltip("Sahip Oldu�umuz Alt�n")]
    public int Gold;
    public int CurrentGold
    {
        get
        {
            return Gold;
        }

        set
        {
            Gold = value;
        }
    }
    

    [Tooltip("Sahip Oldu�umuz Alt�n Miktar�n�n Yazaca�� Text")]
    public TMP_Text GoldText;

    public static CurrentGoldScript Instance;
    private void Awake()
    {
        Instance=this;
        CurrentGold = PlayerPrefs.GetInt("CurrentGold");
    }
    private void Update()
    {
        GoldText.text = "Gold : " + ((int)CurrentGold).ToString();
    }
}
