using UnityEngine;

public class MobileAssetsManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] moblibeAsset;
    [SerializeField]
    private GameObject[] desktopAssets;
    private void Awake()
    {
         #if UNITY_IOS || UNITY_ANDROID
            {
                foreach(var asset in moblibeAsset)
                {
                    asset.SetActive(true);
                }
            }
            #else
            {
                foreach( var asset in desktopAssets)
                {
                    asset.SetActive(true);
                }
            }
            #endif
    }
}
