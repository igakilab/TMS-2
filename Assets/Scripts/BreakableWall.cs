using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BreakableWall : Wall
{
    public int HP = 1; // 壁の耐久力

    public GameObject breakEffect;
    public AudioClip sound1;
    AudioSource audioSource;
    protected PlayerMovement playerMovement;

    private void Start() {
        //Debug.Log("score1:"+score);
        score = HP+2;
        //Debug.Log("HP"+HP);
       //Debug.Log("score2"+score);
        audioSource = GetComponent<AudioSource>();
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();

    }

    private void Update() {  
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        // 壁がプレイヤー以外のオブジェクトと衝突したときに耐久力を減らす
        if (collision.gameObject.tag == "Breaking"){
            HP--;
            //Debug.Log("Wall HP: " + HP);
        }else if(collision.gameObject.name == "Player"){
            playerMovement.Die();
        }
        if (HP <= 0){
            Destroy(this.gameObject); // HPが0になったら壁を破壊
            ScoreManager.addScore(score);
            GenerateExpEffect();
        } 
        base.OnCollisionEnter(collision); // Wallクラスの衝突処理も実行

        
    }
    void GenerateExpEffect()
    {
        //エフェクトを生成する
        GameObject effect = Instantiate(breakEffect) as GameObject;
        //エフェクトが発生する場所を決定する(敵オブジェクトの場所)
        effect.transform.position = gameObject.transform.position;
        audioSource.PlayOneShot(sound1);
        GameObject tempAudioObject = new GameObject("TempAudio");
        tempAudioObject.transform.position = transform.position; // 再生位置を現在のオブジェクトの位置に合わせる

        AudioSource tempAudioSource = tempAudioObject.AddComponent<AudioSource>();
        tempAudioSource.clip = sound1; // 再生するAudioClipを設定
        tempAudioSource.Play(); // 音声を再生

        // 音声の再生が終わった後に一時オブジェクトを削除
        Destroy(tempAudioObject, sound1.length);
    }
}