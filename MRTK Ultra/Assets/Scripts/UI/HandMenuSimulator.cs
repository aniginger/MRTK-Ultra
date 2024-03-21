using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Root.UI
{
    public class HandMenuSimulator : MonoBehaviour
    {
        [Header("Canvas")]
        [SerializeField] private GameObject handMenuCanvas;
        
        [Header("UI")]
        public TextMeshProUGUI imagingPausedText;

        // Start is called before the first frame update
        void Start()
        {
            handMenuCanvas.SetActive(false);
            imagingPausedText.enabled = false;
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
