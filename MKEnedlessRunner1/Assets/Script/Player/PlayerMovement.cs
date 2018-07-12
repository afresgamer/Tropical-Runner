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
    public float FadeSpeed = 0.1f;
    bool isMove = true;

    static Dictionary<AnimState, int> animDict = new Dictionary<AnimState, int>()
    {
        {AnimState.Idle ,Animator.StringToHash("Idle")},
        {AnimState.Run, Animator.StringToHash("Run")},
        {AnimState.Jump, Animator.StringToHash("JUMP")}
    };

    Animator anim;
    Rigidbody rb;
    //Damage Event 
    Material[] materials;
    
	void Start () {
        Camera.main.GetComponent<PlayerCamera>().enabled = true;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        materials = GetComponentInChildren<Renderer>().materials;
        PlayerStatus.Instance.StartPos = transform.position;
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
        bool isAcceleration = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);

        Vector3 move = transform.forward * move_speed * 100 * Time.deltaTime + 
            transform.right * h * rot_Speed * 100 * Time.deltaTime;
        rb.velocity = move;
        rb.rotation = Quaternion.Euler(0, h * 30, 0);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger(animDict[AnimState.Jump]);
            rb.AddForce(Vector3.up * 100 * JumpPower);
        }
        if (isAcceleration) { rb.velocity *= 2; }

        Physics.gravity = new Vector3(0, -20, 0);
        anim.SetBool(animDict[AnimState.Run], rb.velocity != Vector3.zero);
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
        SceneController.Instance.ChangeScene("Result");
    }
}