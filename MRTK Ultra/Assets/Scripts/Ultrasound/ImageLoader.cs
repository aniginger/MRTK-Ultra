using System.IO;
using TMPro;
using UnityEngine;

namespace Root.Ultrasound
{
    public class ImageLoader : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private Material material; // Material used by quad
        [SerializeField] private MeshRenderer meshRenderer; // Image Renderer

        [Header("Global Variables")]
        [SerializeField] private string fileName = "currentFrame.jpg"; // Adjust the file name as needed
        [SerializeField] private float updateInterval = 0.1f; // Adjust the update interval as needed
        [HideInInspector] public bool isPaused = false; // Whether the image should update; hidden in inspector to avoid desync with button functions

        [Header("UI")]
        public TextMeshProUGUI dataPathText;
        [SerializeField] private TextMeshProUGUI noImageDetectedText;

        private string dataPath;
        private string filePath;

        private float lastUpdateTime;
        private static readonly int MainTex = Shader.PropertyToID("_MainTex");

        // Start is called before the first frame update
        void Start()
        {
            SetDataPath();
            lastUpdateTime = Time.time;
            LoadAndDisplayImage();
        }

        // Update is called once per frame
        void Update()
        {
            if (isPaused) return;
            
            // Update the image at the specified interval
            if (!(Time.time - lastUpdateTime > updateInterval)) return;
            LoadAndDisplayImage();
            lastUpdateTime = Time.time;
        }

        /// <summary>
        /// Sets the data path and file path, and displays the data path on screen
        /// </summary>
        private void SetDataPath()
        {
            // Get the path to the persistent data folder and the file name of the frame
            dataPath = Application.persistentDataPath;
            filePath = Path.Combine(dataPath, fileName);
            Debug.Log(filePath);
            if (dataPathText != null) dataPathText.text = dataPath;
        }

        /// <summary>
        /// Toggle whether the image should be displayed to the user
        /// </summary>
        /// <param name="isActive">Whether the imaging is currently active (detecting image feed)</param>
        private void ToggleImageVisibility(bool isActive)
        {
            meshRenderer.enabled = isActive;
            noImageDetectedText.enabled = !isActive;
        }

        // ReSharper disable Unity.PerformanceAnalysis
        /// <summary>
        /// Finds image from persistent data path and displays it to the plane
        /// </summary>
        private void LoadAndDisplayImage()
        {
            // Inside try-catch to avoid runtime pause error
            try
            {
                // Check if the file exists
                if (File.Exists(filePath))
                {
                    // Load the image file into a byte array
                    byte[] fileData = File.ReadAllBytes(filePath);

                    // Create a Texture2D and load the image data into it
                    Texture2D texture = new Texture2D(2, 2);
                    texture.LoadImage(fileData);

                    // Assign the texture to the RawImage component
                    material.SetTexture(MainTex, texture);
                    ToggleImageVisibility(true);
                }
                else
                {
                    // File path not found
                    ToggleImageVisibility(false);
                }
            }
            catch
            {
                // Tried to retrieve file while it was being updated
                // Catching so application does not pause
            }

        }
    }
}