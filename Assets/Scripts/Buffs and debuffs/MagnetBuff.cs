using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetBuff : BuffEntity
{
    [SerializeField] float magnetDuration;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.magnetBuffTimer = magnetDuration;

            Destroy(this.gameObject);
        }
    }
}
