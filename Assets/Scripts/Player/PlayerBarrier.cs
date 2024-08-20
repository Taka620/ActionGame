using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBarrier : MonoBehaviour
{
    [SerializeField] private GameObject barrier;
    [SerializeField] private GameObject playerCollider;
    [SerializeField] private GameObject barrierR;
    [SerializeField] private GameObject barrierNR;
    private bool canBarrier;
    private float lastBarrierTime;
    private float continueTime;
    private float cooltime;

    private void Start()
    {
        barrier.SetActive(false);
        playerCollider.SetActive(true);
        canBarrier = true;
        barrierR.SetActive(canBarrier);
        barrierNR.SetActive(!canBarrier);
        lastBarrierTime = 0;
        continueTime = 1.8f;
        cooltime = 7.5f;
    }

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Space) && canBarrier)
        {
            UseBarrier();
        }
        ManageBarrier();
    }

    private void UseBarrier()
    {
        //バリアを追加し、コライダーを非アクティブ
        barrier.SetActive(true);
        playerCollider.SetActive(false);
        lastBarrierTime = Time.time;
        canBarrier = false;
        barrierR.SetActive(canBarrier);
        barrierNR.SetActive(!canBarrier);

    }

    private void ManageBarrier()
    {
        //クールダウンが戻ってきた
        if (Time.time - lastBarrierTime >= cooltime)
        {
            canBarrier = true;
            barrierR.SetActive(canBarrier);
            barrierNR.SetActive(!canBarrier);

        }

        // 使用時間が過ぎた。
        if (Time.time - lastBarrierTime >= continueTime && !canBarrier)
        {
            // バリアを消してコライダーをアクティブに
            barrier.SetActive(false);
            playerCollider.SetActive(true);
        }
    }

}
