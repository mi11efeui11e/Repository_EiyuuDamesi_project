using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform player;  // プレイヤーのTransform
    public float rotationSpeed = 2f;  // 回転速度

    void Update()
    {
        if (player == null) return;

        // プレイヤーの方向を向くためのターゲット回転
        Quaternion targetRotation = Quaternion.LookRotation(player.position - transform.position);

        // スムーズに回転（Slerpで補間）
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
