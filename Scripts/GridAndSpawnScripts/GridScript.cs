using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridScript : MonoBehaviour
{
    [Header("Grid Bilgileri")]
    [Tooltip("Grid'in Uzunluðu")]
    public int GridLength;
    [Space]
    [Tooltip("Grid'in Geniþliði")]
    public int GridWidth;
    [Space]
    [Tooltip("Grid'in Hücreleri Arasý Mesafe")]
    public float CellToCellDistance;
    [Space]
    [Tooltip("Grid'in Koordinatý (Koordinatlar 0 olarak girilebilir)")]
    public Vector3 GridCootdinate;
    [Space]
    [Tooltip("Grid'in Hücrelerinde Kullanýlan Prefab (Prefab Eklemek Zorunludur)")]
    public GameObject CellPrefab;
    [Space]
    [Header("Listeler")]
    public List<GameObject> GemPrefab = new List<GameObject>();
    [Space]
    public List<GameObject> CellList = new List<GameObject>();
    [Space]
    public List<GameObject> GrowingGems = new List<GameObject>();
    
    
    
    private int Counter = 0;
    private GameObject NewGem;
    public static GridScript Instance;

    private void Awake()//Oyun baþladýðýnda gemlerin oluþnasýný saðlýyor
    {
        
        Instance = this;
        while (GrowingGems.Count < CellList.Count)
        {
            SpawnGem(Counter);
            GrowingGems.Add(NewGem);
            Counter++;
        }
        Counter = 0;
    }

    public void AddNewGem(int NewGemIndex)//Gemler toplandýkca yerlerinde yenilerinin çýkmasýný saðlýyor
    {
        SpawnGem(NewGemIndex);
        GrowingGems.Insert(NewGemIndex, NewGem);
        NewGemIndex = 0;
    }

    public void SpawnGem(int GemIndex)
    {
        int RandomGem = Random.Range(0, (GemPrefab.Count));
        NewGem = (Instantiate(GemPrefab[RandomGem]
            , new Vector3(CellList[GemIndex].transform.position.x,
            CellList[GemIndex].transform.position.y + 1,
            CellList[GemIndex].transform.position.z)
            , Quaternion.identity));
        NewGem.name = GemIndex.ToString();
        NewGem.AddComponent<GemBreeder>();
    }
}
