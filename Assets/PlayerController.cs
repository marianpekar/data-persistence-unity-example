using UnityEngine;

public class PlayerController : MonoBehaviour
{
    void Update()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");

        Vector3 moveDirection = Vector3.right * horizontalAxis + Vector3.forward * verticalAxis;

        transform.Translate(moveDirection * Time.deltaTime, Space.World);
    }
}
