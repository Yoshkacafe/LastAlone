using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaMeRaFoLlOw : MonoBehaviour
{
    [SerializeField] private Vector3 Offset;
    [SerializeField] private Transform target;
    [SerializeField] private float translationSpeed;
    [SerializeField] private float rotationSpeed;

    private void FixedUpdate()
    {
        HandleTranslation();
        HandleRotation();
    } 

    public void HandleTranslation()
    {
        Vector3 targetPosition = target.TransformPoint(Offset);
        transform.position = Vector3.Lerp(transform.position, targetPosition, translationSpeed * Time.deltaTime);
    }

    private void HandleRotation()
    {
        var direction = target.position - transform.position;
        var rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}
