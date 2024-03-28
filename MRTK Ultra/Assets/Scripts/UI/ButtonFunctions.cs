using Root.Ultrasound;
using UnityEngine;

namespace Root.UI
{
    public class ButtonFunctions : MonoBehaviour
    {
        private ImageLoader imageLoader;
        private HandMenuSimulator handMenuSimulator;
        
        // Start is called before the first frame update
        void Start()
        {
            imageLoader = FindObjectOfType<ImageLoader>();
            handMenuSimulator = FindObjectOfType<HandMenuSimulator>();
        }

        /// <summary>
        /// Pause the stream of images coming in from the probe
        /// </summary>
        public void PauseImaging()
        {
            imageLoader.isPaused = !imageLoader.isPaused;
            handMenuSimulator.imagingPausedText.enabled = imageLoader.isPaused;
            handMenuSimulator.pauseButtonText.text = imageLoader.isPaused ? "Play" : "Pause";
        }

        /// <summary>
        /// Change whether the data path text display is visible
        /// </summary>
        public void ToggleDataPathText()
        {
            handMenuSimulator.dataPathText.enabled = !handMenuSimulator.dataPathText.enabled;
            handMenuSimulator.showDataPathButtonText.text =
                handMenuSimulator.dataPathText.isActiveAndEnabled ? "Hide Path" : "Show Path";
        }

        /// <summary>
        /// Recenter the image to be in the middle of the viewport
        /// </summary>
        public void RecenterImage()
        {
            imageLoader.RecenterImage();
        }
    }
}
