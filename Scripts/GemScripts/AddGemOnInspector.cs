using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddGemOnInspector : MonoBehaviour
{//Oyuna yeni gemler eklenmek istenir ise inspector üzerinden bu scrip içerisindeki listeye ekleme yapýlýyor Tek bir oyun objesinde olmasý yeterli, birden fazla oyun objesi içerisinde olmasýna gerek yok
    public static AddGemOnInspector Instance;
    public List<GemProperties> GemProperties = new List<GemProperties>();
    private void Awake()
    {
        Instance = this;
    }
}
