using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [Tooltip("Kullan�lan Joystic Objesinin Alt Objesi Dlan Background Objesi ")]
    public GameObject JoysticBackground;
    [Space]
    [Tooltip("Karakter H�z�")]
    [SerializeField] private float PlayerSpeed;


    public static PlayerController Instance;
    private Rigidbody Rigid;
    private Animator PlayerAnimator;
    Vector3 WalkDirection;

    private void Awake()
    {
        Instance = this;
        Rigid = GetComponent<Rigidbody>();
        PlayerAnimator = GetComponent<Animator>();
    }


    private void FixedUpdate()
    {
        //Joystic'in ortaya olan uzakl���n� denetleyip yeterince uzak ise karakterin y�r�mesi sa�lan�yor (bu denetleme yap�lmad���nda karakter k�p�rdamasa bile ko�u animasyonu yap�yor)
        if ((Mathf.Abs(FloatingJoystick.Instace.Horizontal) >= 0.4f || Mathf.Abs(FloatingJoystick.Instace.Vertical) >= 0.4f) && JoysticBackground.activeSelf == true)
        {
            WalkDirection = Vector3.forward * FloatingJoystick.Instace.Vertical + Vector3.right * FloatingJoystick.Instace.Horizontal;//Joystick'den gelen bilgiler ile karakterin gidece�i y�n� ve h�z� buluyor
            Rigid.velocity = Vector3.Slerp(Rigid.velocity, WalkDirection * (PlayerSpeed * 10) * Time.fixedDeltaTime, 1f);//Karakteri hateket ettiriyor
            transform.rotation = Quaternion.LookRotation(WalkDirection);//karakterin bakt��� y�n� ayarl�yor
            PlayerAnimator.SetBool("IsRunning", true);//Ko�u Animasyonu Ba�lat�yor
        }
        else
        {
            Rigid.velocity = Vector3.Slerp(Rigid.velocity, new Vector3(0f, 0f, 0f),1f);//Karakteri hareketi s�f�rlan�yor
            PlayerAnimator.SetBool("IsRunning", false);//idle animasyonu ba�lat�yor
        }
    }
}
