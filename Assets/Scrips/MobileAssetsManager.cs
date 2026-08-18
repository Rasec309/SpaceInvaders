using UnityEngine;
using UnityEngine.UI;

public class MobileAssetsManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] mobileAssets;
    [SerializeField]
    private GameObject[] desktopAssets;
    [SerializeField]
    private Transform desktopCamera;
    [SerializeField]
    private Transform mobileCamera;
    [SerializeField]
    private Canvas gameCanvas;
    [SerializeField]
    private float canvasDistanceFromCamera = 867;
    [SerializeField]
    private float canvasMobileDistanceFromCamera = 650;
    private void Awake()
    {
        if (Application.isEditor)
        {
            SetActiveAssets(desktopAssets, true);
            SetCanvasToCamera(desktopCamera, canvasDistanceFromCamera);
        }
        else if (Application.isMobilePlatform)
        {
            SetActiveAssets(mobileAssets, true);
            SetCanvasToCamera(mobileCamera, canvasMobileDistanceFromCamera);
        }
        else
        {
            SetActiveAssets(desktopAssets, true);
            SetCanvasToCamera(desktopCamera, canvasDistanceFromCamera);
        }
    }
    private void SetActiveAssets(GameObject[] assets, bool isActive)
    {
        foreach (var asset in assets)
        {
            asset.SetActive(isActive);
        }
    }
    private void SetCanvasToCamera(Transform cameraTransform, float distanceFromCamera = 0)
    {
        gameCanvas.transform.SetParent(cameraTransform);
        gameCanvas.transform.localPosition = new Vector3(0, 0, distanceFromCamera);
    }
}
