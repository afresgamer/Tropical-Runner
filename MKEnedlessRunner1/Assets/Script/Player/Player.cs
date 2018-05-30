﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour {

    public enum AnimState { Idle,Run,Jump }
    private AnimState animState;
    [SerializeField, Header("プレイヤーのスピード")]
    private float move_speed = 1;
    [SerializeField, Header("プレイヤーの左右スピード")]
    private float rot_Speed = 1;
    [SerializeField, Header("プレイヤーのジャンプ力")]
    private float JumpPower = 10;

    static Dictionary<AnimState, int> animDict = new Dictionary<AnimState, int>()
    {
        {AnimState.Idle ,Animator.StringToHash("Idle")},
        {AnimState.Run, Animator.StringToHash("Run")},
        {AnimState.Jump, Animator.StringToHash("JUMP")}
    };

    //Hp
    private int hp = 3;
    public int Hp { get { return hp; } set { hp = value; } }
    //Item Point
    private int itemScorePoint = 0;
    public int ItemScorePoint { get { return itemScorePoint; }
        set { if(value > 0)itemScorePoint = value; }
    }
    //Distance
    private Vector3 StartPos;
    private Vector3 NowPos;
    private float distance = 0;
    public float Distance { get { return distance; } }
    Animator anim;
    Rigidbody rb;
    Material[] materials;
    
	void Start () {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        materials = GetComponentInChildren<Renderer>().materials;
        //StartPos = transform.position;
	}
	
	void Update () {
        //NowPos = transform.position;
        //distance = Vector3.Distance(NowPos, StartPos);
        Move();
	}

    public void Move()
    {
        float h = Input.GetAxis("Horizontal");

        Vector3 move = transform.forward * move_speed * 100 * Time.deltaTime + 
            transform.right * h * rot_Speed * 100 * Time.deltaTime;
        rb.velocity = move;

        rb.rotation = Quaternion.Euler(0, h * 30, 0);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger(animDict[AnimState.Jump]);
            rb.AddForce(Vector3.up * 100 * JumpPower);
        }

        Physics.gravity = new Vector3(0, -20, 0);
        anim.SetBool(animDict[AnimState.Run], rb.velocity != Vector3.zero);
    }
    
    public void Damage()
    {
        StartCoroutine(DamageEffect());
    }
    
    IEnumerator DamageEffect()
    {
        for(int i = 0; i < materials.Length; i++)
        {
            materials[i].DOFade(0, 0.1f);
        }
        yield return new WaitForSeconds(0.1f);
        for (int i = 0; i < materials.Length; i++)
        {
            materials[i].DOFade(1, 0.1f);
        }
    }
}