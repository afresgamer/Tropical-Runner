using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour {

    public enum AnimState { Idle,Run,Jump }
    private AnimState animState;
    [SerializeField, Header("プレイヤーのスピード")]
    private float move_speed = 1;
    [SerializeField, Header("プレイヤーの左右スピード")]
    private float rot_Speed = 1;
    [SerializeField, Header("プレイヤーのジャンプ力")]
    private float JumpPower = 10;
    [SerializeField, Header("プレイヤーのダメージエフェクト間隔")]
    private float FadeSpeed = 0.1f;
    [SerializeField, Header("プレイヤーの加速力")]
    private float SpeedUpValue = 1.5f;
    bool isMove = false;

    static Dictionary<AnimState, int> animDict = new Dictionary<AnimState, int>()
    {
        {AnimState.Run, Animator.StringToHash("Run")},
        {AnimState.Jump, Animator.StringToHash("Jump")}
    };
    Vector3 move = new Vector3();
    Animator anim;
    CharacterController cCtrl;
    //Damage Event 
    Material[] materials;
    bool isAcceleration;


    void Start () {
        Camera.main.GetComponent<PlayerCamera>().enabled = true;
        anim = GetComponent<Animator>();
        cCtrl = GetComponent<CharacterController>();
        materials = GetComponentInChildren<Renderer>().materials;
        PlayerStatus.Instance.StartPos = transform.position;
        StartCoroutine(StartBetween());
    }
	
	void Update () {
        // 距離測定
        PlayerStatus.Instance.NowPos = transform.position;
        float f_distance = Vector3.Distance(PlayerStatus.Instance.NowPos, PlayerStatus.Instance.StartPos);
        PlayerStatus.Instance.Distance = (int)f_distance;
        //　移動
        if (isMove) Move();
    }

    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        //Acceleration
        isAcceleration = Input.GetKey(KeyCode.U) || Input.GetKey(KeyCode.UpArrow);

        move = transform.forward * move_speed * 100 * Time.deltaTime + 
            transform.right * h * rot_Speed * 100 * Time.deltaTime;
        if (isAcceleration) { cCtrl.SimpleMove(move * SpeedUpValue); }
        cCtrl.SimpleMove(move);
        transform.rotation = Quaternion.Euler(0, h * 30, 0);
        
        if (Input.GetKeyDown(KeyCode.Space) && cCtrl.isGrounded) { cCtrl.Move(Vector3.up * JumpPower); }

        anim.SetBool(animDict[AnimState.Jump], !cCtrl.isGrounded);
        anim.SetBool(animDict[AnimState.Run], cCtrl.velocity != Vector3.zero);
    }

    
    /// <summary>
    /// プレイヤー移動用ボタンイベント
    /// </summary>
    public void MoveRight()
    {
        if (isMove)
        {
            move -= transform.position + transform.right * move_speed;
            transform.DORotate(new Vector3(0, 45, 0), 0.5f);
        }
    }

    public void MoveLeft()
    {
        if (isMove)
        {
            move += transform.position + transform.right * move_speed;
            transform.DORotate(new Vector3(0, -45, 0), 0.5f);
        }
    }

    public void Jump()
    {
        if (isMove && cCtrl.isGrounded) { cCtrl.Move(Vector3.up * JumpPower); }
    }
    
    public void SpeedUpMove()
    {
        isAcceleration = true;
        StartCoroutine(SpeedUpBetween());
    }

    /// <summary>
    /// ダメージ関係処理
    /// </summary>
    public void Damage()
    {
        isMove = false;
        if (PlayerStatus.Instance.Hp > 0) { PlayerStatus.Instance.Hp--; StartCoroutine(DamageEffect()); }
        if(PlayerStatus.Instance.Hp == 0) { Death(); }
    }

    private IEnumerator SpeedUpBetween()
    {
        yield return new WaitForSeconds(1.0f);
        isAcceleration = false;
    }

    private IEnumerator StartBetween()
    {
        AnimatorStateInfo animatorStateInfo = anim.GetCurrentAnimatorStateInfo(0);
        yield return animatorStateInfo.fullPathHash == animDict[AnimState.Run];
        isMove = true;
    }
    
    private IEnumerator DamageEffect()
    {
        yield return new WaitForSeconds(0.2f);
        for (int i = 0; i < materials.Length; i++)
        {
            materials[i].DOFade(0, FadeSpeed);
        }
        yield return new WaitForSeconds(0.2f);
        for (int i = 0; i < materials.Length; i++)
        {
            materials[i].DOFade(1, FadeSpeed);
        }
        isMove = true;
    }

    private void Death()
    {
        isMove = false;
        Camera.main.GetComponent<PlayerCamera>().enabled = false;
        Destroy(gameObject);
        SceneController.Instance.ChangeScene(SceneController.Scenes.Result);
    }

    /// <summary>
    /// 海面に落ちたら即死処理
    /// </summary>
    /// <param name="hit"></param>
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "Wave")
        {
            Death();
        }
    }
}