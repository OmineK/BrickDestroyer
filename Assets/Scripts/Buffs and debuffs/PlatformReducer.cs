using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformReducer : BuffEntity
{
    [SerializeField] float reductionSize;

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
                ReduceSize(player);

            Destroy(this.gameObject);
        }
    }

    void ReduceSize(Player player)
    {
        if (player.transform.localScale.x > player.minPlatformSize)
        {
            float newXScale = Mathf.Round((player.transform.localScale.x - reductionSize) * 10f) * 0.1f;
            player.transform.localScale = new Vector3(newXScale, player.transform.localScale.y, player.transform.localScale.z);
        }
        else
            player.transform.localScale = new Vector3(player.minPlatformSize, player.transform.localScale.y, player.transform.localScale.z);
    }
}
