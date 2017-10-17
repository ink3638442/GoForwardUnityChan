using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{

    private float speed = -0.2f;

    private float deadLine = -10;

    private float groundLevel = -3.0f;

    // コンポーネント
    AudioSource se;
    // 効果音
    AudioClip blockSE;

    // 再生済フラグ
    private bool isPlayed = false;


    // Use this for initialization
    void Start()
    {
        this.se      = GetComponent<AudioSource>();
        this.blockSE = this.se.clip;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(this.speed, 0, 0);

        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
	{
        // OnCollisionEnter動作時、Cubeの上下で２重判定してしまう防止策として再生済フラグを追加 未再生のキューブのみ対象とする
        if ((isPlayed == false) && (other.gameObject.tag == "GroundTag" || other.gameObject.tag == "CubeTag"))
        {
            this.se.PlayOneShot(this.blockSE, 1);

            // 再生済フラグをオンにする
            this.isPlayed = true;
        }
    }
}
