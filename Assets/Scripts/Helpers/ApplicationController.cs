using UnityEngine;

namespace GeometryDash
{
    public class ApplicationController : MonoBehaviour
    {
        [SerializeField] private int _targetFrameValue;
        void Start()
        {
            Application.targetFrameRate = _targetFrameValue;
        }
    }
}