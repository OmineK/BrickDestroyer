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
}
