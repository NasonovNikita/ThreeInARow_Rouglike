using UnityEngine;
using UnityEngine.UI;

namespace UI.MessageWindows
{
    public class InfoWindow : MonoBehaviour
    {
        public static InfoWindow instance;
        [SerializeField] private Object windowPrefab;
        private GameObject window;
        private RectTransform windowTransform;
        private Text windowText;
        private RectTransform textTransform;

        public Vector2 WindowSize => window == null ? Vector2.zero : textTransform.sizeDelta;

        public void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else Destroy(gameObject);
        }

        public void Close()
        {
            if (window != null) Destroy(window);
        }

        // ReSharper disable Unity.PerformanceAnalysis
        public void Write(string content)
        {
            if (window != null) Destroy(window.gameObject);
            window = (GameObject) Instantiate(windowPrefab, FindFirstObjectByType<Canvas>().transform);
            windowText = window.GetComponentInChildren<Text>();
            textTransform = windowText.GetComponent<RectTransform>();
            windowText.text = content;
            ContentSizeFitter fitter = windowText.GetComponent<ContentSizeFitter>();
            fitter.SetLayoutHorizontal();
            fitter.SetLayoutVertical();
            
            windowTransform = window.GetComponent<RectTransform>();
        }

        public void MoveTo(Vector3 position, Vector3 localShift = new())
        {
            if (window == null) return;

            Transform wTr = window.transform;
            
            wTr.position = position;
            var localPosition = wTr.localPosition;
            var localScale = wTr.localScale;
            localPosition += localShift;
            
            wTr.localPosition = localPosition;
            Rect rect = windowTransform.rect;
            float y = localPosition.y * localScale.y;
            float x = localPosition.x * localScale.x;
            float height = WindowSize.y;
            float width = WindowSize.x;
            float screenHeight = FindFirstObjectByType<CanvasScaler>().referenceResolution.y;
            float screenWidth = FindFirstObjectByType<CanvasScaler>().referenceResolution.x;

            if (y - height / 2 <= -screenHeight / 2 ||
                y + height / 2 >= screenHeight / 2)
            {
                wTr.localPosition -= new Vector3(0, localShift.y) * 2;
            }
            
            if (x - width / 2 <= -screenWidth / 2 ||
                x + width / 2 >= screenWidth / 2)
            {
                wTr.localPosition -= new Vector3(localShift.x, 0) * 2;
            }
        }
    }
}