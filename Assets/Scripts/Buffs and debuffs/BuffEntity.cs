using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffEntity : MonoBehaviour
{
    [SerializeField] float fallingSpeed;

    protected virtual void Update()
    {
        FallingMovement();
    }

    void FallingMovement()
    {
        float newYPos = transform.position.y - (fallingSpeed * Time.deltaTime);

        transform.position = new Vector3(transform.position.x, newYPos);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            AudioManager.instance.PlaySFX(0);
        }
    }
}
