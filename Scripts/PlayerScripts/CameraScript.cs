using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [Tooltip("Kameran�n Pozisyonu �le Karakter Pozisyonu Aras�nda Olmas� �stenen Fark")]
    [SerializeField]
    private Vector3 CameraPosToPlayer;
    private void FixedUpdate()//Kameran�n Karakteri Takip Etmesi Sa�lan�yor
    {
        transform.position = Vector3.Slerp(transform.position,
            new Vector3(PlayerController.Instance.transform.position.x + CameraPosToPlayer.x,
            transform.position.y + CameraPosToPlayer.y,
            PlayerController.Instance.transform.position.z + CameraPosToPlayer.z), 1f) ;
    }
}
