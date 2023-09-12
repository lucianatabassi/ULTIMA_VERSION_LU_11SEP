using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class prueba : MonoBehaviour
{
    public float walkSpeed = 5f;
    private CharacterController player;

    private Gyroscope gyro;
    private bool gyroSupported;

    private Transform cameraTransform;
    private Quaternion originalRotation;

    private void Awake()
    {
        player = GetComponent<CharacterController>();

        // Comprobar si el dispositivo admite el giroscopio
        gyroSupported = SystemInfo.supportsGyroscope;

        if (gyroSupported)
        {
            gyro = Input.gyro;
            gyro.enabled = true;

            // Guardar la rotación original de la cámara
            originalRotation = Camera.main.transform.rotation;
        }
        else
        {
            Debug.LogWarning("Gyroscope not supported on this device.");
        }
    }

    private void Update()
    {
        // Obtén las entradas de movimiento del jugador
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calcula la dirección de movimiento en relación con la cámara
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;
        cameraForward.y = 0f; // Mantén la dirección horizontal
        cameraRight.y = 0f;   // Mantén la dirección horizontal
        Vector3 moveDirection = cameraForward.normalized * verticalInput + cameraRight.normalized * horizontalInput;

        // Mueve al jugador en la dirección calculada
        player.Move(moveDirection.normalized * walkSpeed * Time.deltaTime);

        if (gyroSupported)
        {
            // Obtener la rotación del giroscopio
            Quaternion gyroRotation = gyro.attitude;

            // Aplicar la rotación del giroscopio a la cámara
            Camera.main.transform.rotation = originalRotation * gyroRotation;
        }
    }
}
