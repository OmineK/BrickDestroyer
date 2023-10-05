using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraBall : BuffEntity
{
    [SerializeField] GameObject gameBallPref;

    protected override void Update()
    {
        base.Update();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        if (collision.gameObject.GetComponent<Player>() != null)
        {
            Player player = collision.gameObject.GetComponent<Player>();

            float newY = player.transform.position.y + 0.7f;
            Vector3 newBallPos = new Vector3(transform.position.x, newY);

            Instantiate(gameBallPref, newBallPos, Quaternion.identity);

            Destroy(this.gameObject);
        }
    }
}
