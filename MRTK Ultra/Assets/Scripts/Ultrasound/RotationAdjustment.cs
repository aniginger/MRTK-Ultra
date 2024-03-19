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
            if (!isAdjustingRotation) return;
            
            Vector3 eulerAngles = targetTransform.eulerAngles;
            Vector3 eulerRotation = new(eulerAngles.x, eulerAngles.y, eulerAngles.z);
            
            imageTransform.rotation = Quaternion.Euler(eulerRotation);
            canvasTransform.rotation = Quaternion.Euler(eulerRotation);
        }
    }
}
