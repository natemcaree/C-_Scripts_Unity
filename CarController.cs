using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private float horizontalInput;
    private float verticalInput;
    private float currentsteerAngle;
    private float steerAngle;
    private float currentbreakForce;
    private bool isBreaking;
    

    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteeringAngle;

    [SerializeField] private WheelCollider FLWheelCollider;
    [SerializeField] private WheelCollider FRWheelCollider;
    [SerializeField] private WheelCollider BLWheelCollider;
    [SerializeField] private WheelCollider BRWheelCollider;

    [SerializeField] private Transform FLWheelTransform;
    [SerializeField] private Transform FRWheelTransform;
    [SerializeField] private Transform BLWheelTransform;
    [SerializeField] private Transform BRWheelTransform;

    private void FixedUpdate()
    { 
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }
    private void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);
        isBreaking = Input.GetKey(KeyCode.Space);

    }
    private void HandleMotor()
    {
        FLWheelCollider.motorTorque = verticalInput * motorForce * 1000f;
        FRWheelCollider.motorTorque = verticalInput * motorForce * 1000f;
        currentbreakForce = isBreaking ? breakForce : 0f;

        ApplyBreaking();
        
    }
    private void ApplyBreaking()
    {
        FLWheelCollider.brakeTorque = currentbreakForce;
        FRWheelCollider.brakeTorque = currentbreakForce;
        BLWheelCollider.brakeTorque = currentbreakForce;
        BRWheelCollider.brakeTorque = currentbreakForce;

    }
    private void HandleSteering()
    {
        currentsteerAngle = maxSteeringAngle * horizontalInput;
        FLWheelCollider.steerAngle = currentsteerAngle;
        FRWheelCollider.steerAngle = currentsteerAngle;

    }
    private void UpdateWheels ()
    {
        UpdateSingleWheel(FLWheelCollider, FLWheelTransform);
        UpdateSingleWheel(FRWheelCollider, FRWheelTransform);
        UpdateSingleWheel(BLWheelCollider, BLWheelTransform);
        UpdateSingleWheel(BRWheelCollider, BRWheelTransform);
    }
    
    private void UpdateSingleWheel(WheelCollider WheelCollider, Transform WheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        WheelCollider.GetWorldPose(out pos, out rot);
        WheelTransform.rotation = rot;
        WheelTransform.position = pos;
    }

    

    
}
