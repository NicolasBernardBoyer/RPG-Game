using UnityEngine;

namespace RPG.Saving
{
    [System.Serializable]
    public class SerializableVector3T
    {
        float x, y, z;

        public SerializableVector3T(Vector3 vector)
        {
            x = vector.x;
            y = vector.y;
            z = vector.z;
        }

        public Vector3 ToVector()
        {
            return new Vector3(x, y, z);
        }
    }
}