using UnityEngine;
namespace GeometryDash
{
    public class ApplicationController : MonoBehaviour
    { 
        [SerializeField] private int targetFrameValue;
        void Start()
        {
            Application.targetFrameRate = targetFrameValue;
        }
    }
}