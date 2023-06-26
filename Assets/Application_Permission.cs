using UnityEngine;
using UnityEngine.Android;
//using UnityEngine.iOS;
//using UnityEngine.Windows;

public class Application_Permission : MonoBehaviour
{

    void Start()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
        {
            Permission.RequestUserPermission(Permission.Camera);
            return; // Exit the method until the permission is granted
        }
        if (!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite))
        {
            Permission.RequestUserPermission(Permission.ExternalStorageWrite);
            return; // Exit the method until the permission is granted
        }
        if (!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageRead))
        {
            Permission.RequestUserPermission(Permission.ExternalStorageRead);
            return; // Exit the method until the permission is granted
        }
#if PLATFORM_IPHONE // saka nato nag e-error -eu gene
        /*if (!UnityEngine.iOS.Permission.HasUserAuthorizedPermission(UnityEngine.iOS.Permission.Camera))
        {
            UnityEngine.iOS.Permission.RequestUserPermission(UnityEngine.iOS.Permission.Camera);
            return; // Exit the method until the permission is granted
        }*/
#endif
    }

}
