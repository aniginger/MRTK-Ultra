using Root.Ultrasound;
using UnityEngine;

namespace Root.UI
{
    public class ButtonFunctions : MonoBehaviour
    {
        private ImageLoader imageLoader;
        private CameraAdjust cameraAdjust;
        
        // Start is called before the first frame update
        void Start()
        {
            imageLoader = FindObjectOfType<ImageLoader>();
            cameraAdjust = FindObjectOfType<CameraAdjust>();
        }

        /// <summary>
        /// Pause the stream of images coming in from the probe
        /// </summary>
        public void PauseImaging()
        {
            imageLoader.isPaused = !imageLoader.isPaused;
        }

        /// <summary>
        /// Change whether the data path text display is visible
        /// </summary>
        public void ToggleDataPathText()
        {
            imageLoader.dataPathText.enabled = !imageLoader.dataPathText.enabled;
        }

        /// <summary>
        /// Recenter the camera to the user's current viewport
        /// </summary>
        public void RecenterCamera()
        {
            cameraAdjust.CenterCamera();
        }
    }
}
