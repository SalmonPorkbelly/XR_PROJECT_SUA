using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    public enum PROJECTILETYPE
    {
        PLAYER,
        MONSTER
    }
    public Vector3 launchDirection; // 발사방향

    public PROJECTILETYPE projectileType;


    private void FixedUpdate() {
        float moveAmount = 3 * Time.fixedDeltaTime; // 이동 속도 설정
        transform.Translate(launchDirection * moveAmount); // translate로 이동
    }

    // private void OnCollisionEnter(Collision collision) {
    //     Debug.Log(collision.gameObject.name);
    //     if (collision.gameObject.tag == "Object") // Tag 값이 오브젝트인 경우
    //     {
    //         Destroy(this.gameObject);
    //     }
    //     if (collision.gameObject.tag == "Monster") // Tag 값이 Monster인 경우
    //     {
    //         Destroy(this.gameObject);
    //         collision.gameObject.GetComponent<Monster>().Damaged(1);
    //     }
    // }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Monster") && projectileType == PROJECTILETYPE.PLAYER) //Tag를 검사한다.
        {
            Destroy(this.gameObject);
            other.gameObject.GetComponent<Monster>().Damaged(1);
            GameObject temp = GameObject.FindGameObjectWithTag("GameManager");
            temp.GetComponent<HUDTextManager>().UpdateHUDTextSet("1", other.gameObject, new Vector3(0.0f, 10.0f, 0.0f));
        }

        if(other.CompareTag("Player") && projectileType == PROJECTILETYPE.MONSTER) //Tag를 검사한다.
        {
            Destroy(this.gameObject);
            other.gameObject.GetComponent<PlayerHp>().Damaged(1);
        }
    }
}
