using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private GameObject objectToFollow;

    [SerializeField] private Tilemap _tilemap;
    
    private float xMax, xMin, yMax, yMin;
   
    private void Awake()
    {
        
    }


    private void Start()
    {
        

        Vector3 minTile = _tilemap.CellToWorld(_tilemap.cellBounds.min);
        Vector3 maxTile = _tilemap.CellToWorld(_tilemap.cellBounds.max);
        
        SetLimits(minTile, maxTile);
    }

    private void LateUpdate()
    {
        Transform target = objectToFollow.transform;
        transform.position = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax), Mathf.Clamp(target.position.y, xMin, yMax), -10);
    }


    private void SetLimits(Vector3 minTile, Vector3 maxTile)
    {
        Camera cam = Camera.main;

        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;

        xMin = minTile.x + width / 2;
        xMax = maxTile.x - width / 2;
        yMin = minTile.y + height / 2;
        yMax = maxTile.y - height / 2;
    }
}
