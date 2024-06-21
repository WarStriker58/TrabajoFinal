using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    private Vector2 moveInput;

    public void OnMovement(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    void Update()
    {
        Vector3 movement = new Vector3(moveInput.x, 0.0f, moveInput.y);

        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
    }

    //Despues borrar
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            SceneManager.LoadScene("DefeatScene");
        }
        else if (collision.gameObject.CompareTag("Victory"))
        {
            SceneManager.LoadScene("VictoryScene");
        }
    }
}