using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBoost : BuffEntity
{
    [SerializeField] float boostSize;

    protected override void Update()
    {
        base.Update();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            Player player = collision.gameObject.GetComponent<Player>();

            if (player.magneticBuffTimer < 0)
                BoostSize(player);

            Destroy(this.gameObject);
        }
    }

    void BoostSize(Player player)
    {
        if (player.transform.localScale.x < player.maxPlatformSize)
        {

            float newXScale = Mathf.Round((player.transform.localScale.x + boostSize) * 10f) * 0.1f;
            player.transform.localScale = new Vector3(newXScale, player.transform.localScale.y, player.transform.localScale.z);
        }
        else
            player.transform.localScale = new Vector3(player.maxPlatformSize, player.transform.localScale.y, player.transform.localScale.z);
    }
}
