using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GemBreeder : MonoBehaviour//Gemlerin zaman i�inde b�y�meleri sa�lan�yor, boyutlar� 1 scale oldu�unda ya da karakter gemi toplad���nda b�y�me duruyor
{
    public bool CanBreed;
    private void OnEnable()
    {
        gameObject.transform.localScale = new Vector3(0,0,0);
        CanBreed = true;
        
    }

    private void FixedUpdate()
    {
        if (transform.localScale.x < 1.0f && CanBreed )
        {
            transform.localScale = Vector3.Slerp(transform.localScale,
                new Vector3(transform.localScale.x + 0.01f, transform.localScale.y + 0.01f, transform.localScale.z + 0.01f),
                (0.4f+(GemGrowSpeed.Instance.CurrentGrowSpeed/10)));
        }
        else
        {
            if (transform.localScale.x > 1.0f)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
            CanBreed = false;
        }
    }
}
