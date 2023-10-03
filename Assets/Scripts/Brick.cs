using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [Header("Platform size booster")]
    [SerializeField] GameObject platformBoostPref;
    [SerializeField][Range(0, 100)] int platformBoostDropChance;

    [Header("Platform size reductor")]
    [SerializeField] GameObject platformReducerPref;
    [SerializeField][Range(0, 100)] int platformReducerDropChance;

    [Header("Extra game ball")]
    [SerializeField] GameObject extraBallPref;
    [SerializeField][Range(0, 100)] int extraBallDropChance;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<GameBall>() != null)
        {
            //Platform size booster
            if (platformBoostDropChance > Random.Range(1, 101))
                Instantiate(platformReducerPref, transform.position, Quaternion.identity);

            //Platform size reductor
            if (platformReducerDropChance > Random.Range(1, 101))
                Instantiate(platformBoostPref, transform.position, Quaternion.identity);

            //Extra game ball
            if (extraBallDropChance > Random.Range(1, 101))
                Instantiate(extraBallPref, transform.position, Quaternion.identity);
        }
    }
}
