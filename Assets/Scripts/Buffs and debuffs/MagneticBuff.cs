using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticBuff : BuffEntity
{
    [SerializeField] float magneticBuffDuration;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.magneticBuffTimer = magneticBuffDuration;

            Destroy(this.gameObject);
        }
    }
}
