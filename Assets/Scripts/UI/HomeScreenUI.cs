using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeScreenUI : MonoBehaviour
{
    public void OnLoginPressed() {
        Debug.Log("Login clicked");
        // SceneManager.LoadScene("LoginScene");
    }

    public void OnSignupPressed() {
        Debug.Log("Signup clicked");
        // SceneManager.LoadScene("SignupScene");
    }
}
