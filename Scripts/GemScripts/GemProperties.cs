using UnityEngine;

[System.Serializable]
public class GemProperties//Her bir gemin �zelliklerinin yaz�ld��� liste
{
    public string Name;
    public float GemSellingPrice;
    public Sprite GemIcon;
    public string GemTag;
    public int CollectedCount;
    public bool IsInPopUp;
    [HideInInspector]
    public GameObject GemPanel;
    
}
