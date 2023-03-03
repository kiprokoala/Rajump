using JetBrains.Annotations;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogTrigger : MonoBehaviour
{
    public bool isInRange;
    public Animator animator;

    public Text nameUI;
    public Text textUI;

    public string creatureName;

    public static DialogTrigger instance;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    private void Update()
    {
        if ((isInRange && Input.GetKeyDown(KeyCode.I)) || (isInRange && tag == "Reaper"))
        {
            PlayerMovement.instance.enabled = false;
            PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Kinematic;
            PlayerMovement.instance.rb.velocity = Vector3.zero;
            PlayerMovement.instance.animator.SetFloat("Speed", 0);
            animator.SetBool("buttonPressed", false);
            animator.SetBool("enterDialog", true);
            StartDialog();
        }
    }

    void StartDialog()
    {
        string text = "";
        string the_name = "";
        switch (creatureName) {
            case "Vampire":
                the_name = "Vampire";
                text = "My allies are strong, but with my blood, you will be faster than ever!";
                break;
            case "Witch":
                the_name = "Witch";
                text = "My allies are unkillable, but with my potions, you will be unbeatable!";
                break;
            case "Reaper":
                the_name = "Reaper";
                text = "Let's get somewhere empty, so I don't make too much damage.";
                break;
        }
        nameUI.text = the_name;
        StopAllCoroutines();
        StartCoroutine(typeDialog(text));
    }

    public void CloseDialog()
    {
        PlayerMovement.instance.enabled = true;
        PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Dynamic;
        animator.SetBool("buttonPressed", true);
        animator.SetBool("enterDialog", false);
    }

    public void yesClick()
    {

        PlayerMovement.instance.enabled = true;
        PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Dynamic;
        animator.SetBool("buttonPressed", true);
        animator.SetBool("enterDialog", false);
        StartCoroutine(changeScene());
    }
    IEnumerator changeScene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(creatureName + 1);
    }

    IEnumerator typeDialog(string text)
    {
        textUI.text = "";
        foreach (char charac in text)
        {
            textUI.text += charac;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
