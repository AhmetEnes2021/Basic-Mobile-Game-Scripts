using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddGemOnInspector : MonoBehaviour
{//Oyuna yeni gemler eklenmek istenir ise inspector �zerinden bu scrip i�erisindeki listeye ekleme yap�l�yor Tek bir oyun objesinde olmas� yeterli, birden fazla oyun objesi i�erisinde olmas�na gerek yok
    public static AddGemOnInspector Instance;
    public List<GemProperties> GemProperties = new List<GemProperties>();
    private void Awake()
    {
        Instance = this;
    }
}
