using UnityEngine;

namespace Code.Scripts.Character
{
    public interface ICameraTargetInfo
    {
        Vector3 GetCameraPosition();
        Quaternion GetCameraRotation();
    }
}