using UnityEngine;

public class GemSellSystem : MonoBehaviour
{
    public static GemSellSystem Instance;
    private float timer = 0;
    private GameObject GemToBeSold;
    private void Awake()
    {
        Instance = this;
    }

    private void OnTriggerStay(Collider other)//Satýþ bölgesine girildiðini algýlayýp gemlerin satýlmasýný saðlýyor
    {
        SellGems(other);
    }
    private void SellGems(Collider _Other)
    {
        if (_Other.tag == "Player" && GemCollecter.Instance.GemList.Count > 0)
        {
            timer += Time.fixedDeltaTime;
            for (int i = GemCollecter.Instance.GemList.Count; i > 0; i--)
            {
                GemToBeSold = GemCollecter.Instance.GemList[GemCollecter.Instance.GemList.Count - 1];
                if (timer >= 0.06f)
                {
                    timer = 0;
                    foreach (var gem in AddGemOnInspector.Instance.GemProperties)
                    {
                        if (GemToBeSold.tag == gem.GemTag)
                        {
                            CurrentGoldScript.Instance.CurrentGold += (int)(gem.GemSellingPrice + (GemToBeSold.transform.localScale.x * 100));
                            PlayerPrefs.SetInt("CurrentGold", CurrentGoldScript.Instance.CurrentGold);
                            GemCollecter.Instance.GemList.Remove(GemToBeSold);
                            Destroy(GemToBeSold);
                            CarryCapacityScript.Instance.CurrentCarryCapacityText.text = "Carry Capacity : " + GemCollecter.Instance.GemList.Count + "/" + CarryCapacityScript.Instance.CurrentCarryCapacity;
                        }
                    }
                }
            }
        }
    }
}

