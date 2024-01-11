using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private float horizontalInput;
    private float verticalInput;
    private float currentSteeringAngle;
    private float currentBrakingForce;
    private bool isBraking;

    [SerializeField] private float motorForce, brakeForce, maxSteerAngle;
    
    [SerializeField] private WheelCollider frontLeftWheelCollider, frontRightWheelCollider, backLeftWheelCollider, backRightWheelCollider;

    [SerializeField] private  Transform FrontLeftWheelTransform, FrontRightWheelTransform, BackLeftWheelTransform, BackRightWheelTransform;

    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheeks();
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);
        isBraking = Input.GetKey(KeyCode.Space);
    }

    private void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce;
        
        currentBrakingForce = isBraking ? brakeForce : 0f;
        ApplyBraking();
    }

    private void ApplyBraking()
    {
        frontLeftWheelCollider.brakeTorque = currentBrakingForce;
        frontRightWheelCollider.brakeTorque = currentBrakingForce;
        backLeftWheelCollider.brakeTorque = currentBrakingForce;
        backRightWheelCollider.brakeTorque = currentBrakingForce;
    }

    private void HandleSteering()
    {
        currentSteeringAngle = maxSteerAngle * horizontalInput;

        frontLeftWheelCollider.steerAngle = currentSteeringAngle;
        frontRightWheelCollider.steerAngle = currentSteeringAngle;
    }

    private void UpdateWheeks()
    {
        UpdateSingleWheel(frontLeftWheelCollider, FrontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, FrontRightWheelTransform);
        UpdateSingleWheel(backLeftWheelCollider, BackLeftWheelTransform);
        UpdateSingleWheel(backRightWheelCollider, BackRightWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;

        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
}