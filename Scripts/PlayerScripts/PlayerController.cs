using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [Tooltip("Kullanýlan Joystic Objesinin Alt Objesi Dlan Background Objesi ")]
    public GameObject JoysticBackground;
    [Space]
    [Tooltip("Karakter Hýzý")]
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
        //Joystic'in ortaya olan uzaklýðýný denetleyip yeterince uzak ise karakterin yürümesi saðlanýyor (bu denetleme yapýlmadýðýnda karakter kýpýrdamasa bile koþu animasyonu yapýyor)
        if ((Mathf.Abs(FloatingJoystick.Instace.Horizontal) >= 0.4f || Mathf.Abs(FloatingJoystick.Instace.Vertical) >= 0.4f) && JoysticBackground.activeSelf == true)
        {
            WalkDirection = Vector3.forward * FloatingJoystick.Instace.Vertical + Vector3.right * FloatingJoystick.Instace.Horizontal;//Joystick'den gelen bilgiler ile karakterin gideceði yönü ve hýzý buluyor
            Rigid.velocity = Vector3.Slerp(Rigid.velocity, WalkDirection * (PlayerSpeed * 10) * Time.fixedDeltaTime, 1f);//Karakteri hateket ettiriyor
            transform.rotation = Quaternion.LookRotation(WalkDirection);//karakterin baktýðý yönü ayarlýyor
            PlayerAnimator.SetBool("IsRunning", true);//Koþu Animasyonu Baþlatýyor
        }
        else
        {
            Rigid.velocity = Vector3.Slerp(Rigid.velocity, new Vector3(0f, 0f, 0f),1f);//Karakteri hareketi sýfýrlanýyor
            PlayerAnimator.SetBool("IsRunning", false);//idle animasyonu baþlatýyor
        }
    }
}
