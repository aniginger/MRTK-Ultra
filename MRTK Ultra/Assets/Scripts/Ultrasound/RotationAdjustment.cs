using UnityEngine;

namespace Root.Ultrasound
{
    public class RotationAdjustment : MonoBehaviour
    {
        [Header("Rotation settings")]
        [SerializeField] private bool isAdjustingRotation = true;
        [SerializeField] private Transform targetTransform;

        [Header("Objects to rotate")]
        [SerializeField] private Transform imageTransform;
        [SerializeField] private Transform canvasTransform;

        // Update is called once per frame
        void Update()
        {
            if (isAdjustingRotation) RotateTowardCamera();
        }

        /// <summary>
        /// Rotate object so it is always facing the camera
        /// Makes the user feel they are looking at a 2D image instead of a 3D model
        /// </summary>
        private void RotateTowardCamera()
        {
            Vector3 eulerAngles = targetTransform.eulerAngles;
            Vector3 eulerRotation = new(eulerAngles.x, eulerAngles.y, eulerAngles.z);
            
            imageTransform.rotation = Quaternion.Euler(eulerRotation);
            // Canvas no longer needs to rotate as it is using a hand menu; uncomment below if needed
            // canvasTransform.rotation = Quaternion.Euler(eulerRotation);
        }
    }
}
