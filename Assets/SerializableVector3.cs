using System;
using UnityEngine;

[Serializable]
public struct SerializableVector3
{
    public float x, y, z;
    public static SerializableVector3 FromVector3(Vector3 v) => new SerializableVector3 { x = v.x, y = v.y, z = v.z };
    public static Vector3 ToVector3(SerializableVector3 s) => new Vector3 { x = s.x, y = s.y, z = s.z };
}
