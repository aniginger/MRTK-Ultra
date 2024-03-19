using UnityEngine;

namespace Root.Ultrasound
{
    public class RotationAdjustment : MonoBehaviour
    {
        [SerializeField] private bool isAdjustingRotation = true;
        [SerializeField] private Transform targetTransform;

        // Update is called once per frame
        void Update()
        {
            if (!isAdjustingRotation) return;
            
            Vector3 eulerAngles = targetTransform.eulerAngles;
            Vector3 eulerRotation = new(eulerAngles.x, eulerAngles.y, eulerAngles.z);
            transform.rotation = Quaternion.Euler(eulerRotation);
        }
    }
}
