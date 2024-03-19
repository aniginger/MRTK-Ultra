using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Root.UI
{
    public class CameraAdjust : MonoBehaviour
    {
        private Transform offsetTransform;
        private Transform cameraTransform;
        
        [SerializeField] private Camera mainCamera;
        
        // Start is called before the first frame update
        void Start()
        {
            offsetTransform = transform;
            cameraTransform = mainCamera.transform;
        }

        /// <summary>
        /// Adjust the camera offset to negate the user's viewport
        /// </summary>
        public void CenterCamera()
        {
            // Obtain the camera's position and rotation
            Vector3 cameraPosition = cameraTransform.localPosition;
            Vector3 cameraRotation = cameraTransform.eulerAngles;

            // Set the offset to the negative of the camera's position and rotation to mimic 0
            offsetTransform.position = -cameraPosition;
            // offsetTransform.rotation = Quaternion.Euler(-cameraRotation);
        }
    }
}
