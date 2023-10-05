using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticBuff : BuffEntity
{
    [SerializeField] float magneticBuffDuration;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        if (collision.gameObject.GetComponent<Player>() != null)
        {
            Player player = collision.gameObject.GetComponent<Player>();

            if (player.magneticBuffTimer < 0)
                player.magneticBuffTimer = magneticBuffDuration;
            else
                player.magneticBuffTimer += magneticBuffDuration;

            Destroy(this.gameObject);
        }
    }
}
