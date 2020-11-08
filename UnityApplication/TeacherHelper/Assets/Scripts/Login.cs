using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Login : MonoBehaviour
{

    public Button GuestBtn;
    public Button SignInBtn;
    public Button CompleteSignInBtn;
    public Button BackBtn;

    public GameObject SignInPanel;
    public GameObject initialPanel;


    // Start is called before the first frame update
    void Start()
    {
        GuestBtn.onClick.AddListener(delegate { guestClick(); });
        SignInBtn.onClick.AddListener(delegate { signInClick(); });
        CompleteSignInBtn.onClick.AddListener(delegate { finishSignIn(); });
        BackBtn.onClick.AddListener(delegate { back(); });
    }


    void back()
    {
        initialPanel.SetActive(true);
        SignInPanel.SetActive(false);
    }
    void signInClick()
    {
        initialPanel.SetActive(false);
        SignInPanel.SetActive(true);
    }

    void guestClick()
    {
        SceneManager.LoadScene("Home");
    }

    // here you should check whether or not the sign in information is correct
    void finishSignIn()
    {
        SceneManager.LoadScene("HomeMenu");
    }

}
