using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [Header("Platform size booster")]
    [SerializeField] GameObject platformBoostPref;
    [SerializeField][Range(0, 100)] int platformBoostDropChance;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<GameBall>() != null)
        {
            if (platformBoostDropChance > Random.Range(1, 101))
                Instantiate(platformBoostPref, transform.position, Quaternion.identity);
        }
    }
}
