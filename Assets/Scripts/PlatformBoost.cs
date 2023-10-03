using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBoost : MonoBehaviour
{
    [SerializeField] float boostSize;
    [SerializeField] float fallingSpeed;

    void Update()
    {
        FallingMovement();
    }

    void FallingMovement()
    {
        float newYPos = transform.position.y - (fallingSpeed * Time.deltaTime);

        transform.position = new Vector3(transform.position.x, newYPos);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            Player player = collision.gameObject.GetComponent<Player>();

            if (player.transform.localScale.x < player.maxPlatformSize)
            {
                float newXScale = player.transform.localScale.x + boostSize;
                player.transform.localScale = new Vector3(newXScale, player.transform.localScale.y, player.transform.localScale.z);
            }
            else
                player.transform.localScale = new Vector3(player.maxPlatformSize, player.transform.localScale.y, player.transform.localScale.z);
                

            Destroy(this.gameObject);
        }
    }
}