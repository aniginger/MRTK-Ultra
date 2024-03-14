using UnityEngine;

namespace Root.Ultrasound
{
    public class RotationAdjustment : MonoBehaviour
    {
        [SerializeField] private Transform targetTransform;
    
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 eulerAngles = targetTransform.eulerAngles;
            Vector3 eulerRotation = new(eulerAngles.x, eulerAngles.y, eulerAngles.z);
            transform.rotation = Quaternion.Euler(eulerRotation);
        }
    }
}
