using TMPro;
using UnityEngine;

namespace Root.UI
{
    public class HandMenuSimulator : MonoBehaviour
    {
        [Header("Canvas")]
        [SerializeField] private GameObject handMenuCanvas;

        [Header("UI")]
        public TextMeshProUGUI dataPathText;
        public TextMeshProUGUI imagingPausedText;
        public TextMeshProUGUI noImageDetectedText;
        public TextMeshProUGUI pauseButtonText;
        public TextMeshProUGUI showDataPathButtonText;

        // Start is called before the first frame update
        void Start()
        {
            handMenuCanvas.SetActive(false);
            dataPathText.enabled = false;
            imagingPausedText.enabled = false;
            noImageDetectedText.enabled = false;

            pauseButtonText.text = "Pause";
            showDataPathButtonText.text = "Show Path";
        }
        
        // Update is called once per frame
        void Update()
        {
            SimulateHandPresent();
        }

        /// <summary>
        /// Use the 'P' key to simulate a hand being present
        /// </summary>
        private void SimulateHandPresent()
        {
            if (Input.GetKeyDown(KeyCode.P)) ToggleCanvas(true);
        }


        /// <summary>
        /// Toggle the hand UI canvas on or off depending on the current state
        /// </summary>
        /// <param name="isActive">Whether the menu should be set to be active</param>
        public void ToggleCanvas(bool isActive)
        {
            handMenuCanvas.SetActive(isActive);
        }
    }
}
