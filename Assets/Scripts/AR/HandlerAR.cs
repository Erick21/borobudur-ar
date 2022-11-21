using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HandlerAR : MonoBehaviour
{
    [SerializeField] Image _screenshot;
    [SerializeField] GameObject _topContainer, _bottomContainer;
    //readonly string IMAGE_NAME = Application.persistentDataPath + "/borobudur-ar.png";

    public void CloseApp()
    {
        Application.Quit();
    }

    public void DoCapture()
    {
        StartCoroutine(Capture());
    }

    IEnumerator Capture()
    {
        yield return null;

        // Disable UI       
        _topContainer.SetActive(false); _bottomContainer.SetActive(false);

        // Wait for screen rendering to complete
        yield return new WaitForEndOfFrame();

        // Take screenshot
        //ScreenCapture.CaptureScreenshot(IMAGE_NAME);
        Texture2D texture = ScreenCapture.CaptureScreenshotAsTexture();

        // Show UI after we're done
        _topContainer.SetActive(true); _bottomContainer.SetActive(true);

        // Show on Image UI
        yield return new WaitForSeconds(1);
        //Texture2D texture = LoadPNG(IMAGE_NAME);
        _screenshot.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        _screenshot.gameObject.SetActive(true);
    }

    //public static Texture2D LoadPNG(string filePath)
    //{
    //    Texture2D texture = null;
    //    byte[] fileData;

    //    if (File.Exists(filePath))
    //    {
    //        fileData = File.ReadAllBytes(filePath);
    //        texture = new Texture2D(2, 2);
    //        if (texture.LoadImage(fileData))  // Load the imagedata into the texture (size is set automatically)
    //            return texture;
    //        texture.LoadImage(fileData); //..this will auto-resize the texture dimensions.
    //    }
    //    return null;
    //}

    public void DoRetake()
    {
        _screenshot.gameObject.SetActive(false);
    }

    public void GoTo3DMode()
    {
        SceneManager.LoadScene("3D");
    }
}
