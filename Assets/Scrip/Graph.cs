using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField] Transform pointPrefab;
    [SerializeField, Range(10, 100)] int resolution = 10;
    Transform[] points;
    [SerializeField, Range(0,2)] int function;

    private void Awake()
    {
        var step = 2f / resolution;
        var position=Vector3.zero;
        var scale = Vector3.one *step;
        points = new Transform[resolution];
        for(int i=0;i<points.Length;i++)
        {
                         
            Transform point = points[i] = Instantiate(pointPrefab);
            position.x = (i + 0.5f) *step -1f;
            //position.y = position.x;
            position.y = position.x * position.x;
            point.localPosition=position;
            point.localScale = scale;
            point.SetParent(transform,false);
        }
    }
    private void Update()
    {
        float time = Time.time;
        for (int i = 0; i < points.Length; i++)
        {
            Transform point = points[i];
            Vector3 position = point.localPosition;
            if (function == 0)
            {
                position.y = FunctionLibrary.Wave(position.x, time);
            }
            else if (function == 1) 
            {
                position.y=FunctionLibrary.MultiWave(position.x, time);
            }
            else
            {
                position.y=FunctionLibrary.Ripple(position.x, time); 
            }
            point.localPosition = position;
        }
    }
}