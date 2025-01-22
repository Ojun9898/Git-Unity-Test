using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] private GameObject[] maps;
    
    private Vector2 _startPosition;
    
    private int _mapIndex = 0;
    private const float MapSize = 9.0f;
    
    private const float Speed = 3.0f;

    private void Start()
    {
        _startPosition = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position += Vector3.down * (Time.deltaTime * Speed);

        if (maps[_mapIndex].transform.position.y < -MapSize)
        {
            maps[_mapIndex].transform.position = new Vector2(0, MapSize * 2);
            _mapIndex++;
        }

        if (_mapIndex >= maps.Length)
        {
            _mapIndex = 0;
        }
    }
}
