using UnityEngine;
#if UNITY_ANDROID
using UnityEngine.Android;
#endif

public class PermissionRequest : MonoBehaviour
{

    private void Start()
    {
#if UNITY_ANDROID
        if(!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
        }
#endif
    }

}
