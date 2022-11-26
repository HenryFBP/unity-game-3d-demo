using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    [SerializeField] float speedX = 0f;
    [SerializeField] float speedY = 0.5f;
    [SerializeField] float speedZ = 0f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(
            360 * speedX * Time.deltaTime,
            360 * speedY * Time.deltaTime,
            360 * speedZ * Time.deltaTime
            );
    }
}
