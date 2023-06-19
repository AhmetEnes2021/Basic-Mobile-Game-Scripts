using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [Tooltip("Kameranýn Pozisyonu Ýle Karakter Pozisyonu Arasýnda Olmasý Ýstenen Fark")]
    [SerializeField]
    private Vector3 CameraPosToPlayer;
    private void FixedUpdate()//Kameranýn Karakteri Takip Etmesi Saðlanýyor
    {
        transform.position = Vector3.Slerp(transform.position,
            new Vector3(PlayerController.Instance.transform.position.x + CameraPosToPlayer.x,
            transform.position.y + CameraPosToPlayer.y,
            PlayerController.Instance.transform.position.z + CameraPosToPlayer.z), 1f) ;
    }
}
