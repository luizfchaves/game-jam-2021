using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSpear : MonoBehaviour
{
    public AudioSource audioData;
    Player player;
    public GameObject spear;
    public float rateByMinute = 1f;
    bool isAbleToThrow = true; 

    void Start()
    {
        player = GetComponent<Player>();
    }
    IEnumerator spearCoolDown() {
        isAbleToThrow = false;
        audioData.Play(0);
        Instantiate(spear, player.transform.position, Quaternion.Euler(0, 0, 0));
        yield return new WaitForSeconds(60/rateByMinute); ;
        isAbleToThrow = true;
    }

    void Update(){
        if (isAbleToThrow && player.isAttacking) {
            StartCoroutine(spearCoolDown());
        }
    }
}
