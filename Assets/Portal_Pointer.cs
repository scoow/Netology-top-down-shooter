using System;
using System.Collections;
using System.Collections.Generic;
using TDShooter.Level;
using UnityEngine;

public class Portal_Pointer : MonoBehaviour
{
    [SerializeField] Transform _playerTransform;
    [SerializeField] Camera _camera;
    [SerializeField] GameObject _portalIcon;

    
    void Update()
    {
        Vector3 fromPlayerToPortal = transform.position - _playerTransform.position;
        Ray ray = new Ray(_playerTransform.position, fromPlayerToPortal);

        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(_camera);

        float minDistance = Mathf.Infinity;
        int index =0;

        for(int i =0; i <4; i++)
        {
            if (planes[i].Raycast(ray,out float  distance))
            {
                if(distance < minDistance)
                {
                    minDistance = distance;
                    index = i;
                }
            }
        }

        minDistance = Mathf.Clamp(minDistance, 0, fromPlayerToPortal.magnitude);
        Vector3 worldPosition = ray.GetPoint(minDistance);
        Vector3 position = _camera.WorldToScreenPoint(worldPosition);
        Quaternion rotation = GetPortalIconRotation(index);

        if (fromPlayerToPortal.magnitude > minDistance)
        {
            _portalIcon.gameObject.SetActive(true);
        }
        else
            _portalIcon.gameObject.SetActive(false);

        _portalIcon.transform.SetPositionAndRotation(position, rotation);

    }

    private Quaternion GetPortalIconRotation(int index)
    {
        if(index == 0) return Quaternion.Euler(0, 0, 90f);
        else if(index == 1) return Quaternion.Euler(0, 0, -90f);
        else if(index == 2) return Quaternion.Euler(0, 0, 180f);
        else if(index == 3) return Quaternion.Euler(0, 0, 0);
        return Quaternion.identity;
    }
}
